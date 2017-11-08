using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Portal.Application.HR.Dto;
using Portal.Infrastructure.Repository;
using Portal.Core.HR;
using AutoMapper;
using System.Linq;

namespace Portal.Application.HR
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper iMapper;
        public EmployeeAppService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeListDto>();
                cfg.CreateMap<Employee, EmployeeInputDto>();
                cfg.CreateMap<EmployeeListDto, Employee>();
                cfg.CreateMap<Designation, DesignationListDto>();
                cfg.CreateMap<ProfilePhoto, ProfilePhotoListDto>();
            });
        }

        public async Task<EmployeeInputDto> GetAsync(int companyId)
        {
            Employee employee = await _employeeRepository.GetAsync(companyId);
            if (employee.IsDeleted != true)
            {
                EmployeeInputDto employeeDto = iMapper.Map<EmployeeInputDto>(employee);
                return employeeDto;
            }
            return null;
        }

        public async Task<List<EmployeeListDto>> GetAllAsync()
        {
            var employees = (await _employeeRepository.GetAllAsync()).Where(x => x.IsDeleted != true);
            List<EmployeeListDto> employeeListDtos = new List<EmployeeListDto>();
            if (employees != null)
                employeeListDtos = iMapper.Map<List<EmployeeListDto>>(employees);
            return employeeListDtos;
        }

        public async Task<EmployeeInputDto> SaveAsync(EmployeeInputDto employeeDto, string userName)
        {
            Employee employee = iMapper.Map<Employee>(employeeDto);
            if (employee.Id > 0)
            {
                employee.ModificationTime = DateTime.Now;
                employee.ModifiedBy = userName;
                await _employeeRepository.UpdateAsync(employee, employee.Id);
            }
            else
            {
                employee.CreationTime = DateTime.Now;
                employee.CreatedBy = userName;
                await _employeeRepository.InsertAsync(employee);
            }
            return employeeDto;
        }

        public async Task Delete(int id, string userName)
        {
            Employee employee = await _employeeRepository.GetAsync(id);
            if (employee != null)
            {
                employee.IsDeleted = true;
                employee.DeletionTime = DateTime.Now;
                employee.DeletedBy = userName;
                await _employeeRepository.Delete(employee);
            }
        }
    }
}

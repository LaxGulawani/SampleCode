using Portal.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Portal.Core;
using System.Threading.Tasks;
using Portal.Application.Dto;
using AutoMapper;
using System.Linq;

namespace Portal.Application
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IMapper iMapper;
        public CompanyAppService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyListDto>();
                cfg.CreateMap<Company, CompanyDto>();
                cfg.CreateMap<CompanyDto, Company>();
            });

            iMapper = config.CreateMapper();
        }

        public async Task<List<CompanyListDto>> GetAllAsync()
        {
            var companies = (await _companyRepository.GetAllAsync()).Where(x => x.IsDeleted != true);
            List<CompanyListDto> companyListDtos = new List<CompanyListDto>();
            if (companies != null)
                companyListDtos = iMapper.Map<List<CompanyListDto>>(companies);
            return companyListDtos;
        }

        public async Task<CompanyDto> GetAsync(int companyId)
        {
            Company company = await _companyRepository.GetAsync(companyId);
            if (company.IsDeleted != true)
            {
                CompanyDto companyDto = iMapper.Map<CompanyDto>(company);
                return companyDto;
            }
            return null;
        }

        public async Task<CompanyDto> SaveAsync(CompanyDto companyDto, string userName)
        {
            Company company = iMapper.Map<Company>(companyDto);
            if (company.Id > 0)
            {
                company.ModificationTime = DateTime.Now;
                company.ModifiedBy = userName;
                await _companyRepository.UpdateAsync(company, company.Id);
            }
            else
            {
                company.CreationTime = DateTime.Now;
                company.CreatedBy = userName;
                await _companyRepository.InsertAsync(company);
            }
            return companyDto;
        }

        public async Task Delete(int id,string userName)
        {
            Company company = await _companyRepository.GetAsync(id);
            if (company != null)
            {
                company.IsDeleted = true;
                company.DeletionTime = DateTime.Now;
                company.DeletedBy = userName;
                await _companyRepository.Delete(company);
            }
        }
    }
}

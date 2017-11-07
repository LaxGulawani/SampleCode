using Portal.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Portal.Core;
using System.Threading.Tasks;
using Portal.Application.Dto;
using AutoMapper;

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
            var companies = await _companyRepository.GetAllAsync();
            List<CompanyListDto> companyListDtos = new List<CompanyListDto>();
            if (companies != null)
                companyListDtos = iMapper.Map<List<CompanyListDto>>(companies);
            return companyListDtos;
        }

        public async Task<CompanyDto> GetAsync(int companyId)
        {
            Company company = await _companyRepository.GetAsync(companyId);
            CompanyDto companyDto = iMapper.Map<CompanyDto>(company);
            return companyDto;
        }

        public async Task<CompanyDto> SaveAsync(CompanyDto companyDto)
        {
            Company company = iMapper.Map<Company>(companyDto);
            if (company.Id > 0)
                await _companyRepository.UpdateAsync(company, company.Id);
            else
                await _companyRepository.InsertAsync(company);
            return companyDto;
        }
        
        public async Task Delete(int id)
        {            
            Company company = await _companyRepository.GetAsync(id);
            if (company != null)
            {
                company.IsDeleted = true;
                company.DeletionTime = DateTime.Now;
                _companyRepository.Delete(company);
            }
        }
    }
}

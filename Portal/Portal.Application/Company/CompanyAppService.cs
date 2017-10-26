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

        public CompanyAppService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyListDto>> GetAllAsync()
        {
            var companies = await _companyRepository.GetAllAsync();
            var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Company, CompanyListDto>();
            });
            IMapper iMapper = config.CreateMapper();

            List<CompanyListDto> companyListDtos = iMapper.Map<List<CompanyListDto>>(companies);

            return companyListDtos;
        }

        public Task<Company> GetAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<Company> InsertAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<Company> UpdateAsync(Company company, int companyId)
        {
            throw new NotImplementedException();
        }
    }
}

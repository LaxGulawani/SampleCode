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
    /// <summary>
    /// Company Service class implements the methods to manage the company information
    /// </summary>
    public class CompanyAppService : ICompanyAppService
    {
        /// <summary>
        /// Company repository class to provide data access to company entity
        /// </summary>
        private readonly IRepository<Company> _companyRepository;
        private readonly IMapper iMapper;

        /// <summary>
        /// Public Constructor accepts repository injected to it
        /// </summary>
        /// <param name="companyRepository">Injected repositry</param>
        public CompanyAppService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;

            //Configure mapping for automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyListDto>();
                cfg.CreateMap<Company, CompanyDto>();
                cfg.CreateMap<CompanyDto, Company>();
            });

            iMapper = config.CreateMapper();
        }

        /// <summary>
        /// Get all active companies
        /// </summary>
        /// <returns>List of companies</returns>
        public async Task<List<CompanyListDto>> GetAllAsync()
        {
            var companies = (await _companyRepository.GetAllAsync()).Where(x => x.IsDeleted != true);
            List<CompanyListDto> companyListDtos = new List<CompanyListDto>();
            if (companies != null)
                companyListDtos = iMapper.Map<List<CompanyListDto>>(companies);
            return companyListDtos;
        }

        /// <summary>
        /// Get company of specified Id
        /// </summary>
        /// <param name="companyId">Company Id of company you would like to fetch information</param>
        /// <returns>CompanyDto object</returns>
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


        /// <summary>
        /// Saves Company information to database
        /// </summary>
        /// <param name="companyDto">CompanyDto object containing new or existing company</param>
        /// <param name="userName">UserId</param>
        /// <returns>Returns CompanyDto object with Id if newly created or same object in case of updation</returns>
        public async Task<CompanyDto> SaveAsync(CompanyDto companyDto, string userName)
        {
            Company company = iMapper.Map<Company>(companyDto);
            //If company already exists update company
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

        /// <summary>
        /// Soft delete specified company record
        /// </summary>
        /// <param name="id">Company id, which you would like to mark as deleted</param>
        /// <param name="userName">userId</param>
        /// <returns></returns>
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

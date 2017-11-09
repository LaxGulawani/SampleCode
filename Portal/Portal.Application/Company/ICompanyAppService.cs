using Portal.Application.Dto;
using Portal.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portal.Application
{
    /// <summary>
    /// Interface for Company App Service
    /// </summary>
    public interface ICompanyAppService
    {
        Task<List<CompanyListDto>> GetAllAsync();
        Task<CompanyDto> GetAsync(int companyId);
        Task<CompanyDto> SaveAsync(CompanyDto company,string userName);
        Task Delete(int id,string userName);

    }
}

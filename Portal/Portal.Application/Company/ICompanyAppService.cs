using Portal.Application.Dto;
using Portal.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portal.Application
{
    public interface ICompanyAppService
    {
        Task<List<CompanyListDto>> GetAllAsync();
        Task<CompanyDto> GetAsync(int companyId);
        Task<CompanyDto> SaveAsync(CompanyDto company,string userName);
        Task Delete(int id,string userName);

    }
}

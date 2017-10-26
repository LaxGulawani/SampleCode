using Portal.Application.Dto;
using Portal.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application
{
    public interface ICompanyAppService
    {
        Task<List<CompanyListDto>> GetAllAsync();
        Task<Company> GetAsync(int companyId);
        Task<Company> InsertAsync(Company company);
        Task<Company> UpdateAsync(Company company, int companyId);
        void Delete(int id);

    }
}

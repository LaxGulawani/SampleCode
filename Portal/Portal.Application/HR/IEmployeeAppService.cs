using Portal.Application.HR.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.HR
{
    public interface IEmployeeAppService
    {
        Task<List<EmployeeListDto>> GetAllAsync();
        Task<EmployeeInputDto> GetAsync(int companyId);
        Task<EmployeeInputDto> SaveAsync(EmployeeInputDto company, string userName);
        Task Delete(int id, string userName);
    }
}

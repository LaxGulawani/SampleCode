using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Application;
using Portal.Application.Dto;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Portal.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Portal.Web.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly ICompanyAppService _companyAppService;
        private readonly string userName = String.Empty;

        public CompanyController(ICompanyAppService companyAppService, IHttpContextAccessor httpContextAccessor)
        {
            _companyAppService = companyAppService;           
            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                userName = httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public async Task<IActionResult> Index()
        {
            List<CompanyListDto> companyList = await _companyAppService.GetAllAsync();
            return View(companyList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateOrUpdate", new CompanyDto());
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int companyId)
        {
            CompanyDto company = await _companyAppService.GetAsync(companyId);
            return View("CreateOrUpdate", company);
        }


        [HttpPost]
        public async Task<ActionResult> CreateOrUpdate(CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {              
                await _companyAppService.SaveAsync(companyDto, userName);
                return RedirectToAction("Index");
            }
            return View(companyDto);
        }
        public ActionResult CreateOrupdate()
        {
            return View();
        }

        public async Task<ActionResult> Delete(int companyId)
        {
            await _companyAppService.Delete(companyId, userName);
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Application;
using Portal.Application.Dto;

namespace Portal.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
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
                await _companyAppService.SaveAsync(companyDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult CreateOrupdate()
        {
            return View();
        }

        public ActionResult Delete(int companyId)
        {
            _companyAppService.Delete(companyId);
            return RedirectToAction("Index");
        }
    }
}
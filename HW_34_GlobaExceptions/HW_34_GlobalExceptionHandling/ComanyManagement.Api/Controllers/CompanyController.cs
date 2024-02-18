using CompanyManagement.Application;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService, ICompanyService companyService1)
        {
            _companyService = companyService;
        }

        #region Endpoints

        [HttpGet]
        public List<string> GetCompanies()
        {
            return _companyService.GetCompanies();
        }


        [HttpGet("{id}")]
        public ActionResult<string> GetCompanyByName(string id)
        {
            var companies = _companyService.GetCompanyByName(id);
            return Ok(companies);

        }

        #endregion
    }
}

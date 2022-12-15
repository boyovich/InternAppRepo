using AutoMapper;
using InternApp.Domain.DTOs;
using InternApp.Domain.Entities;
using InternApp.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace InternApp.API.Controllers
{
    [ApiController]
    [Route("/Company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
            _mapper = mapper;
        }
        /*public IEnumerable<Company> GetAllCompanies();
        public Company CreateCompany(CreateCompanyDTO companyDTO);
        public Company UpdateCompany(string id, UpdateCompanyDTO companyDTO);
        public void DeleteCompany(string id); */
        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetAllCompanies()
        {
            var companies = _companyService.GetAllCompanies();
            return Ok(companies);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Company), StatusCodes.Status201Created)]
        public ActionResult<Company> CreateCompany([FromBody] CreateCompanyDTO companyDTO)
        {
            var company = _companyService.CreateCompany(_mapper.Map<Company>(companyDTO));
            return CreatedAtRoute("CreateCompany", company);
        }
        [HttpPut("{id}")]
        public ActionResult<Company> UpdateCompany(string id, [FromBody] UpdateCompanyDTO companyDTO)
        {
            var company = _companyService.UpdateCompany(id, companyDTO);
            return Ok(company);
        }
        [HttpDelete]
        public IActionResult DeleteCompany(string id)
        {
            _companyService.DeleteCompany(id);
            return Ok();
        }
    }
}

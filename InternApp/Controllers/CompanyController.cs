﻿using AutoMapper;
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

        [HttpGet]
        public ActionResult<PaginationResponse<CompanyDTO>> GetAllCompanies()
        {
            var companies = _companyService.GetAllCompanies();
            return Ok(new PaginationResponse<CompanyDTO> { ResponseList = _mapper.Map<List<CompanyDTO>>(companies.ResponseList), Count = companies.Count });
        }
        [HttpPut]
        public ActionResult<PaginationResponse<CompanyDTO>> GetCompanies([FromBody] PaginationRequest request)
        {
            var companies = _companyService.GetCompanies(request);
            return Ok(new PaginationResponse<CompanyDTO> {ResponseList = _mapper.Map<List<CompanyDTO>>(companies.ResponseList), Count =  companies.Count});
        }

        [HttpPost("createCompany")]
        [ProducesResponseType(typeof(Company), StatusCodes.Status201Created)]
        public ActionResult<Company> CreateCompany([FromBody] CreateCompanyDTO companyDTO)
        {
            var company = _companyService.CreateCompany(_mapper.Map<Company>(companyDTO));
            return Ok(company); 
        }

        [HttpPut("{id}")]
        public ActionResult<Company> UpdateCompany(Guid id, [FromBody] UpdateCompanyDTO companyDTO)
        {
            var company = _companyService.UpdateCompany(id, companyDTO);
            return Ok(company);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(Guid id)
        {
            _companyService.DeleteCompany(id);
            return Ok();
        }
    }
}

﻿using AutoMapper;
using InternApp.Domain.DTOs;
using InternApp.Domain.Entities;
using InternApp.Service.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InternApp.API.Controllers
{
    [ApiController]
    [Route("/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPut("getAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers([FromBody] PaginationRequest paginationRequest)
        {
            var users = await _userService.GetAllUsers(paginationRequest.pageNumber, paginationRequest.pageSize);           
            return Ok(_mapper.Map<List<UserDTO>>(users));
        }

        [HttpPut("getUsersByCompany/{companyId}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsersByCompanyId(Guid companyId, [FromBody] PaginationRequest paginationRequest)
        {
            var users = await _userService.GetAllUsersByCompanyId(companyId, paginationRequest.pageNumber, paginationRequest.pageSize);          
            return Ok(_mapper.Map<List<UserDTO>>(users));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Domain.Entities.User), StatusCodes.Status201Created)]
        public ActionResult<Domain.Entities.User> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var user = _userService.CreateUser(_mapper.Map<Domain.Entities.User>(createUserDTO));
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult<Domain.Entities.User> UpdateUser([FromRoute] Guid id,[FromBody] UpdateUserDTO updateUserDTO)
        {
            var user = _userService.UpdateUser(id, _mapper.Map<Domain.Entities.User>(updateUserDTO));
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}

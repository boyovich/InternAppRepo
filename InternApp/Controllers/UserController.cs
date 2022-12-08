using InternApp.Domain.Entities;
using InternApp.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace InternApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /*public IEnumerable<User> GetAllUsers();
        public IEnumerable<User> GetAllUsersByCompanyId(string companyId);
        public User CreateUser(CreateUserDTO createUserDTO);
        public User UpdateUser(string id, UpdateUserDTO updateUserDTO);
        public void DeleteUser(string id);*/
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
        [HttpGet("{companyId?}")]
        public ActionResult<IEnumerable<User>> GetAllUsersByCompanyId(string companyId)
        {
            return Ok(_userService.GetAllUsersByCompanyId(companyId));
        }
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var user = _userService.CreateUser(createUserDTO);
            return Ok(user);
        }
        [HttpPut]
        public ActionResult<User> UpdateUser(string id,[FromBody] UpdateUserDTO updateUserDTO)
        {
            var user = _userService.UpdateUser(id, updateUserDTO);
            return Ok(user);
        }
        [HttpDelete]
        public IActionResult DeleteUser(string id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}

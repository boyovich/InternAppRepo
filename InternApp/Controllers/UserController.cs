using AutoMapper;
using InternApp.Service.Service;
using Microsoft.AspNetCore.Mvc;
/*public IEnumerable<User> GetAllUsers();
       public IEnumerable<User> GetAllUsersByCompanyId(string companyId);
       public User CreateUser(CreateUserDTO createUserDTO);
       public User UpdateUser(string id, UpdateUserDTO updateUserDTO);
       public void DeleteUser(string id);*/
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
       

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Domain.Entities.User>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            _logger.LogInformation("All users have been reached");
            return Ok(users);
        }

        [HttpGet("{companyId}")]
        public ActionResult<IEnumerable<Domain.Entities.User>> GetAllUsersByCompanyId(Guid companyId)
        {
            return Ok(_userService.GetAllUsersByCompanyId(companyId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Domain.Entities.User), StatusCodes.Status201Created)]
        public ActionResult<Domain.Entities.User> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var user = _userService.CreateUser(_mapper.Map<Domain.Entities.User>(createUserDTO));
            return CreatedAtAction("CreateUser", user);
        }

        [HttpPut]
        public ActionResult<Domain.Entities.User> UpdateUser([FromQuery] Guid id,[FromBody] UpdateUserDTO updateUserDTO)
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

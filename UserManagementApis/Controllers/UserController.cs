using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApis.Models;
using UserManagementApis.Services;

namespace UserManagementApis.Controllers
{
  //  [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/GetAllUsers")]

        public async Task<List<UserDetails>> GetUserDetails() =>
            await _userService.GetUserDetails();

        [HttpGet]
        [Route("api/GetUserById/{id}")]

        public async Task<ActionResult<UserDetails>> GetUserDetailsById(int id)
        {
            var user = await _userService.GetUserDetailsById(id);

            if (user is null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        [Route("api/CreateUser")]

        public async Task<IActionResult> CreateUser(UserDetails userDetails)
        {
            await _userService.CreateUser(userDetails);
            return CreatedAtAction(nameof(GetUserDetails), new { id = userDetails._id }, userDetails);
        }

        [HttpPut]
        [Route("api/UpdateUser/{id}")]

        public async Task<IActionResult> UpdateUser(UserDetails userDetails, int id)
        {
            var userDetail = await _userService.GetUserDetailsById(id);
            if (userDetail is null)
            {
                return NotFound();
            }
            userDetails._id = userDetail._id;
            await _userService.UpdateUser(userDetails, id);
            return NoContent();
        }

        [HttpDelete]
        [Route("api/DeleteUser/{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            var userDetail = await _userService.GetUserDetailsById(id);
            if (userDetail is null)
            {
                return NotFound();
            }
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}

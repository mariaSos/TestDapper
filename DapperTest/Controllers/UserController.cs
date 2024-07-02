using DapperTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    
        public class UserController : ControllerBase
        {

            private readonly IUserRepository _userRepository;

            public UserController(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            [HttpGet]
            [Route("user/{id}")]

            public ActionResult<User> GetUseerById(int id)
            {

                var user = _userRepository.Get(id);

                return Ok(user);

            }
        [HttpPost]
        [Route("addUser")]

        public ActionResult<User> AddUser(User user) 
        {

            try
            {
                _userRepository.Create(user);
                return Ok("");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




    }
}


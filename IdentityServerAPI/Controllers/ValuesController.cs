using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Core;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerAPI.Controllers
{
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;

        public ValuesController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [Route("api/authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Email, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });
            return Ok(user);
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var users = _userService.GetAll();                
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                var user = _userService.GetByID(id);
                if (user == null)
                {                    
                    return NotFound();
                }                
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] RegisterModel model)
        {
            try
            {
                if (await _userService.RegisterUser(model) == true)
                {
                    return Ok(_userService.GetAll());
                }
                return StatusCode(500);
            }
            catch (Exception ex)
            {                
                return StatusCode(500, ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User model)
        {
            try
            {
                await _userService.Update(id, model);
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            try
            {
                if (await _userService.Delete(id))
                {
                    return Ok(_userService.GetAll());
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public ActionResult<User> ForgotPassword(int id, string email)
        {
            try
            {
                _userService.ForgotPassword(id, email);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public async Task<ActionResult<User>> RegisterUser(RegisterModel model)
        {
            try
            {
                User newUser = model;
                await _userService.RegisterUser(model);
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public ActionResult<User> ValidateCredentials(string email, string password)
        {
            try
            {
                var user = _userService.ValidateCredentials(email, password);
                if (user)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public async Task<ActionResult<User>> ChangePassword(int id, ChangePasswordModel model)
        {
            try
            {
                if (await _userService.ChangePassword(id, model))
                {
                    return Ok(model);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL;
using Core;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdentityServerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private static readonly ILog log = LogManager.GetLogger(typeof(UserController));

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var users = _userService.GetAll();
                log.Info("Users called successfully");
                return Ok(users);
            }
            catch (Exception ex)
            {
                log.Error("Couldn't called all users", ex);
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
                    log.Error($"Couldn't find user with the {id}");
                    return NotFound();
                }
                log.Info($"User called by id: {id}");
                return Ok(user);
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error", ex);
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
                    log.Info($"User has been regostered with the email address: {model.regEmail}");
                    return Ok(_userService.GetAll());
                }
                log.Error("Post action error");
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error", ex);
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
                log.Info($"User succesfully updated with the id number:{model.ID}");
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                log.Error($"Couldn't find user with the {id}", ex);
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
                    log.Info($"User with the id number:{id} successfully deleted");
                    return Ok(_userService.GetAll());
                }
                log.Error($"Couldn't find user with the {id}");
                return NotFound();
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error", ex);
                return StatusCode(500, ex);
            }
        }

        public ActionResult<User> ForgotPassword(int id, string email)
        {
            try
            {
                _userService.ForgotPassword(id, email);
                log.Info($"Forgot Password mail has been sent to the user with the email :{email}");
                return Ok();
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error", ex);
                return StatusCode(500, ex);
            }
        }

        public async Task<ActionResult<User>> RegisterUser(RegisterModel model)
        {
            try
            {
                User newUser = model;
                await _userService.RegisterUser(model);
                log.Info("User successfully has been registered.");
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                log.Fatal("Couldnt register user.", ex);
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
                    log.Info("User info matches with database.");
                    return Ok(user);
                }
                log.Error("User info didnt match with database.");
                return NotFound();
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error", ex);
                return StatusCode(500, ex);
            }
        }

        public async Task<ActionResult<User>> ChangePassword(int id, ChangePasswordModel model)
        {
            try
            {
                if (await _userService.ChangePassword(id, model))
                {
                    log.Info("User's password successfully has changed");
                    return Ok(model);
                }
                else
                {
                    log.Error("Couldnt change user's password");
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error", ex);
                return StatusCode(500, ex);
            }
        }
    }
}

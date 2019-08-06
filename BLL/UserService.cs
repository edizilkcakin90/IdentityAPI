using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Helpers;
using DAL;
using Microsoft.Extensions.Options;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<bool> ChangePassword(int id, ChangePasswordModel model)
        {
            var valid = ValidateCredentials(model.Email, model.Password);
            if (valid)
            {
                await _userRepository.ChangePassword(id, model);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _userRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ForgotPassword(int id, string email)
        {
            User model = _userRepository.GetByID(id);
            SendMail(model);
        }

        public IEnumerable<User> GetAll()
        {
            //return _userRepository.GetAll();
            return _userRepository.GetAll().Select(x => {
                x.Password = null;
                return x;
            });
        }

        public User GetByID(int id)
        {
            return _userRepository.GetByID(id);
        }

        public async Task<bool> RegisterUser(RegisterModel model)
        {
            try
            {
                if (model != null)
                {
                    await _userRepository.Add(model);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(int id, User model)
        {
            if (model != null)
            {
                await _userRepository.Update(id, model);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateCredentials(string email, string password)
        {
            var user = _userRepository.GetAll().Any(x => x.Email == email && x.Password == password);
            if (user)
            {
                return true;
            }
            return false;
        }

        public void SendMail(User model)
        {
            MailMessage message = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            message.To.Add(model.Email.ToString());
            message.Subject = "Password Recovery";
            message.From = new System.Net.Mail.MailAddress("ediz.ilkcakin@gmail.com");
            message.Body = "Your Password is :" + model.Password;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com"
            };

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
            SmtpServer.EnableSsl = true;

            smtp.Send(message);
        }

        public User Authenticate(string email, string password)
        {
            var user = _userRepository.GetAll().SingleOrDefault(x => x.Email == email && x.Password == password);
            
            if (user == null)
                return null;

            if (ValidateCredentials(email, password))
            {
                return user;
            }
            return null;
        }
    }
}



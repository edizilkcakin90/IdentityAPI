using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace BLL
{
    public interface IUserService
    {
        Task<bool> RegisterUser(RegisterModel model);
        Task<bool> ChangePassword(int id, ChangePasswordModel model);
        bool ValidateCredentials(string email, string password);
        void ForgotPassword(int id, string email);
        Task<bool> Update(int id, User model);
        Task<bool> Delete(int id);
        IEnumerable<User> GetAll();
        User GetByID(int id);        
    }
}

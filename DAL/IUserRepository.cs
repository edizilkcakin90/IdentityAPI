using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace DAL
{
    public interface IUserRepository
    {
        Task<bool> Add(User model);
        Task<bool> Update(int id, User model);
        Task<bool> Delete(int id);
        IEnumerable<User> GetAll();
        User GetByID(int id);
        Task<bool> ChangePassword(int id, ChangePasswordModel model);
        User GetByEmail(string email);
    }
}

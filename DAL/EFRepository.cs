using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Core;
using DAL.Context;

namespace DAL
{
    public class EFRepository : IUserRepository
    {
        private readonly ProjectContext db;
        public EFRepository(ProjectContext _db)
        {
            db = _db;

        }
        public async Task<bool> Add(User model)
        {
            try
            {
                var newUser = new User
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Age = model.Age,
                    Email = model.Email,
                    IdentityNo = model.IdentityNo,
                    Sex = model.Sex,
                    Password = model.Password
                };
                db.Set<User>().Add(newUser);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> ChangePassword(int id, ChangePasswordModel model)
        {
            try
            {
                var user = GetAll().FirstOrDefault(x => (x.ID == id));
                if (user != null)
                {
                    user.Password = model.NewPassword;
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var user = db.Users.FirstOrDefault(x => x.ID == id);
                if (user != null)
                {
                    db.Set<User>().Remove(user);
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return db.Set<User>().ToList();
        }

        public User GetByEmail(string email)
        {
            return db.Set<User>().FirstOrDefault(x => x.Email == email);
        }

        public User GetByID(int id)
        {
            return db.Set<User>().FirstOrDefault(x => x.ID == id);
        }

        public async Task<bool> Update(int id, User model)
        {
            var user = db.Set<User>().FirstOrDefault(x => (x.ID == id));
            try
            {
                if (user != null)
                {
                    user.Name = model.Name;
                    user.LastName = model.LastName;
                    user.Age = model.Age;
                    user.Email = model.Email;
                    user.IdentityNo = model.IdentityNo;
                    user.Sex = model.Sex;
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

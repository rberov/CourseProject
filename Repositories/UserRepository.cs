using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Helpers;

namespace Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public override void Save(User user)
        {
            if (user.ID == 0)
            {
                base.Create(user);
            }
            else
            {
                base.Update(user, item => item.ID == user.ID);
            }
        }
        public User GetUserByNameAndPassword(string username, string password)
        {
            User user = base.DBSet.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                PasswordManager passManager = new PasswordManager();
                bool isValidPassword = passManager.IsPasswordMatch(password, user.PasswordHash, user.PasswordSalt);
                if (isValidPassword == false)
                {
                    user = null;
                }
            }
            return user;
        }

        public void RegisterUser(string username, string password)
        {
            User user = new User();
            user.Username = username;

            PasswordManager passwordManager = new PasswordManager();

            string salt;

            string hashedPassword = passwordManager.GeneratePasswordHash(password, out salt);

            user.PasswordHash = hashedPassword;
            user.PasswordSalt = salt;

            base.Create(user);

        }

        public User GetUserByName(string username)
        {
            User user = base.DBSet.FirstOrDefault(u => u.Username == username);
            return user;
        }
    }
}

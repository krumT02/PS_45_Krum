using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;
using Welcome.Model;
using Welcome.ViewModel;
using Welcome.View;
using System.Security.AccessControl;

namespace WelcomeExtended.Data
{
    internal class UserData
    {
        private List<User> _users;
        private int _nextid;
        public UserData()
        {
            _users = new List<User>();
            _nextid = 0;
        }
        public void AddUser(User user)
        {
            user.id = _nextid++;
            _users.Add(user);
            Console.WriteLine($"Добавен е потребител: {user.Names}. Общ брой потребители: {_users.Count}");

        }
        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            string encryptedPassword = PasswordHelper.Encrypt(password);
            foreach (var user in _users)
            {
                if(user.Names == name && user.Password == encryptedPassword)
                {
                    Console.WriteLine(user.Names);
                    return true;
                }
                
            }
            return false;
        }
        public bool ValidateUserLambda(string name,string password)
        {
            string encryptedPassword = PasswordHelper.Encrypt(password);
            return _users.Where(x => x.Names == name && x.Password == encryptedPassword).FirstOrDefault() != null ? true : false;
        }
        public bool ValidateUserLinQ(string name, string password)
        {
            string encryptedPassword = PasswordHelper.Encrypt(password);
            var ret = from user in _users
                      where user.Names == name && user.Password == encryptedPassword
                      select user.id;
            return ret != null ? true : false;
        }
        public User? GetUser(string name, string password)
        {
            string encryptedPassword = PasswordHelper.Encrypt(password);
            return _users.FirstOrDefault(z => z.Names.Equals(name, StringComparison.Ordinal) && z.Password.Equals(encryptedPassword, StringComparison.Ordinal));
        }
        public void AssignUserRoles(string name, UserRolesEnum role)
        {
            var obj = _users.FirstOrDefault(x => x.Names == name);
            if (obj != null) obj.Role = role;
            
        }
        public void SetActive(string name, DateTime validUntil)
        {
            var user = _users.FirstOrDefault(u => u.Names == name);
            if (user != null)
            {
                user.Expires = validUntil;
            }
        }
        public void PrintAllUsers()
        {
            foreach (var user in _users)
            {
                Console.WriteLine($"Име: {user.Names}, Парола: {PasswordHelper.Decrypt(user.Password)}, Роля: {user.Role}");
            }
        }

    }
}

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

        }
        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach(var user in _users)
            {
                if(user.Names == name && user.Password == password)
                {
                    return true;
                }
                
            }
            return false;
        }
        public bool ValidateUserLambda(string name,string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password).FirstOrDefault() != null ? true : false;
        }
        public bool ValidateUserLinQ(string name, string password)
        {
            var ret = from user in _users
                      where user.Names == name && user.Password == password
                      select user.id;
            return ret != null ? true : false;
        }
        public User GetUser(string name, string password)
        {

            return _users.FirstOrDefault(z => z.Names == name && z.Password == password);
        }
        public void AssignUserRoles(string name, UserRolesEnum role)
        {
            var obj = _users.FirstOrDefault(x => x.Names == name);
            if (obj != null) obj.Role = role;
            
        }
    }
}

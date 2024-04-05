using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{

    public class UserViewModel
    {
        private readonly User _user;
        public UserViewModel(User user) { _user = user; }

        public string Names
        {
            get { return _user.Names; }
            set { _user.Names = value; }
        }
        public string Password
        {
            get { return PasswordHelper.Decrypt(_user.Password); }
            set { _user.Password = PasswordHelper.Encrypt(value); }
        }
        public UserRolesEnum Role
        {
            get { return _user.Role; }
            set { _user.Role = value; }
        }
        public string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }
        public string Fac_Num
        {
            get { return _user.Fac_Num; }
            set { _user.Fac_Num = value; }
        }

    }
}

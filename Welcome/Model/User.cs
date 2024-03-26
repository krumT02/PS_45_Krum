using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public string Names { get; set; }  
        public string Password { get; set; }
        public UserRolesEnum Role { get; set; }
        public string Email {get; set; }
        public string Fac_Num { get; set; }
        public int id { get; set; }

        public User(string Names, string Password, UserRolesEnum Role, string Email, string Fac_Num)
        {
            this.Names = Names;
            this.Password = Encrypt(Password);   
            this.Role = Role;   
            this.Email = Email;
            this.Fac_Num  = Fac_Num;
        }
       
        public string Encrypt(string Password)
        {
            char[] chars = Password.ToCharArray();
            for(int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] + 1);
            }
            
            return new string(chars);
        }
        public string DeEncrypt(string Password)
        {
            char[] chars = Password.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] - 1);
            }

            return new string(chars);
        }
       
    }
}

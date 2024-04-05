using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class PasswordHelper
{
    public static string Encrypt(string password)
    {
        char[] chars = password.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] + 1); 
        }
        return new string(chars);
    }

    public static string Decrypt(string encryptedPassword)
    {
        char[] chars = encryptedPassword.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] - 1); 
        }
        return new string(chars);
    }
}

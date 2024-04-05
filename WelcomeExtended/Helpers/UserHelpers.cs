using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Helpers
{
    internal static class UserHelpers
    {
        public static string ToString(this User user)
        {
            return $"ID: {user.id}, Name: {user.Names}, Role: {user.Role}";
        }
        public static bool ValidateCredentials( UserData userData, string name, string password)
        {
            var fileLogger = new FileLogger("Authentication", "auth_log.txt");
            if (string.IsNullOrEmpty(name))
            {
                fileLogger.Log(LogLevel.Warning, new EventId(1), $"Опит за вход с празно потребителско име на {DateTime.Now}", null, (state, exception) => state);
                Console.WriteLine( "The name cannot be empty");
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                fileLogger.Log(LogLevel.Warning, new EventId(1), $"Опит за вход за {name} с празна парола на {DateTime.Now}", null, (state, exception) => state);
                Console.WriteLine("The password cannot be empty");
                return false;
            }

            
            bool isValid = userData.ValidateUser(name, password); 
            if (isValid ) 
            {
                fileLogger.Log(LogLevel.Information, new EventId(1), $"Успешен вход за {name} на {DateTime.Now}", null, (state, exception) => state);
                Console.WriteLine("Correct Credentials");
            return true;
            }
            else 
            {
                fileLogger.Log(LogLevel.Warning, new EventId(1), $"Грешен опит за вход за {name} на {DateTime.Now}", null, (state, exception) => state);
                Console.WriteLine("Wrong Credentials"); 
                return false; }
        }
        public static User GetUser( UserData userData, string name, string password)
        {
            
            return userData.GetUser(name, password); 
        }
    }
}

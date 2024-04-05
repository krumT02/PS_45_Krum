using Welcome.Others;
using Welcome.Model;
using Welcome.ViewModel;
using Welcome.View;
using WelcomeExtended.Others;
using WelcomeExtended.Data;
using System.Data;
using System.Xml.Linq;
using WelcomeExtended.Helpers;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                UserData userData = new UserData();
                User studentUser = new User("Student", "123", UserRolesEnum.STUDENT);
                User studentUser1 = new User("Student2", "123", UserRolesEnum.STUDENT);
                User ProfessorUser = new User("Professor", "1234", UserRolesEnum.PROFESSOR);
                User AdminUser = new User("Admin", "1235", UserRolesEnum.ADMIN);

                userData.AddUser(studentUser);
                userData.AddUser(studentUser1);
                userData.AddUser(ProfessorUser);
                userData.AddUser(AdminUser);

                Console.WriteLine("Enter UserName: ");
                string UserName = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string Password = Console.ReadLine();

                if (UserHelpers.ValidateCredentials(userData,UserName, Password))
                {
                    // Потребителят съществува, извличане с GetUser и показване с ToStringExtension
                    User user = userData.GetUser(UserName, Password);
                    if (user != null)
                    {
                        Console.WriteLine(UserHelpers.ToString(user));
                    }
                    else
                    {
                        Console.WriteLine("Потребителят не е намерен.");
                    }
                }
                else
                {
                    Console.WriteLine("Потребителят не е намерен или данните за вход са невалидни.");
                }




            }
            catch (Exception e) 
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally { Console.WriteLine("Executed in any case! "); }
                
        }
    }
}
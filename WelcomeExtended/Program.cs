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
                User studentUser = new User() 
                {
                    Names = "Student1",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                    
                };
                User student2User = new User()
                {
                    Names = "Student2",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT

                };
                User ProfessorUser = new User()
                {
                    Names = "Professor",
                    Password = "1234",
                    Role = UserRolesEnum.PROFESSOR

                };
                User AdminUser = new User()
                {
                    Names = "Admin",
                    Password = "12345",
                    Role = UserRolesEnum.ADMIN

                };

                userData.AddUser(studentUser);
                userData.AddUser(student2User);
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
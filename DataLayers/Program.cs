using DataLayers.DataBase;
using DataLayers.Model;
using Microsoft.Extensions.Logging;

namespace DataLayers
{


    internal class Program
    {
        

        static void Main(string[] args)
        {
            using (var context = new DatabaseContext()) 
            {
                var logger = new Logger(context);
                context.Database.EnsureCreated();
              
                var users = context.Users.ToList();
                Console.WriteLine("Въведете потребителско име:");
                string userName = Console.ReadLine();
                Console.WriteLine("Въведете парола:");
                string userPassword = Console.ReadLine();

                // Проверка за валиден потребител и парола
                bool isValidUser = context.Users.Any(u => u.Names == userName && u.Password == userPassword);

                if (isValidUser)
                {
                    Console.WriteLine("Валиден потребител");
                    logger.Log($"Влязал: {userName}", "Info");
                    bool isAdmin = context.Users.Any(z => z.Role == Welcome.Others.UserRolesEnum.ADMIN);
                    if (isAdmin)
                    {
                        AdminMenu(context,logger); 
                    }
                }
                else
                {
                    Console.WriteLine("Невалидни данни");
                }
                Console.ReadKey();
            }

        }
        public static void AdminMenu(DatabaseContext context, Logger logger)
        {
            {
                

                while (true)
                {
                    Console.WriteLine("Изберете опция:");
                    Console.WriteLine("1. Вземи всички потребители");
                    Console.WriteLine("2. Добави нов потребител");
                    Console.WriteLine("3. Изтрий потребител");
                    Console.WriteLine("4. Изход");

                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            var users = context.Users.ToList();
                            
                            foreach (var user in users)
                            {
                                Console.WriteLine($"{user.id} - {user.Names}");
                            }

                            break;
                        case "2":
                            Console.Write("Въведете име: ");
                            string name = Console.ReadLine();
                            Console.Write("Въведете парола: ");
                            string password = Console.ReadLine();
                            Console.Write("Въведете email: ");
                            string email = Console.ReadLine();
                            Console.Write("Въведете FacNum: ");
                            string FacNum = Console.ReadLine();

                            var newUser = new DataBaseUser { Names = name, Password = password,Email = email, Fac_Num = FacNum };
                            context.Users.Add(newUser);
                            context.SaveChanges();
                            logger.Log($"Добавен е нов потребител: {name}", "Info");
                            break;
                        case "3":
                            Console.Write("Въведете име на потребителя за изтриване: ");
                            string nameToDelete = Console.ReadLine();
                            var userToDelete = context.Users.FirstOrDefault(u => u.Names == nameToDelete);
                            if (userToDelete != null)
                            {
                                context.Users.Remove(userToDelete);
                                context.SaveChanges();
                                logger.Log($"Изтрит потребител: {nameToDelete}", "Info");
                            }
                            else
                            {
                                Console.WriteLine("Потребителят не е намерен.");
                            }
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Невалидна опция.");
                            break;
                    }
                }
            }
        }

    }
}
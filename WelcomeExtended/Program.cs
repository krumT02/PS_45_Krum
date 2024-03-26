using Welcome.Others;
using Welcome.Model;
using Welcome.ViewModel;
using Welcome.View;
using WelcomeExtended.Others;


namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                var user = new User("John Smith", "1234567", UserRolesEnum.STUDENT, "Josh@abv.bg", "121221435");
                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);

                view.Display();

                view.DisplayError();


            }
            catch (Exception e) 
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally { Console.WriteLine("Executed in any case!"); }
                
        }
    }
}
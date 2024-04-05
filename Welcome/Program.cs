using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            { 
                Names = "Student1",
                Password = "password",

            } ;
            
            UserViewModel viewModel = new UserViewModel(user);
            Console.WriteLine(user.Password); Console.WriteLine(viewModel.Password);
            viewModel.Password = "121232AAAAAAA";
            Console.WriteLine(viewModel.Password);
            UserView view = new UserView(viewModel);
            view.Display();




        }

    }
}
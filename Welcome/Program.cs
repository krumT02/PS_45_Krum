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
            User user = new User("Ivan", "123456",UserRolesEnum.STUDENT,"IvanStagram@abv.bg","121221032") ;
            
            UserViewModel viewModel = new UserViewModel(user);
            Console.WriteLine(user.Password); Console.WriteLine(viewModel.Password);
            viewModel.Password = "121232AAAAAAA";
            Console.WriteLine(viewModel.Password);
            UserView view = new UserView(viewModel);
            view.Display();


        }
    }
}
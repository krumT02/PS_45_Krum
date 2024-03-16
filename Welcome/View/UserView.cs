using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private readonly UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel; 
        }
        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine($"User: {_viewModel.Names}");
            Console.WriteLine($"Role: {_viewModel.Role}");
            Console.WriteLine($"Email: {_viewModel.Email}");
            Console.WriteLine($"Fac. Number: {_viewModel.Fac_Num}");
        }
        public void DisplayError() {
            throw new Exception("Error");
        }

    }
}

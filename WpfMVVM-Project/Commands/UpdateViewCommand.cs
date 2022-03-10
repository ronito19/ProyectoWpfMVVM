using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.ViewModels;
using WpfMVVM_Project.Views;

namespace WpfMVVM_Project.Commands
{
    class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            Console.WriteLine(parameter.ToString());
            string vista = parameter.ToString();
            if (vista.Equals("clientes"))
            {
                MainViewModel.SelectedViewModel = new PaginaPrincipalViewModel();
            }
            else if (vista.Equals("formulario"))
            {
                MainViewModel.SelectedViewModel = new GafasViewModel();
            }
            else if (vista.Equals("proveedores") && !vista.Equals(CurrentVista))
            {
                CurrentVista = vista;
                MainViewModel.SelectedViewModel = new ProveedoresTableViewModel();
            }
            else if (vista.Equals("productos") && !vista.Equals(CurrentVista))
            {
                CurrentVista = vista;
                MainViewModel.SelectedViewModel = new ProductosTableViewModel();
            }
            
        }



        public MainViewModel MainViewModel { get; set; }

        string CurrentVista { get; set; }


        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            MainViewModel.SelectedViewModel = new HomeViewModel();

        }
    }
}

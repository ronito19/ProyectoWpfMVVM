using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProveedorCommand
{
    class LoadProveedoresCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            proveedoresTableViewModel.ListaProveedores = ProveedorDBHandler.ObtenerListaProveedores();
        }


        public ProveedoresTableViewModel proveedoresTableViewModel;

        public LoadProveedoresCommand(ProveedoresTableViewModel proveedoresTableViewModel)
        {
            this.proveedoresTableViewModel = proveedoresTableViewModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProveedorCommand
{
    class LoadProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            proveedoresTableViewModel.CurrentProveedor = (Models.ProveedoresModel)parameter;
        }



        public ProveedoresTableViewModel proveedoresTableViewModel { get; set; }

        public LoadProveedorCommand(ProveedoresTableViewModel proveedoresTableViewModel)
        {
            this.proveedoresTableViewModel = proveedoresTableViewModel;
        }
    }
}

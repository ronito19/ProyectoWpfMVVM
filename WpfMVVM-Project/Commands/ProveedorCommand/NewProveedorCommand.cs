using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProveedorCommand
{
    class NewProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool OKinsertar = ProveedorDBHandler.NuevoProveedor(proveedoresTableViewModel.CurrentProveedor);
            if (OKinsertar)
            {
                MessageBox.Show(" Se ha creado el proveedor ");
            }
            else
            {
                MessageBox.Show(" Error al crear el proveedor ");
            }
        }


        private ProveedoresTableViewModel proveedoresTableViewModel;
        public NewProveedorCommand(ProveedoresTableViewModel proveedoresTableViewModel)
        {
            this.proveedoresTableViewModel = proveedoresTableViewModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;
using WpfMVVM_Project.Views;

namespace WpfMVVM_Project.Commands.ProveedorCommand
{
    class DeleteProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            if (parameter is String)
            {
                string accion = parameter.ToString();
                Console.WriteLine(parameter.ToString());

                if (accion.Equals("borrar"))
                {
                    int index = ProveedorDBHandler.BorrarProveedor(proveedoresTableViewModel.CurrentProveedor);
                    proveedoresTableViewModel.ListaProveedores.RemoveAt(index);
                    proveedoresTableViewModel.CurrentProveedor = new Models.ProveedoresModel();
                }

                if (parameter is ProveedoresModel)
                {
                    ProveedoresModel proveedor = (ProveedoresModel)parameter;
                    proveedoresTableViewModel.CurrentProveedor = (ProveedoresModel)proveedor.Clone();
                    proveedoresTableViewModel.SelectedProveedor = (ProveedoresModel)proveedor.Clone();
                }
            }
        }




   
        private ProveedoresTableViewModel proveedoresTableViewModel;

   

        public DeleteProveedorCommand(ProveedoresTableViewModel proveedoresTableViewModel)
        {
            this.proveedoresTableViewModel = proveedoresTableViewModel;
        }
    }
}

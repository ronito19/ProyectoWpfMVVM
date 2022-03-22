using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Services.DataSet;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands
{
    class UpdateClientesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            nuevo_ProductosViewModel.ListaClientes = DataSetHandler.getClientes();
            

        }


        public Nuevo_ProductosViewModel nuevo_ProductosViewModel {set; get;}

        public UpdateClientesCommand(Nuevo_ProductosViewModel nuevo_ProductosViewModel)
        {
            this.nuevo_ProductosViewModel = nuevo_ProductosViewModel;
        }


        


    }
}

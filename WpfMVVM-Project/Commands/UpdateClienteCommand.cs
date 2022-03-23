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
    class UpdateClienteCommand : ICommand
    {
        

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            consultasViewModel.ListaClientes = DataSetHandler.getClientes();
        }


        public ConsultasViewModel consultasViewModel { get; set; }
        public UpdateClienteCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;

        }

        
    }
}

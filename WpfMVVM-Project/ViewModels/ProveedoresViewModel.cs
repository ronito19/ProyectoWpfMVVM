using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands.ProveedorCommand;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    class ProveedoresViewModel : ViewModelBase
    {
        public ProveedoresModel CurrentProveedor { get; set; }



        public ProveedoresModel SelectedProveedor { get; set; }


        public ICommand NewProveedorCommand { get; set; }



        public ICommand DeleteProveedorCommand { get; set; }



        public ObservableCollection<ProveedoresModel> listaProveedores { get; set; }




        public ProveedoresViewModel()
        {
            CurrentProveedor = new ProveedoresModel();
            NewProveedorCommand = new NewProveedorCommand(this);
            DeleteProveedorCommand = new DeleteProveedorCommand(this);
            listaProveedores = new ObservableCollection<ProveedoresModel>();
            SelectedProveedor = new ProveedoresModel();
        }
    }
}

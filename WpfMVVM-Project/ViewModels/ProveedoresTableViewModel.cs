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
    class ProveedoresTableViewModel : ViewModelBase
    {

        public ObservableCollection<ProveedoresModel> ListaProveedores { get; set; }


        public ICommand LoadProveedoresCommand { get; set; }


        public ProveedoresModel CurrentProveedor { get; set; }

        public ProveedoresTableViewModel()
        {
            ListaProveedores = new ObservableCollection<ProveedoresModel>();
            LoadProveedoresCommand = new LoadProveedoresCommand(this);
            CurrentProveedor = new ProveedoresModel();
        }
    }
}

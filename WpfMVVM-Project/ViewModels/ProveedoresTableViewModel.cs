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

        private ObservableCollection<ProveedoresModel> listaProveedores { get; set; }

        public ObservableCollection<ProveedoresModel> ListaProveedores
        {
            get
            {
                return listaProveedores;
            }
            set
            {
                listaProveedores = value;
                OnPropertyChanged(nameof(ListaProveedores));
            }
        }

    

        public ICommand LoadProveedoresCommand { get; set; }

        public ICommand LoadProveedorCommand { get; set; }




        private ProveedoresModel currentProveedor { get; set; }

        public ProveedoresModel CurrentProveedor 
        {
            get 
            {
                return currentProveedor;
            }
            set 
            {
                currentProveedor = value;
                OnPropertyChanged(nameof(CurrentProveedor));
            }
        }



        public ProveedoresTableViewModel()
        {
            ListaProveedores = new ObservableCollection<ProveedoresModel>();
            LoadProveedoresCommand = new LoadProveedoresCommand(this);
            LoadProveedorCommand = new LoadProveedorCommand(this);
            CurrentProveedor = new ProveedoresModel();
        }
    }
}

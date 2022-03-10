using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    class Nuevo_ProductosViewModel : ViewModelBase
    {
        public ICommand UpdateFacturasCommand { set; get; }

        
        
        private ClientesModel selectedClientes;

        public ClientesModel SelectedClientes
        {
            set
            {
                selectedClientes = value;
                OnPropertyChanged(nameof(SelectedClientes));
            }
            get
            {
                return selectedClientes;
            }
        }




        private ProductosModel productos;

        public ProductosModel Productos
        {
            get
            {
                return productos;
            }
            set
            {
                productos = value;
                OnPropertyChanged(nameof(Productos));
            }
        }



        public ObservableCollection<ClientesModel> listaClientes;

        public ObservableCollection<ClientesModel> ListaClientes
        {
            get
            {
                return listaClientes;
            }
            set
            {
                listaClientes = value;
                OnPropertyChanged(nameof(ListaClientes));
            }
        }


        public DateTime fecha1 { set; get; }




        public Nuevo_ProductosViewModel(UpdateViewCommand updateViewCommand)
        {
            UpdateFacturasCommand = new UpdateFacturasCommand(this);

            fecha1 = DateTime.Today;

            Productos = new ProductosModel();
        }



    }
}

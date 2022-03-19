using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands;
using WpfMVVM_Project.Commands.ProductoCommand;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    class Nuevo_ProductosViewModel : ViewModelBase
    {
        public ICommand UpdateFacturasCommand { set; get; }
        public ICommand UpdateClientesCommand { set; get; }
        public ICommand UpdateProductosCommand { set; get; }
        public ICommand LoadProductosCommand { set; get; }

        public ICommand AddFacturaCommand { set; get; }




        private double totalFactura;

        public double TotalFactura
        {
            get
            {
                return totalFactura;
            }
            set
            {
                totalFactura = value;
                OnPropertyChanged(nameof(TotalFactura));
            }
        }
        

     
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



        private ObservableCollection<ProductoFacturaModel> productoFacturaList;

        public ObservableCollection<ProductoFacturaModel> ProductoFacturaList
        {
            get
            {
                return productoFacturaList;
            }
            set
            {
                productoFacturaList = value;
                OnPropertyChanged(nameof(ProductoFacturaList));
            }
        }



        private ProductoFacturaModel currentProductosFactura;

        public ProductoFacturaModel CurrentProductosFactura
        {
            get
            {
                return currentProductosFactura;
            }
            set
            {
                currentProductosFactura = value;
                OnPropertyChanged(nameof(CurrentProductosFactura));
            }
        }



        private ProductoFacturaModel selectedProductosFactura;

        public ProductoFacturaModel SelectedProductosFactura
        { 
            get
            {
                return selectedProductosFactura;
            }
            set
            {
                selectedProductosFactura = value;
                OnPropertyChanged(nameof(SelectedProductosFactura));
            }
        }




        private ObservableCollection<ClientesModel> listaClientes;

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



        private ObservableCollection<ProductosModel> listaProductos;

        public ObservableCollection<ProductosModel> ListaProductos
        {
            get
            {
                return listaProductos;
            }
            set
            {
                listaProductos = value;
                OnPropertyChanged(nameof(ListaProductos));
            }
        }






        public DateTime fecha1 { set; get; }

        public UpdateViewCommand UpdateViewCommand { get; set; }


        public Nuevo_ProductosViewModel(UpdateViewCommand updateViewCommand)
        {
            UpdateFacturasCommand = new UpdateFacturasCommand(this);
            UpdateClientesCommand = new UpdateClientesCommand(this);
            LoadProductosCommand = new LoadProductosCommand(this);
            UpdateProductosCommand = new UpdateProductosCommand(this);
            AddFacturaCommand = new AddFacturaCommand(this);
            ListaClientes = new ObservableCollection<ClientesModel>();
            ListaProductos = new ObservableCollection<ProductosModel>();
            ProductoFacturaList = new ObservableCollection<ProductoFacturaModel>();
            CurrentProductosFactura = new ProductoFacturaModel();
            SelectedProductosFactura = new ProductoFacturaModel();
            this.UpdateViewCommand = UpdateViewCommand;
            fecha1 = DateTime.Today;

            
        }

      
    }
}

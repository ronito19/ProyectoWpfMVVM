using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands.ProductoCommand;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    class ProductosTableViewModel : ViewModelBase
    {

        private ObservableCollection<ProductosModel> listaProductos { get; set; }


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



        public ICommand LoadProductosCommand { get; set; }



        public ICommand LoadProductoCommand { get; set; }



        public ICommand NewProductoCommand { get; set; }



        private ProductosModel currentProducto { get; set; }

        public ProductosModel CurrentProducto 
        {
            get
            {
                return currentProducto;
            }
            set
            {
                currentProducto = value;
                OnPropertyChanged(nameof(CurrentProducto));
            }
        }


        


        public ProductosTableViewModel()
        {
            ListaProductos = new ObservableCollection<ProductosModel>();
            LoadProductoCommand = new LoadProductoCommand(this);
            LoadProductosCommand = new LoadProductosCommand(this);
            CurrentProducto = new ProductosModel();
            //NewProductoCommand = new NewProductoCommand(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductoCommand
{
    class LoadProductosCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductoDBHandler.CargarListaFicticia();
            productosTableViewModel.ListaProductos = ProductoDBHandler.ObtenerListaProductos();
        }




        public ProductosTableViewModel productosTableViewModel;

        public LoadProductosCommand(ProductosTableViewModel productosTableViewModel)
        {
            this.productosTableViewModel = productosTableViewModel;
        }

        
    }
}

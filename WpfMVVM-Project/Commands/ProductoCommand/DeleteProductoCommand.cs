using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductoCommand
{
    class DeleteProductoCommand : ICommand
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
                    int index = ProductoDBHandler.BorrarProducto(productosTableViewModel.CurrentProducto);
                    productosTableViewModel.ListaProductos.RemoveAt(index);
                    productosTableViewModel.CurrentProducto = new Models.ProductosModel();
                }

                if (parameter is ProductosModel)
                {
                    ProductosModel productos = (ProductosModel)parameter;
                    productosTableViewModel.CurrentProducto = (ProductosModel)productos.Clone();
                    productosTableViewModel.SelectedProductos = (ProductosModel)productos.Clone();
                }
            }
        }




        private ProductosTableViewModel productosTableViewModel;

        public DeleteProductoCommand(ProductosTableViewModel productosTableViewModel)
        {
            this.productosTableViewModel = productosTableViewModel;
        }
    }
}

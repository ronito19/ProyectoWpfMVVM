using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductoCommand
{
    class LoadProductoCommand : ICommand
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

                if (accion.Equals("cargarLista"))
                {

                    //productosViewModel.ListaProductos = ProductosDBHandler.GetProductos();

                }
                else if (accion.Equals("cancelar"))
                {
                   // productosTableViewModel.TxWarning2 = "";
                    productosTableViewModel.CurrentProducto = productosTableViewModel.SelectedProductos;

                }


            }
            else
            {
                if (parameter is ProductosModel)
                {

                    ProductosModel productos = (ProductosModel)parameter;
                    productosTableViewModel.CurrentProducto = (ProductosModel)productos.Clone();
                    productosTableViewModel.SelectedProductos = (ProductosModel)productos.Clone();


                }
            }
        }


        public ProductosTableViewModel productosTableViewModel { get; set; }

        public LoadProductoCommand(ProductosTableViewModel productosTableViewModel)
        {
            this.productosTableViewModel = productosTableViewModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductoCommand
{
    class NewProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; ;
        }

        public void Execute(object parameter)
        {
            bool OKinsertar = ProductoDBHandler.NuevoProducto(productosTableViewModel.CurrentProducto);
            if (OKinsertar)
            {
                MessageBox.Show(" Se ha creado el producto ");
            }
            else
            {
                MessageBox.Show(" Error al crear el producto ");
            }
        }



       

        private ProductosTableViewModel productosTableViewModel;


        public NewProductoCommand(ProductosTableViewModel productosTableViewModel)
        {
            this.productosTableViewModel = productosTableViewModel;
        }
    }
}

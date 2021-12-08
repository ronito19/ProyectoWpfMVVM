using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands.ProductoCommand;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    class ProductosViewModel : ViewModelBase
    {
        public ProductosModel CurrentProducto { get; set; }


        public ICommand NewProductoCommand { get; set; }




        public ProductosViewModel()
        {
            CurrentProducto = new ProductosModel();
            NewProductoCommand = new NewProductoCommand(this);
        }
    }
}

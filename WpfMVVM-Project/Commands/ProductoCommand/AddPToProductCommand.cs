using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductoCommand
{
    class AddPToProductCommand : ICommand
    {
        private ProductosTableViewModel productosTableViewModel;


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public ObservableCollection<string> producto { get; set; }

        public void Execute(object parameter)
        {
            bool OKinsertar = ProductoDBHandler.NuevoProducto();
        }



        public AddPToProductCommand(ProductosTableViewModel productosTableViewModel)
        {
            this.productosTableViewModel = productosTableViewModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;
using WpfMVVM_Project.Views;

namespace WpfMVVM_Project.Commands.ProductoCommand
{
    class DeleteProductoCommand : ICommand
    {
       

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter is ProductosTableView)
            {
                ProductosTableView vista = (ProductosTableView)parameter;

                MessageBoxResult result = MessageBox.Show("Deseas borrar este registro?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Stop);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        RequestModel requestModel = new RequestModel();
                        requestModel.route = "/students";
                        requestModel.method = "DELETE";
                        requestModel.data = productosTableViewModel.CurrentProducto._Id;
                        ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                        if (responseModel.resultOK)
                        {
                            productosTableViewModel.LoadProductosCommand.Execute("");
                            vista.productoListView.SelectedIndex = 0;
                        }

                        MessageBox.Show((string)responseModel.data);
                        break;

                    case MessageBoxResult.No:
                        break;

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

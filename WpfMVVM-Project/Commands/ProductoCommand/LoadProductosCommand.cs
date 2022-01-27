using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Models;
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

        public async void Execute(object parameter)
        {
            ProductoDBHandler.CargarListaFicticia();
            productosTableViewModel.ListaProductos = ProductoDBHandler.ObtenerListaProductos();

            RequestModel requestModel = new RequestModel();
            requestModel.route = "/productos";
            requestModel.method = "GET";
            requestModel.data = "all";

            ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

            if (responseModel.resultOK)
            {
                productosTableViewModel.ListaProductos = JsonConvert.DeserializeObject<ObservableCollection<ProductosModel>>((string)responseModel.data);
            }
            else
            {
                MessageBox.Show((string)responseModel.data);
            }
        }




        public ProductosTableViewModel productosTableViewModel;

        public LoadProductosCommand(ProductosTableViewModel productosTableViewModel)
        {
            this.productosTableViewModel = productosTableViewModel;
        }

        
    }
}

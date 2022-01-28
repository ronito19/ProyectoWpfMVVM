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
    public class SaveProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            ProductosTableView vista = (ProductosTableView)parameter;

            Console.WriteLine("FECHA: " + vista.datePickerFecha.Text);
            Console.WriteLine("MARCA: " + productosTableViewModel.CurrentProducto.Marca);
            //Console.WriteLine(studentTableViewModel.CurrentStudent.Fecha);

            if (vista.datePickerFecha.Text.Equals(""))
            {
                vista.txWarning.Text = "Debes poner un fecha";
            }
            else if (productosTableViewModel.CurrentProducto.Marca.Equals("") || productosTableViewModel.CurrentProducto.Marca is null)
            {
                vista.txWarning.Text = "Debes poner una marca";
            }
            else
            {
                vista.txWarning.Text = "";
                MessageBoxResult result = MessageBox.Show("¿Deseas realizar los cambios?", "Modificar", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        RequestModel requestModel = new RequestModel();
                        requestModel.route = "/students";
                        requestModel.method = "PUT";
                        requestModel.data = productosTableViewModel.CurrentProducto;
                        ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                        if (responseModel.resultOK)
                        {

                            vista.E01MostrarDatosProductos1();
                            productosTableViewModel.LoadProductosCommand.Execute("");
                        }

                        MessageBox.Show((string)responseModel.data, "Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;

                    case MessageBoxResult.No:
                        break;

                }
            }
        }


        public ProductosTableViewModel productosTableViewModel { get; set; }
        public SaveProductoCommand(ProductosTableViewModel productosTableViewModel)
        {
            this.productosTableViewModel = productosTableViewModel;
        }


    }
}

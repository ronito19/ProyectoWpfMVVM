using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Services.DataSet;
using WpfMVVM_Project.ViewModels;
using WpfMVVM_Project.Views;

namespace WpfMVVM_Project.Commands
{
    class AddFacturaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Nuevo_Edit_Productos vista = (Nuevo_Edit_Productos)parameter;

            bool validation = false;

            if (nuevo_ProductosViewModel.SelectedClientes is null)
            {
                MessageBox.Show(" Debe introducir un cliente ");
                validation = true;
            }
            else if (nuevo_ProductosViewModel.ProductoFacturaList.Count < 1)
            {
                MessageBox.Show(" Debe introducir algun producto a la factura ");
                validation = true;
            }

            if (validation == false)
            {
                bool okInsertar = await DataSetHandler.insertarFactura(nuevo_ProductosViewModel);
                if (okInsertar)
                {
                    MessageBox.Show(" Factura Creada", " Crear ");
                    nuevo_ProductosViewModel.ProductoFacturaList.Clear();
                    nuevo_ProductosViewModel.TotalFactura = 0;
                    nuevo_ProductosViewModel.SelectedProductosFactura = new Models.ProductoFacturaModel();
                    nuevo_ProductosViewModel.CurrentProductosFactura = new Models.ProductoFacturaModel();
                    nuevo_ProductosViewModel.SelectedClientes = new Models.ClientesModel();
                    nuevo_ProductosViewModel.ListaClientes = new System.Collections.ObjectModel.ObservableCollection<Models.ClientesModel>();

                }
                else
                {
                    MessageBox.Show(" No se pudo crear la factura :(");
                }
            }
        }


        public Nuevo_ProductosViewModel nuevo_ProductosViewModel;

        public AddFacturaCommand(Nuevo_ProductosViewModel nuevo_ProductosViewModel)
        {
            this.nuevo_ProductosViewModel = nuevo_ProductosViewModel;
        }
    }
    
}

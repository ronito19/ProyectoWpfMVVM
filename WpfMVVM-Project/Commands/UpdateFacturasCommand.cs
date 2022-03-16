using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands
{
    class UpdateFacturasCommand : ICommand
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

                if (accion.Equals("nuevo"))
                {
                    ObservableCollection<ProductoFacturaModel> productoFacturaList = nuevo_ProductosViewModel.ProductoFacturaList;

                    bool okGuardar = false;
                    foreach (ProductoFacturaModel p in productoFacturaList)
                    {
                        if (p.Producto._id.Equals(nuevo_ProductosViewModel.CurrentProductosFactura.Producto._id))
                        {
                            p.Cantidad = p.Cantidad + nuevo_ProductosViewModel.CurrentProductosFactura.Cantidad;
                            p.Total = p.Total * nuevo_ProductosViewModel.CurrentProductosFactura.Cantidad;
                            okGuardar = true;
                            nuevo_ProductosViewModel.CurrentProductosFactura = new Models.ProductoFacturaModel();
                            break;
                        }
                    }
                    if (okGuardar == false)
                    {
                        nuevo_ProductosViewModel.ProductoFacturaList.Add(nuevo_ProductosViewModel.CurrentProductosFactura);
                        nuevo_ProductosViewModel.CurrentProductosFactura = new Models.ProductoFacturaModel();
                    }
                }
            }
            else
            {
                if (parameter is ProductoFacturaModel)
                {
                   ProductoFacturaModel producto = (ProductoFacturaModel)parameter;

                    // facturasViewModel.CurrentProductosFactura = (ProductoFacturaModel)producto.Clone();
                    //nuevo_ProductosViewModel.SelectedProductosFactura = (ProductoFacturaModel)producto.Clone();
                }

            }
        }


        public Nuevo_ProductosViewModel nuevo_ProductosViewModel;

        public UpdateFacturasCommand(Nuevo_ProductosViewModel nuevo_ProductosViewModel)
        {
            this.nuevo_ProductosViewModel = nuevo_ProductosViewModel;
        }
    }
}

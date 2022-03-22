using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands
{
    class UpdateFacturasCommand : ICommand
    {

        

        public event EventHandler CanExecuteChanged;

        int index;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is String)
            {
                bool validation = true;
                string accion = parameter.ToString();
                Console.WriteLine(parameter.ToString());

                if (accion.Equals("nuevo"))
                {
                    if (nuevo_ProductosViewModel.CurrentProductosFactura.Producto is null)
                    {
                        MessageBox.Show(" Debe seleccionar un producto ");
                        validation = false;
                    }
                    else if (nuevo_ProductosViewModel.CurrentProductosFactura.Cantidad < 1)
                    {
                        MessageBox.Show(" Debes introducir una cantidad ");
                        validation = false;
                    }

                    if (validation)
                    {

                        ObservableCollection<ProductoFacturaModel> productoFacturaList = nuevo_ProductosViewModel.ProductoFacturaList;

                        bool okGuardar = false;
                        foreach (ProductoFacturaModel p in productoFacturaList)
                        {
                            if (p.Producto._id.Equals(nuevo_ProductosViewModel.CurrentProductosFactura.Producto._id))
                            {
                                p.Cantidad = p.Cantidad + nuevo_ProductosViewModel.CurrentProductosFactura.Cantidad;
                                p.Total = p.Total * nuevo_ProductosViewModel.CurrentProductosFactura.Cantidad;
                                nuevo_ProductosViewModel.TotalFactura = nuevo_ProductosViewModel.TotalFactura + nuevo_ProductosViewModel.CurrentProductosFactura.Total;
                                okGuardar = true;
                                nuevo_ProductosViewModel.CurrentProductosFactura = new Models.ProductoFacturaModel();
                                break;
                            }
                        }
                        if (okGuardar == false)
                        {
                            nuevo_ProductosViewModel.ProductoFacturaList.Add(nuevo_ProductosViewModel.CurrentProductosFactura);
                            nuevo_ProductosViewModel.TotalFactura = nuevo_ProductosViewModel.TotalFactura + nuevo_ProductosViewModel.CurrentProductosFactura.Total;
                            nuevo_ProductosViewModel.CurrentProductosFactura = new Models.ProductoFacturaModel();
                        }
                    }
                }
                else if (accion.Equals("borrar"))
                {

                    MessageBoxResult result = MessageBox.Show("¿Deseas realizar los cambios?", "Borrar", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:


                            ObservableCollection<ProductoFacturaModel> productoFacturaList = nuevo_ProductosViewModel.ProductoFacturaList;

                            foreach (ProductoFacturaModel p in productoFacturaList)
                            {
                                if (p.Producto._id.Equals(nuevo_ProductosViewModel.SelectedProductosFactura.Producto._id))
                                {
                                    index = productoFacturaList.IndexOf(p);
                                    break;
                                }
                            }


                            nuevo_ProductosViewModel.ProductoFacturaList.RemoveAt(index);
                            nuevo_ProductosViewModel.CurrentProductosFactura = new Models.ProductoFacturaModel();

                            if (index != -1)
                            {
                                MessageBox.Show("Proveedor borrado con éxito", "Borrar");
                            }
                            else
                            {
                                MessageBox.Show("Error al borrar el proveedor", "Borrar");

                            }
                            break;

                        case MessageBoxResult.No:
                            break;

                    }
                }
            }
            else
            {
                if (parameter is ProductoFacturaModel)
                {
                   ProductoFacturaModel producto = (ProductoFacturaModel)parameter;
                   nuevo_ProductosViewModel.SelectedProductosFactura = (ProductoFacturaModel)producto.Clone();
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

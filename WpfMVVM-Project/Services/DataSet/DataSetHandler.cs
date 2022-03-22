using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services.DataSet.DataSetTableAdapters;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Services.DataSet
{
    class DataSetHandler
    {


        private static ClientesTableAdapter clientesAdapter = new ClientesTableAdapter();

        private static FacturaTableAdapter facturasAdapter = new FacturaTableAdapter();

        private static DetalleTableAdapter detallesAdapter = new DetalleTableAdapter();

        private static DataTable1TableAdapter adapter = new DataTable1TableAdapter();

        



        public static ObservableCollection<ClientesModel> getClientes()
        {
            DataTable clientesDataTable = clientesAdapter.GetData();
            ObservableCollection<ClientesModel> listaClientes = new ObservableCollection<ClientesModel>();


            foreach (DataRow clientes in clientesDataTable.Rows)
            {
                ClientesModel myCliente = new ClientesModel();
                myCliente.Dni = (string)clientes["Dni"];
                myCliente.Nombre = clientes["Nombre"].ToString();
                myCliente.Direccion = clientes["Direccion"].ToString();
                myCliente.Telefono = clientes["Telefono"].ToString();
                myCliente.Email = clientes["Email"].ToString();
                listaClientes.Add(myCliente);
            }
            return listaClientes;
        }



        public static async Task<bool> insertarFactura(Nuevo_ProductosViewModel f)
        {
            try
            {
                facturasAdapter.Insert(f.SelectedClientes.Dni, f.fecha1, System.Convert.ToDecimal(f.TotalFactura));
                DataRow ultimoRegistro = facturasAdapter.GetData().Last();
                int idUltimaFactura = (int)ultimoRegistro["idFactura"];

                foreach (ProductoFacturaModel p in f.ProductoFacturaList)
                {
                    string codProducto = p.Producto._id;
                    string descripcion = p.Producto.Descripcion;
                    int cantidad = p.Cantidad;
                    decimal precio = (decimal)p.Producto.Precio;

                    detallesAdapter.Insert(idUltimaFactura, codProducto, descripcion, cantidad, precio);
                }

                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }



        public static DataTable GetDataByIdFactura(int Id_factura)
        {
            return adapter.GetDataByIdFactura(Id_factura);
        }



        public static DataTable GetDataByFacturaClientes(string Nombre)
        {
            return adapter.GetDataByFacturaClientes(Nombre);
        }



        public static DataTable GetDataByFacturaFechas(DateTime Fecha)
        {
            return adapter.GetDataByFacturaFechas(Fecha.ToString());
        }



        public static DataTable GetDataByFacturaClienteFecha(string Dni, DateTime Fecha1, DateTime Fecha2)
        {
            return adapter.GetDataByFacturaClienteFecha(Dni, Fecha1.ToString(), Fecha2.ToString());
        }





    }
}

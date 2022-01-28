using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.Services
{
    public class ProductoDBHandler
    {
        private static ObservableCollection<ProductosModel> listaProductos = new ObservableCollection<ProductosModel>();
        
        private static ObservableCollection<string> listaProveedores = new ObservableCollection<string>();

        public static void CargarListaFicticia()
        {
            listaProductos = new ObservableCollection<ProductosModel>();

            var random = new Random();

            for (int i = 001; i < 006; i++)
            {
                ProductosModel pro = new ProductosModel();
                pro._id = i.ToString();
                pro.Proveedor.Add("Proveedor 1");
                pro.Clase = "Gafas Graduadas";
                pro.Marca = "Gucci";
                pro.Tipo = "Lentillas Blandas";
                pro.FechaEntrada = DateTime.Today;
                listaProductos.Add(pro);
            }
        }

        internal static bool NuevoProducto()
        {
            throw new NotImplementedException();
        }

        public static bool NuevoProducto2(ProductosModel productos)
        {
            bool OKinsertar = false;

            try
            {
                listaProductos.Add(productos);
                OKinsertar = true;
            }
            catch (Exception)
            { 
                
            }
            return OKinsertar;
        }



        //public static bool EditProducto(ProductosModel productos)
        //{
        //    bool okGuardar = false;
        //    foreach (ProductosModel pd in listaProductos)
        //    {
        //        if (pd._Id.Equals(productos._Id)) 
        //        {
        //            pd._Id = productos._Id;
        //            pd.Proveedor = productos.Proveedor;
        //            pd.Clase = productos.Clase;
        //            pd.Marca = productos.Marca;
        //            pd.Tipo = productos.Tipo;
        //            okGuardar = true;
        //        }
        //    }
        //    return okGuardar;
        //}





        //public static bool GuardarProducto(ProductosModel productos)
        //{
        //    bool okGuardar = false;

        //    foreach (ProductosModel pd in listaProductos)
        //    {
        //        if (pd._Id == productos._Id)
        //        {
                    
        //            pd.Proveedor = productos.Proveedor;
        //            pd.Clase = productos.Clase;
        //            pd.Marca = productos.Marca;
        //            pd.Tipo = productos.Tipo;
        //            pd.Referencia = productos.Referencia;
        //            pd.Descripcion = productos.Descripcion;
        //            pd.Precio = productos.Precio;
        //            pd.FechaEntrada = productos.FechaEntrada;
        //            pd.Stock = productos.Stock;
        //            okGuardar = true;
        //            break;
        //        }
        //    }
        //    return okGuardar;
        //}






        //public static int BorrarProducto(ProductosModel productos)
        //{
        //    foreach (ProductosModel pd in listaProductos)
        //    {
        //        if (pd._Id.Equals(productos._Id))
        //        {
        //            int index = listaProductos.IndexOf(pd);
        //            return index;
        //        }
        //    }
        //    return -1;
        //}




        public static ObservableCollection<ProductosModel> ObtenerListaProductos()
        {
            return listaProductos;
        }



        public static bool NuevoProveedor(string proveedor)
        {
            bool OKinsertar = false;

            try
            {
                listaProveedores.Add(proveedor);
                OKinsertar = true;
            }
            catch (Exception)
            {

            }
            return OKinsertar;
        }



        public static bool NuevoProveedor(ObservableCollection<string> proveedor)
        {
            bool OKinsertar = false;

            try
            {
                listaProveedores.Add("Proveedor 1");
                OKinsertar = true;
            }
            catch (Exception)
            {

            }
            return OKinsertar;
        }



        public static ObservableCollection<string> ObtenerListaProveedores()
        {
            return listaProveedores;
        }





        public static async Task<bool> NuevoProducto(ProductosModel productos)
        {
            bool okinsertar = false;

            var handler = new WinHttpHandler();
            var client = new HttpClient(handler);

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/productos");

            var data = JsonConvert.SerializeObject(productos);

            request.Headers.Add("Accept", "application/json");
            request.Content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseJSON = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseJSON);
                okinsertar = true;
            }

            return okinsertar;
        }



    }
}

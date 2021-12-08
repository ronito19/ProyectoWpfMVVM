using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.Services
{
    public class ProductoDBHandler
    {
        private static ObservableCollection<ProductosModel> listaProductos = new ObservableCollection<ProductosModel>();



        public static void CargarListaFicticia()
        {
            listaProductos = new ObservableCollection<ProductosModel>();

            for (int i = 100; i < 110; i++)
            {
                ProductosModel pro = new ProductosModel();
                pro._Id = i.ToString();
                listaProductos.Add(pro);
            }
        }



        public static bool NuevoProducto(ProductosModel productos)
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


        public static ObservableCollection<ProductosModel> ObtenerListaProductos()
        {
            return listaProductos;
        }
    }
}

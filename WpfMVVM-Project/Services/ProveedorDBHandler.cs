using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.Services
{
    public class ProveedorDBHandler
    {
        private static ObservableCollection<ProveedoresModel> listaProveedores = new ObservableCollection<ProveedoresModel>();

        public static void CargarListaSupuesta()
        {
            for (int i = 0; i < 6; i++)
            {
                ProveedoresModel p = new ProveedoresModel();
                p._Id = i.ToString();
                p.Nombre = " Proveedor " + i.ToString();
                p.Provincia = " Toledo ";
                p.Telefono = 123456789;
                listaProveedores.Add(p);
            }
        }



        public static bool NuevoProveedor(ProveedoresModel proveedor)
        {
            bool OKinsertar = false;

            try
            {
                listaProveedores.Add(proveedor);
                OKinsertar = true;
            }
            catch (Exception) { }

            return OKinsertar;
        }


        public static ObservableCollection<ProveedoresModel> ObtenerListaProveedores()
        {
            return listaProveedores;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.Services
{
    class ProveedorDBHandler
    {
        private static ObservableCollection<ProveedoresModel> listaProveedores = new ObservableCollection<ProveedoresModel>();

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

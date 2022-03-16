using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services.DataSet.DataSetTableAdapters;

namespace WpfMVVM_Project.Services.DataSet
{
    class DataSetHandler
    {


        private static ClientesTableAdapter clientesAdapter = new ClientesTableAdapter();


        public static ObservableCollection<ClientesModel> getClientes()
        {
            DataTable clientesDataTable = clientesAdapter.GetData();
            ObservableCollection<ClientesModel> listaClientes = new ObservableCollection<ClientesModel>();


            foreach (DataRow clientes in clientesDataTable.Rows)
            {
                ClientesModel myCliente = new ClientesModel();
                myCliente.Dni = (string)clientes["Dni"];
                myCliente.Nombre = clientes["Nombre"].ToString();
                listaClientes.Add(myCliente);
            }
            return listaClientes;
        }

    }
}

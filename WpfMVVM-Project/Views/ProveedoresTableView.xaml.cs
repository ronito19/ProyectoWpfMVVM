using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services;

namespace WpfMVVM_Project.Views
{
    /// <summary>
    /// Lógica de interacción para ProveedoresTableView.xaml
    /// </summary>
    public partial class ProveedoresTableView : UserControl, INotifyPropertyChanged
    {
        public ProveedoresTableView()
        {
            InitializeComponent();
            E00Estadoinicial();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        private bool editarActivado;

        public bool EditarActivado 
        {
            get 
            {
                return editarActivado;
            }
            set
            {
                editarActivado = value;
                OnPropertyChanged(nameof(EditarActivado));
            }
        }




        public void E00Estadoinicial()
        {
            stackDatosPro.Visibility = Visibility.Collapsed;

            EditarActivado = false;
        }


        public void E01MostrarDatos()
        {
            stackDatosPro.Visibility = Visibility.Visible;

            btnGuardarDatos.Visibility = Visibility.Collapsed;
            btnBorrarDatos.Visibility = Visibility.Collapsed;
            btnEditarDatos.Visibility = Visibility.Visible;

            proveedorListView.IsEnabled = true;

            EditarActivado = false;
        }



        public void E02ModificarDatos()
        {
            btnGuardarDatos.Visibility = Visibility.Visible;
            btnBorrarDatos.Visibility = Visibility.Visible;
            btnEditarDatos.Visibility = Visibility.Collapsed;

            proveedorListView.IsEnabled = false;

            EditarActivado = true;
        }



        private void proveedorListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            E01MostrarDatos();
        }

        private void btnEditarDatos_Click(object sender, RoutedEventArgs e)
        {
            E02ModificarDatos();
        }

        private void btnBorrarDatos_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult mensaje = MessageBox.Show(" Deseas borrar al proveedor? ", " BORRAR PROVEEDOR ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            switch (mensaje)
                { 
                case MessageBoxResult.Yes:
                    ProveedoresModel listaProveedores = (ProveedoresModel)proveedorListView.SelectedItem;
                    ProveedorDBHandler.BorrarProveedor(listaProveedores);

                    MessageBox.Show(" Proveedor BORRADO ");
                    break;

                case MessageBoxResult.No:
                    break;
                }
            E01MostrarDatos();
            proveedorListView.IsEnabled = true;
        }

        private void btnGuardarDatos_Click(object sender, RoutedEventArgs e)
        {
            E01MostrarDatos();
            MessageBoxResult mensaje = MessageBox.Show(" Deseas guardar los cambios al modificarlo? ", " MODIFICAR PROVEEDOR ", MessageBoxButton.YesNo, MessageBoxImage.Question);

            proveedorListView.IsEnabled = true;
        }
    }
}

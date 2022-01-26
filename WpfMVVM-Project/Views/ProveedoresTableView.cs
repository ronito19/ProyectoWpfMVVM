using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Windows;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services;
using System.Windows.Forms;
using UserControl = System.Windows.Forms.UserControl;
using System.Windows.Controls;
using MessageBox = System.Windows.MessageBox;

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
            btnCrearDatos.Visibility = Visibility.Visible;
            btnAtras.Visibility = Visibility.Collapsed;

            proveedorListView.IsEnabled = true;

            EditarActivado = false;
        }



        public void E02ModificarDatos()
        {
            btnGuardarDatos.Visibility = Visibility.Visible;
            btnBorrarDatos.Visibility = Visibility.Visible;
            btnEditarDatos.Visibility = Visibility.Collapsed;
            btnCrearDatos.Visibility = Visibility.Collapsed;
            btnAtras.Visibility = Visibility.Visible;

            proveedorListView.IsEnabled = false;

            EditarActivado = true;
        }




        public void E03CrearDatos()
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




        



        private void btnCrearDatos_Click(object sender, RoutedEventArgs e)
        {
            E02ModificarDatos();
            proveedorListView.SelectedIndex = proveedorListView.Items.Count;

            
        }

       
            

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            E01MostrarDatos();
            
        }
    }
}

using System;
using System.Collections.Generic;
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

namespace WpfMVVM_Project.Views
{
    /// <summary>
    /// Lógica de interacción para ProductosTableView.xaml
    /// </summary>
    public partial class ProductosTableView : UserControl
    {
        public ProductosTableView()
        {
            InitializeComponent();
        }

        private void proveedoresListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       

        private void proveedoresListView_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }
    }
}

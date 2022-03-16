using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Models
{
    class ProductoFacturaModel : INotifyPropertyChanged , ICloneable
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {

            return MemberwiseClone();
        }

        private ProductosModel producto;

        public ProductosModel Producto
        {
            get
            {
                return producto;
            }
            set
            {
                producto = value;
                OnPropertyChanged(nameof(Producto));
            }
        }




        private int cantidad;

        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
                OnPropertyChanged(nameof(Cantidad));

            }

        }


        private double total;
        public double Total
        {
            get
            {
                return total = producto.Precio * cantidad;
            }
            set
            {
                total = value;
                OnPropertyChanged(nameof(Total));

            }

        }




        
      
    }
}

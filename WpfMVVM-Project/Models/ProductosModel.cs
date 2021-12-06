using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Project.Models
{
    public class ProductosModel : INotifypropertyChanged
    {



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        private string _id;

        public string _Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(_Id));
                
            }

        }



        private string proveedores;

        public string Proveedores
        {
            get
            {
                return proveedores;
            }
            set
            {
                proveedores = value;
                OnPropertyChanged(nameof(Proveedores));
            }
        }



        private string Clase;

        public string clase
        {
            get
            {
                return clase;
            }
            set 
            {
                clase = value;
                OnPropertyChanged(nameof(Clase));
            }
        }



        private string Marca;

        public string marca
        {
            get
            {
                return marca;
            }
            set
            {
                marca = value;
                OnPropertyChanged(nameof(Marca));
            }
        }



        private string Tipo;

        public string tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
                OnPropertyChanged(nameof(Tipo));
            }
        }



        private string Referencia;

        public string referencia
        {
            get
            {
                return referencia;
            }
            set
            {
                referencia = value;
                OnPropertyChanged(nameof(Referencia));
            }
        }



        private string Descripcion;

        public string descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
                OnPropertyChanged(nameof(Descripcion));
            }
        }



        private double Precio;

        public double precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
                OnPropertyChanged(nameof(Precio));
            }
        }



        private DateTime FechaEntrada;

        public DateTime fechaEntrada
        {
            get
            {
                return fechaEntrada;
            }
            set
            {
                fechaEntrada = value;
                OnPropertyChanged(nameof(FechaEntrada));
            }
        }



        private int Stock;

        public int stock
        {
            get
            {
                return stock;
            }
            set
            {
                stock = value;
                OnPropertyChanged(nameof(Stock));
            }
        }     
    }
}

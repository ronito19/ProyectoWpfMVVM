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



        private string proveedor;

        public string Proveedor
        {
            get
            {
                return proveedor;
            }
            set
            {
                proveedor = value;
                OnPropertyChanged(nameof(Proveedor));
            }
        }



        private string clase;

        public string Clase
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

        internal ProductosModel Clone()
        {
            throw new NotImplementedException();
        }

        private string marca;

        public string Marca
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



        private string tipo;

        public string Tipo
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



        private string referencia;

        public string Referencia
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



        private string descripcion;

        public string Descripcion
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



        private double precio;

        public double Precio
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



        private DateTime fechaEntrada;

        public DateTime FechaEntrada
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



        private int stock;

        public int Stock
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Project.Models
{
    public class ProductosModel 
    {
        public ProductosModel()
        {
            Proveedor = new ObservableCollection<string>();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        private string id;

        public string _id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(nameof(_id));
                
            }

        }



        private ObservableCollection<string> proveedor;

        public ObservableCollection<string> Proveedor
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

        public object Clone()
        {

            return MemberwiseClone();

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

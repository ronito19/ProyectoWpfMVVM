using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Models
{
    public class ProveedoresModel : INotifyPropertyChanged
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


        private string nombre;

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set 
            {
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }


        private string provincia;

        public string Provincia
        {
            get
            {
                return provincia;
            }
            set
            {
                provincia = value;
                OnPropertyChanged(nameof(Provincia));
            }
        }

        internal ProveedoresModel Clone()
        {
            throw new NotImplementedException();
        }
       

        

        public ProveedoresModel()
        {
        }


        private int telefono;
        public int Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
                OnPropertyChanged(nameof(Telefono));
                
            }
        }


        public ProveedoresModel currentProveedor { get; set; }

        public static object listaProveedores;


        


        
    }
}

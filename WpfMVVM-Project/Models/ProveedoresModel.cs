using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        
    }
}

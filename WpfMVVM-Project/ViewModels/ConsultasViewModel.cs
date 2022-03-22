using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    class ConsultasViewModel : ViewModelBase
    {
        public UpdateViewCommand updateViewCommand { set; get; }

        public ICommand ConsultarCommand { set; get; }


        public int Id_factura { set; get; }

        public string Nombre { set; get; }

        public DateTime Fecha { set; get; }


        public string DNI { set; get; }

        public DateTime Fecha1 { set; get; }

        public DateTime Fecha2 { set; get; }




        public ConsultasViewModel(UpdateViewCommand updateViewCommand)
        {
            this.updateViewCommand = updateViewCommand;
            ConsultarCommand = new ConsultarCommand(this);
            Fecha1 = DateTime.Today;
            Fecha2 = DateTime.Today;


        }
    }
}

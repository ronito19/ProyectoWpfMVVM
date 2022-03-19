﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands
{
    class ConsultarCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is string)
            {
                string consulta = (string)parameter;

                if (consulta.Equals("Id_factura"))
                {
                    consultasViewModel.updateViewCommand.Execute("formulario");
                }
            }
        }


        public ConsultasViewModel consultasViewModel { set; get; }

        public ConsultarCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands;

namespace WpfMVVM_Project.ViewModels
{
    class ConsultasViewModel : ViewModelBase
    {
        public UpdateViewCommand updateViewCommand { set; get; }

        public ICommand ConsultarCommand { set; get; }
        public ConsultasViewModel(UpdateViewCommand updateViewCommand)
        {
            this.updateViewCommand = updateViewCommand;
            this.ConsultarCommand = new ConsultarCommand(this);
        }
    }
}

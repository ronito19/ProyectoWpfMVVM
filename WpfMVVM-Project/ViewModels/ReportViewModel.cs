using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Project.ViewModels
{
    class ReportViewModel : ViewModelBase
    {
        public string PDFData { set; get; }

        ReportViewer myReport { set; get; }

        ReportDataSource rds { set; get; }

        public ReportViewModel()
        {
            myReport = new ReportViewer();
            rds = new ReportDataSource();
        }


        public void GenerarInforme(int Id_factura)
        {

        }
    }
}

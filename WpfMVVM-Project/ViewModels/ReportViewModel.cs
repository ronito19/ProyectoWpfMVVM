using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Services.DataSet;

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
            rds.Name = "InformeFactura";
            rds.Value = DataSetHandler.GetDataByIdFactura(Id_factura);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Reporting/InformeFactura.rdlc";
            byte[] PDFBytes = myReport.LocalReport.Render(format:"PDF", deviceInfo:"");
            PDFData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }




        public void GenerarInforme(string Nombre)
        {
            rds.Name = "Informe";
            rds.Value = DataSetHandler.GetDataByFacturaClientes(Nombre);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Reporting/InformeClientes.rdlc";
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            PDFData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }




        public void GenerarInforme(DateTime Fecha)
        {
            rds.Name = "InformeFechas";
            rds.Value = DataSetHandler.GetDataByFacturaFechas(Fecha);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Reporting/InformeFechas.rdlc";
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            PDFData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Project.Models
{
    public class ResponseModel
    {
        public object data { get; set; }

        public bool resultOK { set; get; }

        public ResponseModel()
        {
            data = "Error consulta";

            resultOK = false;
        }
    }
}

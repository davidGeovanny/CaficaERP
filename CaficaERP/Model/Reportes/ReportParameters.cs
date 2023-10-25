using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Reportes
{
    public class reportParameters
    {
        public List<reportParameter> reportParameter { get; set; }
        public reportParameters()
        {
            reportParameter = new List<reportParameter>();
        }
    }
}

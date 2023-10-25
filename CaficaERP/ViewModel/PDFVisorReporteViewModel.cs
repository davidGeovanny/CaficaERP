using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel
{
    public class PDFVisorReporteViewModel :ViewModelBase
    {
        private string _Reporte;

        public PDFVisorReporteViewModel(string urlreporte)
            {
            Reporte = urlreporte;

            }

        public string Reporte
        {
            get
            {
                return _Reporte;
            }

            set
            {
                SetProperty(ref _Reporte, value, () => Reporte);
            }
        }
    }
}

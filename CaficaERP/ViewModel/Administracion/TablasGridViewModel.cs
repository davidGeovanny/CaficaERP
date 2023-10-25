using CaficaERP.Model.Administracion;
using CaficaERP.Views.Administracion;
using DevExpress.Xpf.WindowsUI;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Administracion
{
    class TablasGridViewModel : GridViewModel<Tablas, TablasFormView,TablasFormViewModel>
    {
       

        public TablasGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },

            };
        }

       
    }
}

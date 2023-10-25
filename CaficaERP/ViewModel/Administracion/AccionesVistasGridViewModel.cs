using CaficaERP.Model.Administracion;
using CaficaERP.Views.Administracion;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Administracion
{
 public   class AccionesVistasGridViewModel : GridViewModel<AccionesVistas, AccionesVistasFormView, AccionesVistasFormViewModel>
    {
      

        public AccionesVistasGridViewModel(string WebService,string Reporte,string ReporteForm) : base(WebService,Reporte,ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Vista", FieldName = "Vistas.Nombre", Settings = SettingsType.Default },
                new Column() { Header="Tipo", FieldName = "Tipo", Settings = SettingsType.Default },
               
            };
        }

    }
}

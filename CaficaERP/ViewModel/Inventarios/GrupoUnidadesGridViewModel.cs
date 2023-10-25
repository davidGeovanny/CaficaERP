using CaficaERP.Model.Inventarios;
using CaficaERP.Views.Inventarios;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Inventarios
{
    public class GrupoUnidadesGridViewModel : GridViewModel<GruposUnidades, GrupoUnidadesFormView, GrupoUnidadesFormViewModel>
    {
        public GrupoUnidadesGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
            };
        }
    }
}

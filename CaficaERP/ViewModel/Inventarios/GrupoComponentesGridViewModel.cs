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
    public class GrupoComponentesGridViewModel : GridViewModel<GruposComponentes,GrupoComponentesFormView,GrupoComponentesFormViewModel>
    {
        public GrupoComponentesGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Clave", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Tipos Componentes", FieldName = "TiposComponentes.Nombre", Settings = SettingsType.Default },
            };
        }
    }
}

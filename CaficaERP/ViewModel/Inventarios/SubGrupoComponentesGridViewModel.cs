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
    public class SubGrupoComponentesGridViewModel : GridViewModel<SubgruposComponentes, SubGrupoComponentesFormView,SubGrupoComponentesFormViewModel>
    {

        public SubGrupoComponentesGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Grupo de componentes", FieldName = "GruposComponentes.Nombre", Settings = SettingsType.Default }
            };
        }
    }
}

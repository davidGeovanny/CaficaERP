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
    public class ConceptosGridViewModel : GridViewModel<ConceptosES, ConceptosFormView, ConceptosFormViewModel>
    {
        public ConceptosGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Clave", FieldName = "Clave", Settings = SettingsType.Default },
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Naturaleza", FieldName = "Naturaleza", Settings = SettingsType.Default },
                new Column() { Header="Tipo de documento", FieldName = "TiposDocumentos.Nombre", Settings = SettingsType.Default }
            };
        }
    }
}

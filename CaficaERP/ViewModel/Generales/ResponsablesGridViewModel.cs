using CaficaERP.Model.Inventarios;
using CaficaERP.Views.Generales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Generales
{
    public class ResponsablesGridViewModel : GridViewModel<Responsables, ResponsablesFormView, ResponsablesFormViewModel>
    {
        public ResponsablesGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Paterno", FieldName = "Paterno", Settings = SettingsType.Default },
                new Column() { Header="Materno", FieldName = "Materno", Settings = SettingsType.Default },
            };
        }
    }
}

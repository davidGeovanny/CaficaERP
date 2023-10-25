using CaficaERP.Model.Generales;
using CaficaERP.Views.Generales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Generales
{
  public  class MonedasGridViewModel : GridViewModel<Monedas, MonedasFormView, MonedasFormViewModel>
    {
        public MonedasGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Importe letra", FieldName = "TextoImporteLetra", Settings = SettingsType.Default },
                new Column() { Header="Simbolo", FieldName = "Simbolo", Settings = SettingsType.Default }

            };
        }
    }
}

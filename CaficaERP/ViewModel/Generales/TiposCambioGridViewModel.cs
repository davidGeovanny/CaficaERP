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
   public class TiposCambioGridViewModel : GridViewModel<TiposCambio, TiposCambioFormView, TiposCambioFormViewModel>
    {
        public TiposCambioGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Moneda", FieldName = "Monedas.Nombre", Settings = SettingsType.Default },
                new Column() { Header="Fecha", FieldName = "Fecha", Settings = SettingsType.Default },
                new Column() { Header="Tipo de cambio", FieldName = "TipoCambio", Settings = SettingsType.Default }

            };
        }
    }
}

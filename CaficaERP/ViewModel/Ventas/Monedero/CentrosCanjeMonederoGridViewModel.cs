using CaficaERP.Model.Ventas.Monedero;
using CaficaERP.ViewModel.Ventas.Monedero;
using CaficaERP.Views.Ventas.Monedero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Ventas.Monedero
{
    public class CentrosCanjeMonederoGridViewModel : GridViewModel<CentrosCanjeMonedero, CentrosCanjeMonederoFormView, CentrosCanjeMonederoFormViewModel>
    {
        public CentrosCanjeMonederoGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Almacen", FieldName = "Almacenes.Nombre", Settings = SettingsType.Default },

            };
        }
    }
}

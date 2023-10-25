using CaficaERP.Model.Ventas.Monedero;
using CaficaERP.Views.Ventas.Monedero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Ventas.Monedero
{
 public   class SociosMonederoGridViewModel : GridViewModel<SociosMonedero, SociosMonederoFormView, SociosMonederoFormViewModel>
    {
        public SociosMonederoGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Servidor", FieldName = "Servidor", Settings = SettingsType.Default },
                new Column() { Header="Monto de compra", FieldName = "FactorMontoCompra", Settings = SettingsType.Default },
                new Column() { Header="Puntos de la compra", FieldName = "FactorPuntos", Settings = SettingsType.Default },
                new Column() { Header="Antiguedad del ticket", FieldName = "AntiguedadTicket", Settings = SettingsType.Default }
            };
        }
    }
}

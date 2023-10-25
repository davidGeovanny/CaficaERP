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
   public class EntradasInventariosGridViewModel : GridViewModel<InventariosES, ESInventariosFormView, EntradasInventariosFormViewModel>
    {
        public EntradasInventariosGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            FiltradoFechas = true;

            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Fecha", FieldName = "Fecha", Settings = SettingsType.Default },
                new Column() { Header = "Concepto", FieldName = "ConceptosES.Nombre", Settings = SettingsType.Default },
                new Column() { Header = "Folio", FieldName = "Folio", Settings = SettingsType.Default },
                new Column() { Header = "Almacen", FieldName = "Almacenes.Nombre", Settings = SettingsType.Default },
                new Column() { Header = "Descripcion", FieldName = "Descripcion", Settings = SettingsType.Default },
                new Column() { Header = "CostoTotal", FieldName = "CostoTotal", Settings = SettingsType.Default },
                new Column() { Header = "Cancelado", FieldName = "Cancelado", Settings = SettingsType.Default }
            };

            ColumnaSumar = "CostoTotal";
        }
        public override void Refrescar()
        {
            try
            {
                
                ServicioWS ws = new ServicioWS(StrWebService, "getallxnaturaleza", "Entrada", typeof(System.Collections.ObjectModel.ObservableCollection<InventariosES>), "Naturaleza");
                LstItems = (System.Collections.ObjectModel.ObservableCollection<InventariosES>)ws.Peticion();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void Nuevo()
        {
            try
            {
                //0 = Entrada y 1 =Salida
                base.NuevoForm(0);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

    }
}

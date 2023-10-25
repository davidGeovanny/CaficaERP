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
    public class MercaderiaGridViewModel: GridViewModel<Componentes, MercaderiaFormView, ComponentesFormViewModel>
    {
        public MercaderiaGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Clave", FieldName = "Clave", Settings = SettingsType.Default },
                new Column() { Header="Nombre Corto", FieldName = "NombreCorto", Settings = SettingsType.Default },
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Activo", FieldName = "Activo", Settings = SettingsType.Default },
                new Column() { Header="Unidad Inventario", FieldName = "Unidades.Nombre", Settings = SettingsType.Default },
                new Column() { Header="Unidad Compra", FieldName = "Unidades2.Nombre", Settings = SettingsType.Default },
                 new Column() { Header="Unidad Venta", FieldName = "Unidades1.Nombre", Settings = SettingsType.Default },
                new Column() { Header="Grupo de Componentes", FieldName = "GruposComponentes.Nombre", Settings = SettingsType.Default },
                new Column() { Header="Subgrupo de Componentes", FieldName = "SubgruposComponentes.Nombre", Settings = SettingsType.Default }

            };
        }

        public override void Refrescar()
        {
            try
            {
                ServicioWS ws = new ServicioWS(StrWebService, "getAllOfType", 2, typeof(System.Collections.ObjectModel.ObservableCollection<Componentes>), "type");
                LstItems = (System.Collections.ObjectModel.ObservableCollection<Componentes>)ws.Peticion();
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
                base.NuevoForm(2);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
    }
}

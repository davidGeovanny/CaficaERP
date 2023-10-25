using CaficaERP.Model.Inventarios;
using CaficaERP.Model.Ventas.Monedero;
using CaficaERP.Views.Ventas.Monedero;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Ventas.Monedero
{
    public class CanjeGridViewModel : GridViewModel<MovimientosMonedero, CanjeFormView, CanjeFormViewModel>
    {
        public CanjeGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            FiltradoFechas = true;
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Fecha Movimiento", FieldName = "FechaHora", Settings = SettingsType.Default },
                new Column() { Header = "Cliente", FieldName = "UsuariosMonedero.Email", Settings = SettingsType.Default },
                new Column() { Header = "Centro Canje", FieldName = "CentrosCanjeMonedero.Nombre", Settings = SettingsType.Default },
                new Column() { Header = "Total Canje", FieldName = "Canje", Settings = SettingsType.Default }
            };
        }
        public override void Refrescar()
        {
            try
            {
                ServicioWS ws = new ServicioWS("ServiciosERP/Ventas/WSMovimientosMonedero.svc", "getCanjexSocioMonedero", null, typeof(System.Collections.ObjectModel.ObservableCollection<MovimientosMonedero>), null);
                LstItems = (System.Collections.ObjectModel.ObservableCollection<MovimientosMonedero>)ws.Peticion();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void Nuevo()
        {
            CanjeFormView FrmITem = new CanjeFormView();
            ViewModelSource.Create(() => new CanjeFormViewModel(FrmITem)
            {
                FormTitulo = "Canjes",
                TabGridActivo = (TabViewModel)this,
                StrWebService = StrWebService,
                RutaReporteForm = StrReporteForm
            });
        }
        public override void Abrir()
        {
            if (ItemSeleccionado != null)
            {
                if (ItemSeleccionado.Id != 0)
                {
                    CanjeFormView FrmITem = new CanjeFormView();
                    ViewModelSource.Create(() => new CanjeFormViewModel(FrmITem, ItemSeleccionado, StrWebService)
                    {
                        FormTitulo = "Canjes",
                        TabGridActivo = (TabViewModel)this,
                        RutaReporteForm = StrReporteForm
                        //StrWebService = StrWebService
                    });
                }
            }
        }
    }
}

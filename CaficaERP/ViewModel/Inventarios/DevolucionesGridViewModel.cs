using CaficaERP.Model.Inventarios;
using CaficaERP.Views.Inventarios;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Inventarios
{
    public class DevolucionesGridViewModel : GridViewModel<Resguardos, DevolucionesFormView, DevolucionesFormViewModel>
    {
        public DevolucionesGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            FiltradoFechas = true;
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Folio", FieldName = "Id", Settings = SettingsType.Default },
                new Column() { Header = "Fecha", FieldName = "Fecha", Settings = SettingsType.Default },
                new Column() { Header = "Responsable", FieldName = "Responsables.Nombre", Settings = SettingsType.Default },
                new Column() { Header = "Descripcion", FieldName = "Descripcion", Settings = SettingsType.Default },
                new Column() { Header = "Cancelado", FieldName = "Cancelado", Settings = SettingsType.Default }
            };
        }
        public override void Nuevo()
        {
            DevolucionesFormView FrmITem = new DevolucionesFormView();
            ViewModelSource.Create(() => new DevolucionesFormViewModel(FrmITem)
            {
                FormTitulo = "Devoluciones",
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
                    DevolucionesFormView FrmITem = new DevolucionesFormView();
                    ViewModelSource.Create(() => new DevolucionesFormViewModel(FrmITem, ItemSeleccionado, StrWebService)
                    {
                        FormTitulo = "Devoluciones",
                        TabGridActivo = (TabViewModel)this,
                        RutaReporteForm = StrReporteForm
                        //StrWebService = StrWebService
                    });
                }
            }
        }
    }
}

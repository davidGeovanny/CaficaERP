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
    public class ResguardosGridViewModel : GridViewModel<Resguardos, ResguardosFormView, ResguardosFormViewModel>
    {
        public ResguardosGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            FiltradoFechas = true;
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Folio", FieldName = "Id", Settings = SettingsType.Default },
                new Column() { Header = "Fecha", FieldName = "Fecha", Settings = SettingsType.Default },
                new Column() { Header = "Responsable", FieldName = "Responsables.NombreCompleto", Settings = SettingsType.Default },
                new Column() { Header = "Descripcion", FieldName = "Descripcion", Settings = SettingsType.Default },
                new Column() { Header = "Cancelado", FieldName = "Cancelado", Settings = SettingsType.Default }
            };
        }
        public override void Nuevo()
        {
            ResguardosFormView FrmITem = new ResguardosFormView();
            ViewModelSource.Create(() => new ResguardosFormViewModel(FrmITem)
            {
                FormTitulo = "Resguardos",
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
                    ResguardosFormView FrmITem = new ResguardosFormView();
                    ViewModelSource.Create(() => new ResguardosFormViewModel(FrmITem, ItemSeleccionado, StrWebService)
                    {
                        FormTitulo = "Resguardos",
                        TabGridActivo = (TabViewModel)this,
                        RutaReporteForm = StrReporteForm
                        //StrWebService = StrWebService
                    });
                }
            }
        }
    }
}

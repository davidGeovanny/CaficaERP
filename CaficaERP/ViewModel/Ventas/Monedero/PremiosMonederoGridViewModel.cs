using CaficaERP.Model.Ventas.Monedero;
using CaficaERP.Views.Ventas.Monedero;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Ventas.Monedero
{
    class PremiosMonederoGridViewModel : GridViewModel<PremiosMonedero, PremiosMonederoFormView, PremiosMonederoFormViewModel>
    {
        public PremiosMonederoGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Fecha Inicia", FieldName = "FechaInicia", Settings = SettingsType.Default },
                new Column() { Header="Fecha Termina", FieldName = "FechaTermina", Settings = SettingsType.Default },
                new Column() { Header="Puntos Canje", FieldName = "PuntosCanje", Settings = SettingsType.Default }    
            };
        }

        public override void Nuevo()
        {
            PremiosMonederoFormView FrmITem = new PremiosMonederoFormView();
            ViewModelSource.Create(() => new PremiosMonederoFormViewModel(FrmITem)
            {
                FormTitulo = "Premios Monedero",
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
                    PremiosMonederoFormView FrmITem = new PremiosMonederoFormView();
                    ViewModelSource.Create(() => new PremiosMonederoFormViewModel(FrmITem, ItemSeleccionado, StrWebService)
                    {
                        FormTitulo = "Premios Monedero",
                        TabGridActivo = (TabViewModel)this,
                        RutaReporteForm = StrReporteForm
                        //StrWebService = StrWebService
                    });
                }
            }
        }
    }
}

using CaficaERP.Model.Generales;
using CaficaERP.Views.Generales;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Generales
{
  public  class CondicionesdePagoGridViewModel : GridViewModel<CondicionesPago, CondicionesdePagoFormView, CondicionesdePagoFormViewModel>
    {
        public CondicionesdePagoGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            FiltradoFechas = true;
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
            };
        }

        public override void Nuevo()
        {
            CondicionesdePagoFormView FrmITem = new CondicionesdePagoFormView();
            ViewModelSource.Create(() => new CondicionesdePagoFormViewModel(FrmITem)
            {
                FormTitulo = "Condiciones de pago",
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
                    CondicionesdePagoFormView FrmITem = new CondicionesdePagoFormView();
                    ViewModelSource.Create(() => new CondicionesdePagoFormViewModel(FrmITem, ItemSeleccionado, StrWebService)
                    {
                        FormTitulo = "Condiciones de pago",
                        TabGridActivo = (TabViewModel)this,
                        RutaReporteForm = StrReporteForm
                        //StrWebService = StrWebService
                    });
                }
            }
        }
    }
}

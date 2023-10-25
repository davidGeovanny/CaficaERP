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
    public class ImpuestosGridViewModel : GridViewModel<Impuestos, ImpuestosFormView, ImpuestosFormViewModel>
    {

        public ImpuestosGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            FiltradoFechas = true;
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header = "Naturaleza", FieldName = "Naturaleza", Settings = SettingsType.Default },
                new Column() { Header = "Tipo", FieldName = "Tipo", Settings = SettingsType.Default },
                new Column() { Header = "Tipo Calculo", FieldName = "TipoCalculo", Settings = SettingsType.Default },
                new Column() { Header = "Predeterminado", FieldName = "Predeterminado", Settings = SettingsType.Default }
            };
        }

        public override void Nuevo()
        {
            ImpuestosFormView FrmITem = new ImpuestosFormView();
            ViewModelSource.Create(() => new ImpuestosFormViewModel(FrmITem)
            {
                FormTitulo = "Impuestos",
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
                    ImpuestosFormView FrmITem = new ImpuestosFormView();
                    ViewModelSource.Create(() => new ImpuestosFormViewModel(FrmITem, ItemSeleccionado, StrWebService)
                    {
                        FormTitulo = "Impuestos",
                        TabGridActivo = (TabViewModel)this,
                        RutaReporteForm = StrReporteForm
                        //StrWebService = StrWebService
                    });
                }
            }
        }
    }
}

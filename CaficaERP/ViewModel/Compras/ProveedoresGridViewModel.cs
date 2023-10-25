using CaficaERP.Model.Compras;
using CaficaERP.Views.Compras;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Compras
{
    public class ProveedoresGridViewModel : GridViewModel<Proveedores, ProveedoresFormView, ProveedoresFormViewModel>
    {
        public ProveedoresGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            FiltradoFechas = true;
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header = "RFC", FieldName = "RFC", Settings = SettingsType.Default }
            };
        }

        public override void Nuevo()
        {
            ProveedoresFormView FrmITem = new ProveedoresFormView();
            ViewModelSource.Create(() => new ProveedoresFormViewModel(FrmITem)
            {
                FormTitulo = "Proveedores",
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
                    ProveedoresFormView FrmITem = new ProveedoresFormView();
                    ViewModelSource.Create(() => new ProveedoresFormViewModel(FrmITem, ItemSeleccionado, StrWebService)
                    {
                        FormTitulo = "Proveedores",
                        TabGridActivo = (TabViewModel)this,
                        RutaReporteForm = StrReporteForm
                        //StrWebService = StrWebService
                    });
                }
            }
        }
    }
}

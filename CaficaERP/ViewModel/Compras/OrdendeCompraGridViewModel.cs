using CaficaERP.Model.Compras;
using CaficaERP.ViewModel.Compras;
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
   public class OrdendeCompraGridViewModel : GridViewModel<ComprasDocs, OrdendeCompraFormview, OrdendeCompraFormViewModel>
    {
        public OrdendeCompraGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Folio", FieldName = "Folio", Settings = SettingsType.Default }

            };
        }
        public override void Nuevo()
        {
            OrdendeCompraFormview FrmITem = new OrdendeCompraFormview();
            ViewModelSource.Create(() => new OrdendeCompraFormViewModel(FrmITem)
            {
                FormTitulo = "Orden de compra",
                TabGridActivo = (TabViewModel)this,
                StrWebService = StrWebService,
                RutaReporteForm = StrReporteForm
            });
        }

    }
}

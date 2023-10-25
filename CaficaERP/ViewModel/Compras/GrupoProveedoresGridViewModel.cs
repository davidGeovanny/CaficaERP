using CaficaERP.Model.Compras;
using CaficaERP.Views.Compras;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Compras
{
   public class GrupoProveedoresGridViewModel : GridViewModel<GrupoProveedores, GrupoProveedoresFormView, GrupoProveedoresFormViewModel>
    {
        public GrupoProveedoresGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Nombre", FieldName = "Nombre", Settings = SettingsType.Default }

            };
        }
    }
}

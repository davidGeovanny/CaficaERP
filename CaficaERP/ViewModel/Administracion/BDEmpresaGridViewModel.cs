using CaficaERP.Model.Administracion;
using CaficaERP.ViewModel.Administracion;
using CaficaERP.Views.Administracion;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Administracion
{
    public class BDEmpresaGridViewModel : GridViewModel<BDEmpresas, BDEmpresasFormView, BDEmpresaFormViewModel>
    {
       

        public BDEmpresaGridViewModel(string WebService, string Reporte,string ReporteForm) : base(WebService, Reporte,ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Razon Social", FieldName = "RazonSocial", Settings = SettingsType.Default },
                new Column() { Header="RFC", FieldName = "RFC", Settings = SettingsType.Default },
                new Column() { Header="Status", FieldName = "Status", Settings = SettingsType.Default },
                };
        }
        
  }
}
    
using CaficaERP.Model.Generales;
using CaficaERP.Model.Administracion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.WindowsUI;
using DevExpress.Xpf.Core;
using System.Windows;
using CaficaERP.Views.Generales;

namespace CaficaERP.ViewModel.Generales
{
    public class EstadosGridViewModel : GridViewModel<Estados,EstadosFormView,EstadosFormViewModel>
    {
        public EstadosGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header = "Pais", FieldName = "Paises.Nombre", Settings = SettingsType.Default }
            };
        }
        
    }
}

using CaficaERP.Model.Generales;
using CaficaERP.Views.Generales;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Generales
{
    public class CiudadesGridViewModel : GridViewModel<Ciudades, CiudadesFormView, CiudadesFormViewModel>
    {
        public CiudadesGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Pais", FieldName = "Paises.Nombre", Settings = SettingsType.Default },
                new Column() { Header="Estado", FieldName = "Estados.Nombre", Settings = SettingsType.Default },
                new Column() { Header="Municipio", FieldName = "Municipios.Nombre", Settings = SettingsType.Default }
            };
        
        }

    }
}

using CaficaERP.Model.Administracion;
using CaficaERP.Views.Administracion;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
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
    public class VistasGridViewModel : GridViewModel<Vistas, VistasFormView, VistasFormViewModel>
    {

        public VistasGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Parametros", FieldName = "Parametros", Settings = SettingsType.Default },
                new Column() { Header="Icono", FieldName = "ImagenMenu", Settings = SettingsType.Default },
                 new Column() { Header="Tipo", FieldName = "Tipo", Settings = SettingsType.Default },
                 new Column() { Header="Orden", FieldName = "Orden", Settings = SettingsType.Default },

            };
        }

       

    }
}

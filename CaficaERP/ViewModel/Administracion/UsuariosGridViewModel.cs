using CaficaERP.Model.Administracion;
using CaficaERP.Views.Administracion;
using System;
using System.Collections.Generic;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.WindowsUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Xpf.Core;

namespace CaficaERP.ViewModel.Administracion
{
    public class UsuariosGridViewModel : GridViewModel<Usuarios, UsuariosFormView, UsuariosFormViewModel>
    {
       

        public UsuariosGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Nombre Completo", FieldName = "NombreCompleto", Settings = SettingsType.Default },
                new Column() { Header="Estado", FieldName = "Status", Settings = SettingsType.Default },

            };
        }

    }
}
       
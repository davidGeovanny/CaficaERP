using CaficaERP.Model.Inventarios;
using CaficaERP.Views.Inventarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Inventarios
{
    class MarcasComponentesGridViewModel : GridViewModel<MarcasComponentes, MarcasComponentesFormView, MarcasComponentesFormViewModel>
    {
        public MarcasComponentesGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header = "Nombre", FieldName = "Nombre", Settings = SettingsType.Default }          
            };
        }
    }
}

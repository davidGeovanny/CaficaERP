using CaficaERP.Model.Inventarios;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Inventarios
{
    public class GrupoComponentesFormViewModel : FormularioViewModel<GruposComponentes>
    {
        private TiposComponentes _TipoComponenteSeleccionado;

        public TiposComponentes TipoComponenteSeleccionado
        {
            get
            {
                return _TipoComponenteSeleccionado;
            }

            set
            {
                SetProperty(ref _TipoComponenteSeleccionado, value, () => TipoComponenteSeleccionado);
            }
        }
        public GrupoComponentesFormViewModel()
        {
            CargarTiposComponentes();
        }
        public GrupoComponentesFormViewModel(GruposComponentes item,string conexion) : base (item,conexion)
        {

        }
        public override void CargarItem()
        {
            try
            {
                base.CargarItem();
                //Carga el objeto directamente del WS
                CargarTiposComponentes();
                TipoComponenteSeleccionado = LstTiposComponentes.Single(x => x.Id == Item.TipoComponenteId);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
    }
}

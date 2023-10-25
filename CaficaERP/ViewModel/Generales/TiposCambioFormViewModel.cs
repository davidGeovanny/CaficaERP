using CaficaERP.Model.Generales;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Generales
{
    public class TiposCambioFormViewModel : FormularioViewModel<TiposCambio>
    {

        private Monedas _MonedaSeleccionada;



        public Monedas MonedaSeleccionada
        {
            get
            {
                return _MonedaSeleccionada;
            }

            set
            {
                SetProperty(ref _MonedaSeleccionada, value, () => MonedaSeleccionada);
            }
        }
        public TiposCambioFormViewModel()
        {
            CargarMonedas();

        }

        public TiposCambioFormViewModel(TiposCambio item, string conexion) : base(item, conexion)
        {



        }
        public override void CargarItem()
        {
            try
            {
                base.CargarItem();
                CargarMonedas();
                MonedaSeleccionada = LstMonedas.Single(x => x.Id == Item.MonedaId);


            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }

    }
}

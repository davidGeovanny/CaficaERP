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
   public class MonedasFormViewModel : FormularioViewModel<Monedas>
    {
        private CodigosISOMonedas _CodigoSeleccionado;
        private System.Collections.ObjectModel.ObservableCollection<CodigosISOMonedas> _LstCodigosMonedas;






        public System.Collections.ObjectModel.ObservableCollection<CodigosISOMonedas> LstCodigosMonedas
        {
            get
            {
                return _LstCodigosMonedas;
            }

            set
            {
                SetProperty(ref _LstCodigosMonedas, value, () => LstCodigosMonedas);
            }
        }

        public CodigosISOMonedas CodigoSeleccionado
        {
            get
            {
                return _CodigoSeleccionado;
            }

            set
            {
                SetProperty(ref _CodigoSeleccionado, value, () => CodigoSeleccionado);
            }
        }

        public MonedasFormViewModel()
        {
            CargarSiNo();
            CargarCodigosMonedas();
        }

        public MonedasFormViewModel(Monedas item, string conexion) : base(item, conexion)
        {



        }
        public override void CargarItem()
        {
            try
            {
                base.CargarItem();
                CargarSiNo();
                CargarCodigosMonedas();
                CodigoSeleccionado = LstCodigosMonedas.Single(x => x.Id == Item.CodigoISOMonedaId);


            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }



        public void CargarCodigosMonedas()
        {
            try
            {
                LstCodigosMonedas = new System.Collections.ObjectModel.ObservableCollection<CodigosISOMonedas>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Generales/WSCodigosISOMonedas.svc", "getall", null, typeof(System.Collections.ObjectModel.ObservableCollection<CodigosISOMonedas>), null);
                LstCodigosMonedas = (System.Collections.ObjectModel.ObservableCollection<CodigosISOMonedas>)Ws.Peticion();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
    }
}

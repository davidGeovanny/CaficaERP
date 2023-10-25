using CaficaERP.Model.Inventarios;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Inventarios
{
    public class ConceptosFormViewModel : FormularioViewModel<ConceptosES>
    {
      
        private TiposDocumentos _DocuemntoSeleccionado;
        private System.Collections.ObjectModel.ObservableCollection<TiposDocumentos> _LstTiposDocumentos;



        public TiposDocumentos DocuemntoSeleccionado
        {
            get
            {
                return _DocuemntoSeleccionado;
            }

            set
            {
                SetProperty(ref _DocuemntoSeleccionado, value, () => DocuemntoSeleccionado);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<TiposDocumentos> LstTiposDocumentos
        {
            get
            {
                return _LstTiposDocumentos;
            }

            set
            {
                SetProperty(ref _LstTiposDocumentos, value, () => LstTiposDocumentos);
            }
        }

        public ConceptosFormViewModel()
        {
        
           CargarTiposDocumentos();
           CargarNaturaleza();
           CargarSiNo();
        }

        public ConceptosFormViewModel(ConceptosES item, string conexion) : base(item, conexion)
        {



        }
        public override void CargarItem()
        {
            try
            {
            base.CargarItem();
            CargarSiNo();
            CargarNaturaleza();
            CargarTiposDocumentos();
            DocuemntoSeleccionado = LstTiposDocumentos.Single(x => x.Id == Item.TipoDocumentoId);
            
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }



        public void CargarTiposDocumentos()
        {
            try
            {
                LstTiposDocumentos = new System.Collections.ObjectModel.ObservableCollection<TiposDocumentos>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSTiposDocumentos.svc", "getall", null, typeof(System.Collections.ObjectModel.ObservableCollection<TiposDocumentos>), null);
                LstTiposDocumentos = (System.Collections.ObjectModel.ObservableCollection<TiposDocumentos>)Ws.Peticion();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
    }
}

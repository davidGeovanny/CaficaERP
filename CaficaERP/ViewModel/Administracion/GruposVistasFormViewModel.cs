using CaficaERP.Model.Administracion;
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
    public class GruposVistasFormViewModel : FormularioViewModel<GruposVistas>
    {
      
        private System.Collections.ObjectModel.ObservableCollection<Sistemas> _LstSistemas;
        private System.Collections.ObjectModel.ObservableCollection<Modulos> _LstModulos;
        private Sistemas _SistemaSeleccionado;
        private Modulos _ModuloSeleccionado;

        public GruposVistasFormViewModel()
        {
            
            CargarSistemas();
        }

        public GruposVistasFormViewModel(GruposVistas item, string conexion) : base(item, conexion)
        {

        }
        public override void CargarItem()
        {
            try
            {
            base.CargarItem();
            CargarSistemas();
            SistemaSeleccionado = LstSistemas.Single(x => x.Id == Item.SistemaId);
            ModuloSeleccionado = LstModulos.Single(x => x.Id ==Item.ModuloId);

        }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                                        MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Sistemas> LstSistemas
        {
            get
            {
                return _LstSistemas;
            }

            set
            {
                SetProperty(ref _LstSistemas, value, () => LstSistemas);
            }
        }

        public Sistemas SistemaSeleccionado
        {
            get
            {
                return _SistemaSeleccionado;
            }

            set
            {
                SetProperty(ref _SistemaSeleccionado, value, () => SistemaSeleccionado);
                CargarModulos();
            }
        }

        public void CargarSistemas()
        {
            try
            {
                LstSistemas = new System.Collections.ObjectModel.ObservableCollection<Sistemas>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Administracion/WSSistemas.svc", "getall", null, typeof(System.Collections.ObjectModel.ObservableCollection<Sistemas>), null);
                LstSistemas = (System.Collections.ObjectModel.ObservableCollection<Sistemas>)Ws.Peticion();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Modulos> LstModulos
        {
            get
            {
                return _LstModulos;
            }

            set
            {
                SetProperty(ref _LstModulos, value, () => LstModulos);
            }
        }

        public Modulos ModuloSeleccionado
        {
            get
            {
                return _ModuloSeleccionado;
            }

            set
            {
                SetProperty(ref _ModuloSeleccionado, value, () => ModuloSeleccionado);
            }
        }

        public void CargarModulos()
        {
            try
            {
                LstModulos = new System.Collections.ObjectModel.ObservableCollection<Modulos>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Administracion/WSModulos.svc", "getall", SistemaSeleccionado, typeof(System.Collections.ObjectModel.ObservableCollection<Modulos>), "sistema");
                LstModulos = (System.Collections.ObjectModel.ObservableCollection<Modulos>)Ws.Peticion();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }


        public override void GuardarItem()
        {
            base.GuardarItem();
        }




    }
}

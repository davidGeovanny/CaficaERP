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
    class ModulosFormViewModel : FormularioViewModel<Modulos>
    {
       
        private System.Collections.ObjectModel.ObservableCollection<Sistemas> _LstSistemas;
        

        public ModulosFormViewModel()
        {
          
            CargarSistemas();
        }

        public ModulosFormViewModel(Modulos item, string conexion) : base(item, conexion)
        {

        }

        public override void CargarItem()
        {

            try
            {
                base.CargarItem();
                CargarSistemas();

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
    }
}

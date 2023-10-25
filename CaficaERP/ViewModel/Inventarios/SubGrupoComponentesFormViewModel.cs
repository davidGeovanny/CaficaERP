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
    public class SubGrupoComponentesFormViewModel : FormularioViewModel<SubgruposComponentes>
    {
       
        private GruposComponentes _GrupoSeleccionado;
        private System.Collections.ObjectModel.ObservableCollection<GruposComponentes> _LstGrupos;

        public GruposComponentes GrupoSeleccionado
        {
            get
            {
                return _GrupoSeleccionado;
            }

            set
            {
                SetProperty(ref _GrupoSeleccionado, value, () => GrupoSeleccionado);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<GruposComponentes> LstGrupos
        {
            get
            {
                return _LstGrupos;
            }

            set
            {
                SetProperty(ref _LstGrupos, value, () => LstGrupos);
            }
        }

        public SubGrupoComponentesFormViewModel()
        {
            
            CargarGrupos();
        }

        public SubGrupoComponentesFormViewModel(SubgruposComponentes item, string conexion) : base(item, conexion)
        {
            
        }
        public override void CargarItem()
        {
            base.CargarItem();
            CargarGrupos();
            GrupoSeleccionado = LstGrupos.Single(x => x.Id == Item.GrupoComponentesId);
        }

        public void CargarGrupos()
        {
            try
            {
                LstGrupos = new System.Collections.ObjectModel.ObservableCollection<GruposComponentes>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSGrupoComponentes.svc", "getall", null, typeof(System.Collections.ObjectModel.ObservableCollection<GruposComponentes>), null);
                LstGrupos = (System.Collections.ObjectModel.ObservableCollection<GruposComponentes>)Ws.Peticion();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
    }
}

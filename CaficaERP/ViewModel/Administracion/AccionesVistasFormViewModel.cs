using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaficaERP.Model.Administracion;
using System.Collections.ObjectModel;
using System.Windows;
using DevExpress.Xpf.WindowsUI;
using DevExpress.Xpf.Core;

namespace CaficaERP.ViewModel.Administracion
{
     public class AccionesVistasFormViewModel : FormularioViewModel<AccionesVistas>
    {   
        private Vistas _VistasSelecionada;
        private List<string> _LstTipos;

        public AccionesVistasFormViewModel()
        {
           
            CargarVistas();
            CargarTipos();
        }

        public AccionesVistasFormViewModel(AccionesVistas item, string conexion) : base(item, conexion)
        {

        }

        public Vistas VistasSelecionada
        {
            get
            {
                return _VistasSelecionada;
            }

            set
            {
                SetProperty(ref _VistasSelecionada, value, () => VistasSelecionada);
            }
        }


        public List<string> LstTipos
        {
            get
            {
                return _LstTipos;
            }

            set
            {
                SetProperty(ref _LstTipos, value, () => LstTipos);
            }
        }
        public override void CargarItem()
        {

            try
            {
                base.CargarItem();
                CargarVistas();
                CargarTipos();
   
            }
            catch (Exception ex)
            {

              DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }


        public void CargarTipos()
        {
            try
            {
                LstTipos = new List<string>();
                LstTipos.Add("DELETE");
                LstTipos.Add("ESPECIAL");
                LstTipos.Add("INSERT");
                LstTipos.Add("SELECT");
                LstTipos.Add("UPDATE");
                
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

    }
}

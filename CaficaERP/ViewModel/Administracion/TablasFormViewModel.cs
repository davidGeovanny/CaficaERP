using CaficaERP.Model.Administracion;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Administracion
{ 
     public class TablasFormViewModel : FormularioViewModel<Tablas>
    {


        public TablasFormViewModel()
        {
         

        }
        public TablasFormViewModel(Tablas item, string conexion) : base(item, conexion)
        {


        }
        


    /*    public override void Siguiente()
        {
            try
            {

                long BuscaId=TabGridActivo.Siguiente();

                if (BuscaId>0)
                {
                    ServicioWS Ws = new ServicioWS("ServiciosERP/Administracion/WSTablas.svc", "getTabla", BuscaId, typeof(TablasModel), "ID");
                    Tabla = (TablasModel)Ws.Peticion();
                }
                
                
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public override void Anterior()
        {
            try
            {

                long BuscaId = TabGridActivo.Anterior();

                if (BuscaId > 0)
                {
                    ServicioWS Ws = new ServicioWS("ServiciosERP/Administracion/WSTablas.svc", "getTabla", BuscaId, typeof(TablasModel), "ID");
                    Tabla = (TablasModel)Ws.Peticion();
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }*/
    }
}

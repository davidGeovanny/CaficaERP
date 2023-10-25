using CaficaERP.Model.Ventas.Monedero;
using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace CaficaERP.ViewModel.Ventas.Monedero
{
    public class CanjeFormViewModel : FormularioViewModel<MovimientosMonedero>
    {
        public virtual Boolean CentrosdeCanjeActivos { get; set; }
        public virtual CentrosCanjeMonedero CentroCanjeSeleccionado { get; set; }
        public virtual string CodigoCanje { get; set; }

        //Nuevo
        public CanjeFormViewModel(object view) : base(view)
        {
            CargarCentrosCanjeMonedero();

            ServicioWS Ws = new ServicioWS("ServiciosERP/Ventas/WSCentrosCanjeMonedero.svc", "getCentrosdeCanjexUsuario", null, typeof(long), null);
            long CentrodeCanjeId = (long)Ws.Peticion();

            Item.CentroCanjeMonederoId = CentrodeCanjeId;
            this.RaisePropertyChanged(x => x.Item);

        }
        //Modificar
        public CanjeFormViewModel(object view, MovimientosMonedero item, string conexion) : base(view, item, conexion)
        {
            IconCancelar = true;
            
        }
        public void BuscarSolicitud()
        {
            try
            {
                string codigo = CodigoCanje.Replace("-","");

                ServicioWS Ws = new ServicioWS("ServiciosERP/Ventas/WSSolicitudesCanjeMonedero.svc", "getSolicitudxCodigo",codigo, typeof(SolicitudesCanjeMonedero),"codigo");
                SolicitudesCanjeMonedero Solicitud = (SolicitudesCanjeMonedero)Ws.Peticion();

                Item.MovimientosMonederoDetalles.Clear();

                //Asgina el id del cliente que quiere realizar su canje
                Item.UsuariosMonedero = Solicitud.UsuariosMonedero;
                Item.UsuarioMonederoId = Solicitud.UsuariosMonedero.Id;
                Item.CentrosCanjeMonedero = CentroCanjeSeleccionado;

                foreach(SolicitudesCanjeMonederoDetalles detalle in Solicitud.SolicitudesCanjeMonederoDetalles)
                {
                    
                    Item.MovimientosMonederoDetalles.Add(new MovimientosMonederoDetalles {
                        PremioId = detalle.PremioId,
                        Puntos = (int)detalle.PremiosMonedero.PuntosCanje,
                        SolicitudesCanjeMonederoDetallesId = detalle.Id,
                        PremiosMonedero = new PremiosMonedero
                        {
                            Id=detalle.PremiosMonedero.Id,
                            Nombre=detalle.PremiosMonedero.Nombre,
                            PuntosCanje=detalle.PremiosMonedero.PuntosCanje,
                            ImagenBase64=detalle.PremiosMonedero.ImagenBase64
                        },
                        //Guarda el SolicitudDetalleId en el movimiento
                        
                    });
                }

                this.RaisePropertyChanged(x => x.Item);
            }
            catch (Exception ex)
            {
                Item.MovimientosMonederoDetalles.Clear();
                Item.UsuariosMonedero= null;
                this.RaisePropertyChanged(x => x.Item);
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                        MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void GuardarItem()
        {
            try
            {
                //Si quiero modificar el canje, esta funcionalidad no esta permitida
                if (Item.Id != 0)
                    return;

                string errores = Item.Errores();
                if (!string.IsNullOrEmpty(errores))
                    throw new Exception(errores);

                base.GuardarItem();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public override void CargarItem()
        {
            try
            {
                //Editar
                CargarCentrosCanjeMonedero();

                Item.CanValidate = true;
                CamposEnabled = false;

                base.CargarItem();
                Item.Errores();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void EliminaFila(MovimientosMonederoDetalles detalle)
        {
            try
            {
                if (detalle != null && Item.Id == 0)
                {
                    Item.MovimientosMonederoDetalles.Remove(detalle);
                }
                this.RaisePropertyChanged(x => x.Item);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

    }
}

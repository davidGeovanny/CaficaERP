using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Ventas.Monedero
{
    public class SolicitudesCanjeMonederoDetalles : BaseModel
    {
        public long SolicitudCanjeMonederoId { get; set; }
        public long UsuarioMonederoId { get; set; }
        public long PremioId { get; set; }
        public double PuntosCanje { get; set; }
        public Nullable<System.DateTime> VigenciaAl { get; set; }
        public string Estado { get; set; }
        public Nullable<long> MovimientoMonederoId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public Nullable<long> CentroCanjeId { get; set; }

        public virtual MovimientosMonedero MovimientosMonedero { get; set; }
        public virtual UsuariosMonedero UsuariosMonedero { get; set; }
        public virtual PremiosMonedero PremiosMonedero { get; set; }
        public virtual CentrosCanjeMonedero CentrosCanjeMonedero { get; set; }
        public virtual SolicitudesCanjeMonedero SolicitudesCanjeMonedero { get; set; }

        public override string Validar(string propiedad)
        {

            return null;
        }
    }
}

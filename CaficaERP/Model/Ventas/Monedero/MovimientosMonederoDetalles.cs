using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Ventas.Monedero
{
    public class MovimientosMonederoDetalles : BaseModel
    {
        public long MovimientoMonederoId { get; set; }
        public long PremioId { get; set; }

        public Nullable<long> SolicitudesCanjeMonederoDetallesId { get; set; }
        public double Puntos { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual PremiosMonedero PremiosMonedero { get; set; }
        public virtual MovimientosMonedero MovimientosMonedero { get; set; }

        public override string Validar(string propiedad)
        {

            return null;
        }
    }
}

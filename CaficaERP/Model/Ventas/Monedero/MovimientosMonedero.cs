using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Ventas.Monedero
{
    public class MovimientosMonedero : BaseModel
    {
        public MovimientosMonedero()
        {
            this.MovimientosMonederoDetalles = new System.Collections.ObjectModel.ObservableCollection<MovimientosMonederoDetalles>();
        }
        public long UsuarioMonederoId { get; set; }
        public System.DateTime FechaHora { get; set; }
        public Nullable<double> Canje { get; set; }
        public Nullable<double> Abono { get; set; }
        public string FolioTicket { get; set; }
        public Nullable<double> MontoTicket { get; set; }
        public Nullable<long> SocioMonederoId { get; set; }
        public Nullable<long> CentroCanjeMonederoId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual SociosMonedero SociosMonedero { get; set; }
        public virtual UsuariosMonedero UsuariosMonedero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<MovimientosMonederoDetalles> MovimientosMonederoDetalles { get; set; }
        public virtual CentrosCanjeMonedero CentrosCanjeMonedero { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Ventas.Monedero
{
    public class SolicitudesCanjeMonedero : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SolicitudesCanjeMonedero()
        {
            this.SolicitudesCanjeMonederoDetalles = new System.Collections.ObjectModel.ObservableCollection<SolicitudesCanjeMonederoDetalles>();
        }

        public long UsuarioMonederoId { get; set; }
        public string CodigoCanje { get; set; }
        public System.DateTime FechaHora { get; set; }
        public Nullable<System.DateTime> VigenciaAl { get; set; }
        public string Estado { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public Nullable<double> TotalPuntosCanje { get; set; }

        public virtual UsuariosMonedero UsuariosMonedero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<SolicitudesCanjeMonederoDetalles> SolicitudesCanjeMonederoDetalles { get; set; }

        public override string Validar(string propiedad)
        {

            return null;
        }
    }
}

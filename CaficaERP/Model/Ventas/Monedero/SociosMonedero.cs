using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Ventas.Monedero
{
  public  class SociosMonedero :BaseModel
    {
        public SociosMonedero()
        {
            this.MovimientosMonedero = new ObservableCollection<MovimientosMonedero>();
        }
        public string Nombre { get; set; }
        public string Servidor { get; set; }
        public Nullable<double> FactorMontoCompra { get; set; }
        public Nullable<long> FactorPuntos { get; set; }
        public Nullable<int> AntiguedadTicket { get; set; }
        public string GrupoSocio { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<MovimientosMonedero> MovimientosMonedero { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class ExistenciasLotesSeries
    {
        public long LotesSeriesId { get; set; }
        public long ComponenteId { get; set; }
        public double Existencia { get; set; }
        public long AlmacenId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Almacenes Almacenes { get; set; }
        public virtual Componentes Componentes { get; set; }
        public virtual LotesSeries LotesSeries { get; set; }
    }
}

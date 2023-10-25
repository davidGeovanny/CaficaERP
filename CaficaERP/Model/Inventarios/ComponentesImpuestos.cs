using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public partial class ComponentesImpuestos
    {
        public long Id { get; set; }
        public long ComponenteId { get; set; }
        public long ImpuestoId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Componentes Componentes { get; set; }
        public virtual Impuestos Impuestos { get; set; }
    }
}

using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class ComponentesCodigosBarras : BaseModel
    {
        public long ComponenteId { get; set; }
        public long UnidadId { get; set; }
        public string CodigoBarra { get; set; }
        public string Activo { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public virtual Componentes Componentes { get; set; }
        public virtual Unidades Unidades { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

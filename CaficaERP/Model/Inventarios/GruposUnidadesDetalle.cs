using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class GruposUnidadesDetalle : BaseModel
    {
        public long GrupoUnidadesId { get; set; }
        public double CantidadEquivalente { get; set; }
        public long UnidadEquivalenteId { get; set; }
        public double CantidadBase { get; set; }
        public long UnidadBaseId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual GruposUnidades GruposUnidades { get; set; }
        public virtual Unidades Unidades { get; set; }
        public virtual Unidades Unidades1 { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

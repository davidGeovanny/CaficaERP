using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public partial class ComponentesEquivalenciasPartes :BaseModel
    {
      
        public long ComponenteId { get; set; }
        public long MarcaId { get; set; }
        public string NoParte { get; set; }
        public string Modelo { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Componentes Componentes { get; set; }
        public virtual MarcasComponentes MarcasComponentes { get; set; }

        public override string Validar(string propiedad)
        {
            throw new NotImplementedException();
        }
    }
}

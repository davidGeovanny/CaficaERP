using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Administracion
{
  public  class VistasTablas : BaseModel
    {
        public long VistaId { get; set; }
        public long TablaId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Tablas Tablas { get; set; }
        public virtual Vistas Vistas { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

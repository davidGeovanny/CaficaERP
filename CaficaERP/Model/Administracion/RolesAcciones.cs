using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Administracion
{
    public class RolesAcciones : BaseModel
    {
        public long RolId { get; set; }
        public long AccionId { get; set; }
        public string UsuarioCreo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public System.DateTime FechaUltimaModificacion { get; set; }

        public virtual AccionesVistas AccionesVistas { get; set; }
        public virtual Roles Roles { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

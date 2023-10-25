using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Administracion
{
    public class BDEmpresasRoles
    {
        public long RolId { get; set; }
        public long BDEmpresaId { get; set; }
        public string UsuarioCreo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public System.DateTime FechaUltimaModificacion { get; set; }

        public virtual BDEmpresas BDEmpresas { get; set; }
        public virtual Roles Roles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Administracion
{
    public class VistasGruposVistas : BaseModel
    {
        public long VistaId { get; set; }
        public long GrupoVistaId { get; set; }
        public Nullable<long> ModuloId { get; set; }
        public Nullable<long> SistemaId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual GruposVistas GruposVistas { get; set; }
        public virtual Vistas Vistas { get; set; }
        public virtual Sistemas Sistemas { get; set; }
        public virtual Modulos Modulos { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

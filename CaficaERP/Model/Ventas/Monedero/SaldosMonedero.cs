using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Ventas.Monedero
{
    public class SaldosMonedero  : BaseModel
    {
        public long UsuarioMonederoId { get; set; }
        public double Saldo { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual UsuariosMonedero UsuariosMonedero { get; set; }

        public override string Validar(string propiedad)
        {

            return null;
        }
    }
}

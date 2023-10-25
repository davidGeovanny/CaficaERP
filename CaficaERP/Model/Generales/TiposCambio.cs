using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Generales
{
   public class TiposCambio :BaseModel
    {

     
        public long MonedaId { get; set; }
        public System.DateTime Fecha { get; set; }
        public double TipoCambio { get; set; }
        public Nullable<double> TipoCambioCobros { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Monedas Monedas { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

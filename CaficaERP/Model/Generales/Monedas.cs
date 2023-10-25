using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Generales
{
   public class Monedas  : BaseModel
    {

        public string Nombre { get; set; }
        public string TextoImporteLetra { get; set; }
        public string Simbolo { get; set; }
        public long CodigoISOMonedaId { get; set; }
        public string MonedaLocal { get; set; }
        public string Predeterminado { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual CodigosISOMonedas CodigosISOMonedas { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

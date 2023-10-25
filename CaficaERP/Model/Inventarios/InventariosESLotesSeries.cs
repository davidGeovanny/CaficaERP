using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class InventariosESLotesSeries : BaseModel
    {
      
        public long InventariosESDetalleId { get; set; }
        public double Cantidad { get; set; }
        public Nullable<long> LotesSeriesId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual InventariosESDetalles InventariosESDetalles { get; set; }
        public virtual LotesSeries LotesSeries { get; set; }

       

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

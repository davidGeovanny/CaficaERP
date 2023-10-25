using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Compras
{
   public class ComprasDocsImpuestos : BaseModel
    {

        public long ComprasDocsId { get; set; }
        public long ImpuestoId { get; set; }
        public double SubtotalCompra { get; set; }
        public Nullable<double> Otrosimpuestos { get; set; }
        public double Porcentaje { get; set; }
        public double Importe { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual ComprasDocs ComprasDocs { get; set; }
        public virtual Impuestos Impuestos { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

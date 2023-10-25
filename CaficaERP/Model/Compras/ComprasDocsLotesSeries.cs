using CaficaERP.Model.Inventarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Compras
{
   public class ComprasDocsLotesSeries :BaseModel
    {
   
        public long ComprasDocsDetalleId { get; set; }
         
        public double Cantidad { get; set; }
        public long LotesSeriesId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public virtual ComprasDocsDetalles Detalle { get; set; }

        //Esta lista de objetos se utiliza para cargar las series disponibles del componente
        public virtual System.Collections.ObjectModel.ObservableCollection<LotesSeries> LstLotesSeries { get; set; }

        public virtual LotesSeries LotesSeries { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

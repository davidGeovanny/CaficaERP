using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
   public class InventariosESDetalles : BaseModel
    {

        public InventariosESDetalles()
        {
            this.InventariosESLotesSeries = new ObservableCollection<InventariosESLotesSeries>();
            this.InventariosFisicosDetalles = new ObservableCollection<InventariosFisicosDetalles>();
        }

        public long InventariosESId { get; set; }
        public long ConceptoId { get; set; }
        public string Naturaleza { get; set; }
        public long AlmacenId { get; set; }
        public long ComponenteId { get; set; }
        public System.DateTime Fecha { get; set; }
        public double Cantidad { get; set; }
        public double CostoUnitario { get; set; }
        public double CostoTotal { get; set; }
        public string MetodoCosteo { get; set; }
        public long ComponentesAlmacenesId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public string TipoSeguimiento { get; set; }

        public virtual Almacenes Almacenes { get; set; }
        public virtual ComponentesAlmacenes ComponentesAlmacenes { get; set; }
        public virtual ConceptosES ConceptosES { get; set; }
        public virtual Componentes Componentes { get; set; }
        public virtual InventariosES InventariosES { get; set; }
        public virtual ObservableCollection<InventariosESLotesSeries> InventariosESLotesSeries { get; set; }
        public virtual ObservableCollection<InventariosFisicosDetalles> InventariosFisicosDetalles { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

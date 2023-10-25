using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public partial class ComponentesFormula : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComponentesFormula()
        {
            this.ComponentesFormulaDetalles = new ObservableCollection<ComponentesFormulaDetalles>();
        }
        public long ComponenteId { get; set; }
        public Nullable<double> CostoTotal { get; set; }
        public string Estado { get; set; }
        public Nullable<double> Rendimiento { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public virtual Componentes Componentes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComponentesFormulaDetalles> ComponentesFormulaDetalles { get; set; }


        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class AlmacenesGruposComponentes : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AlmacenesGruposComponentes()
        {
            this.ComponentesAlmacenes = new ObservableCollection<ComponentesAlmacenes>();
        }
        public long GrupoComponentesId { get; set; }
        public Nullable<long> AlmacenId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual GruposComponentes GruposComponentes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComponentesAlmacenes> ComponentesAlmacenes { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

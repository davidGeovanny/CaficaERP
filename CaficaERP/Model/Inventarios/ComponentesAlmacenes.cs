using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class ComponentesAlmacenes : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComponentesAlmacenes()
        {
            this.InventariosESDetalles = new ObservableCollection<InventariosESDetalles>();
            this.InventariosFisicosDetalles = new ObservableCollection<InventariosFisicosDetalles>();
            this.ResguardosDetalles = new ObservableCollection<ResguardosDetalles>();
        }

        public long ComponenteId { get; set; }
        public long AlmacenId { get; set; }
        public Nullable<long> Maximo { get; set; }
        public Nullable<long> Reorden { get; set; }
        public Nullable<long> Minimo { get; set; }
        public string Localizacion { get; set; }
        public long AlmacenesGruposComponentesId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
       
     
        public virtual Almacenes Almacenes { get; set; }

        public virtual AlmacenesGruposComponentes AlmacenesGruposComponentes { get; set; }
        public virtual Componentes Componentes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosESDetalles> InventariosESDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosFisicosDetalles> InventariosFisicosDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ResguardosDetalles> ResguardosDetalles { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

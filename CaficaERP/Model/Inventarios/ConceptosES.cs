using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public  class ConceptosES :BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConceptosES()
        {
            this.InventariosES = new ObservableCollection<InventariosES>();
            this.InventariosESDetalles = new ObservableCollection<InventariosESDetalles>();
        }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Predefinido { get; set; }
        public string Naturaleza { get; set; }
        public string FolioAutomatico { get; set; }
        public Nullable<long> TipoDocumentoId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public string CostoAutomatico { get; set; }

        public virtual TiposDocumentos TiposDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosES> InventariosES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosESDetalles> InventariosESDetalles { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class InventariosES : BaseModel

    {
        public InventariosES()
        {
            this.InventariosESDetalles = new ObservableCollection<InventariosESDetalles>();
            this.InventariosFisicos = new ObservableCollection<InventariosFisicos>();
            this.InventariosFisicos1 = new ObservableCollection<InventariosFisicos>();
        }
        public long ConceptoId { get; set; }
        public long AlmacenId { get; set; }
        public string Folio { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Naturaleza { get; set; }
        public double CostoTotal { get; set; }
        public string Cancelado { get; set; }
        public Nullable<long> SalidaTraspasoId { get; set; }
        public Nullable<long> TipoDocumentoId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public Nullable<long> AlmacenDestinoId { get; set; }
        public string SalidaTraspasoAplicada { get; set; }
        public string ModuloOrigen { get; set; }

        public virtual Almacenes Almacenes { get; set; }
        public virtual Almacenes Almacenes1 { get; set; }
        public virtual ConceptosES ConceptosES { get; set; }
 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosESDetalles> InventariosESDetalles { get; set; }
        public virtual TiposDocumentos TiposDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosFisicos> InventariosFisicos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosFisicos> InventariosFisicos1 { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => ConceptoId))
            {
                if (ConceptoId == 0)
                    return "El campo concepto es obligatorio";
                if(ConceptoId == 12 && AlmacenDestinoId==null)
                    return "El campo almacen destino es obligatorio";
            }
            if (propiedad == BindableBase.GetPropertyName(() => AlmacenId))
            {
                if (AlmacenId == 0)
                    return "El campo almacen es obligatorio";
            }
            if (propiedad == BindableBase.GetPropertyName(() => AlmacenId))
            {
                if (AlmacenId == 0)
                    return "El campo almacen es obligatorio";
            }
            return null;
        }
    }
}

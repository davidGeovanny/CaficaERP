using CaficaERP.Model.Compras;
using CaficaERP.Model.Generales;
using CaficaERP.Model.Ventas.Monedero;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class Almacenes : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Almacenes()
        {
            this.AlmacenesGruposComponentes = new System.Collections.ObjectModel.ObservableCollection<AlmacenesGruposComponentes>();
            this.ComponentesAlmacenes = new System.Collections.ObjectModel.ObservableCollection<ComponentesAlmacenes>();
        }

        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string TipoAlmacen { get; set; }
        public string Activo { get; set; }
        public long TipoComponenteId { get; set; }
        public string Virtual { get; set; }
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public Nullable<long> ColoniaId { get; set; }
        public Nullable<long> CodigoPostalId { get; set; }
        public Nullable<long> CiudadId { get; set; }
        public Nullable<long> MunicipioId { get; set; }
        public Nullable<long> EstadoId { get; set; }
        public Nullable<long> PaisId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual TiposComponentes TiposComponentes { get; set; }
        public virtual Ciudades Ciudades { get; set; }
        public virtual CodigosPostales CodigosPostales { get; set; }
        public virtual Colonias Colonias { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual Municipios Municipios { get; set; }
        public virtual Paises Paises { get; set; }
        public virtual ObservableCollection<AlmacenesGruposComponentes> AlmacenesGruposComponentes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<CentrosCanjeMonedero> CentrosCanjeMonedero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComponentesAlmacenes> ComponentesAlmacenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComprasDocs> ComprasDocs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosES> InventariosES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosESDetalles> InventariosESDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ExistenciasLotesSeries> ExistenciasLotesSeries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosES> InventariosES1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosSaldos> InventariosSaldos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosCostos> InventariosCostos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosFisicos> InventariosFisicos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Resguardos> Resguardos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ResguardosDetalles> ResguardosDetalles { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Clave))
            {
                if (string.IsNullOrEmpty(Clave))
                {
                    return "El campo Clave es obligatorio";

                }
            }
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                {
                    return "El campo Nombre es obligatorio";
                }
            }
            if (propiedad == BindableBase.GetPropertyName(() => TipoAlmacen))
            {
                if (string.IsNullOrEmpty(TipoAlmacen))
                {
                    return "El campo Tipo Almacen es obligatorio";
                }
            }
            if (propiedad == BindableBase.GetPropertyName(() => Activo))
            {
                if (string.IsNullOrEmpty(Activo))
                {
                    return "El campo Tipo Almacen es obligatorio";
                }
            }
            if (propiedad == BindableBase.GetPropertyName(() => TipoComponenteId))
            {
                if (TipoComponenteId==0)
                {
                    return "El campo Tipo Componente es obligatorio";
                }
            }
            return null;
        }
    }
}

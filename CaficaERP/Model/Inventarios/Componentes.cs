using CaficaERP.Model.Generales;
using CaficaERP.Model.Ventas.Monedero;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class Componentes : BaseModel
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Componentes()
        {
            this.ComponentesAlmacenes = new System.Collections.ObjectModel.ObservableCollection<ComponentesAlmacenes>();
            this.ComponentesFormulaDetalles = new System.Collections.ObjectModel.ObservableCollection<ComponentesFormulaDetalles>();
            this.ComponentesFormula = new System.Collections.ObjectModel.ObservableCollection<ComponentesFormula>();
            this.ComponentesCodigosBarras = new System.Collections.ObjectModel.ObservableCollection<ComponentesCodigosBarras>();
            this.ComponentesImagenes = new System.Collections.ObjectModel.ObservableCollection<ComponentesImagenes>();
            this.ComponentesEquivalenciasPartes = new System.Collections.ObjectModel.ObservableCollection<ComponentesEquivalenciasPartes>();
            this.ComponentesFormulaDetalles1 = new System.Collections.ObjectModel.ObservableCollection<ComponentesFormulaDetalles>();
            this.ComponentesImpuestos = new System.Collections.ObjectModel.ObservableCollection<ComponentesImpuestos>();
            this.InventariosESDetalles = new System.Collections.ObjectModel.ObservableCollection<InventariosESDetalles>();
            this.InventariosFisicosDetalles = new System.Collections.ObjectModel.ObservableCollection<InventariosFisicosDetalles>();
            this.LotesSeries = new System.Collections.ObjectModel.ObservableCollection<LotesSeries>();
            this.ExistenciasLotesSeries = new System.Collections.ObjectModel.ObservableCollection<ExistenciasLotesSeries>();
            this.InventariosSaldos = new System.Collections.ObjectModel.ObservableCollection<InventariosSaldos>();
            this.InventariosCostos = new System.Collections.ObjectModel.ObservableCollection<InventariosCostos>();
            this.PremiosMonederoDetalles = new System.Collections.ObjectModel.ObservableCollection<PremiosMonederoDetalles>();
            this.ResguardosDetalles = new System.Collections.ObjectModel.ObservableCollection<ResguardosDetalles>();
            this.ResguardosLotesSeries = new System.Collections.ObjectModel.ObservableCollection<ResguardosLotesSeries>();
        }

        public long TipoComponenteId { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public long GrupoComponentesId { get; set; }
        public long SubgrupoComponentesId { get; set; }
        public string Activo { get; set; }
        public string AplicaIVA { get; set; }
        public string AplicaISR { get; set; }
        public string Inventariable { get; set; }
        public string TipoSeguimiento { get; set; }
        public Nullable<long> GrupoUnidadesId { get; set; }
        public Nullable<long> UnidadInventarioId { get; set; }
        public Nullable<long> UnidadVentaId { get; set; }
        public Nullable<long> UnidadCompraId { get; set; }
        public Nullable<double> Costo { get; set; }
        public Nullable<double> Rendimiento { get; set; }
        public Nullable<long> MarcaId { get; set; }
        public string NoParte { get; set; }
        public string Modelo { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual GruposComponentes GruposComponentes { get; set; }
        public virtual GruposUnidades GruposUnidades { get; set; }
        public virtual MarcasComponentes MarcasComponentes { get; set; }
        public virtual SubgruposComponentes SubgruposComponentes { get; set; }
        public virtual TiposComponentes TiposComponentes { get; set; }
        public virtual Unidades Unidades { get; set; }
        public virtual Unidades Unidades1 { get; set; }
        public virtual Unidades Unidades2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComponentesAlmacenes> ComponentesAlmacenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComponentesFormulaDetalles> ComponentesFormulaDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComponentesFormula> ComponentesFormula { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComponentesCodigosBarras> ComponentesCodigosBarras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComponentesImagenes> ComponentesImagenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComponentesEquivalenciasPartes> ComponentesEquivalenciasPartes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComponentesFormulaDetalles> ComponentesFormulaDetalles1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComponentesImpuestos> ComponentesImpuestos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<InventariosESDetalles> InventariosESDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<InventariosFisicosDetalles> InventariosFisicosDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<LotesSeries> LotesSeries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ExistenciasLotesSeries> ExistenciasLotesSeries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventariosSaldos> InventariosSaldos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventariosCostos> InventariosCostos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<PremiosMonederoDetalles> PremiosMonederoDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ResguardosDetalles> ResguardosDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ResguardosLotesSeries> ResguardosLotesSeries { get; set; }

        public byte[] Imagen
        {
            get
            {

                foreach (ComponentesImagenes i in this.ComponentesImagenes)
                {
                    if (i.ImagenBase64 != null)
                    {
                        return Convert.FromBase64String(i.ImagenBase64);
                    }
                    else
                        return null;
                }
                
                return null;

            }
            set
            {
                value = null;
            }
        }


        public override string Validar(string propiedad)
        {

            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El campo Nombre  es obligatorio";
            }

            if (propiedad == BindableBase.GetPropertyName(() => NombreCorto))
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El campo Nombre Corto es obligatorio";
            }
            if (propiedad == BindableBase.GetPropertyName(() => GrupoComponentesId))
            {
                if (GrupoComponentesId == 0)
                    return "El campo Grupo de Componentes es Obligatorio";
            }
            if (propiedad == BindableBase.GetPropertyName(() => SubgrupoComponentesId))
            {
                if (SubgrupoComponentesId == 0)
                    return "El campo Subgrupo de Componentes es Obligatorio";
            }
            if (propiedad == BindableBase.GetPropertyName(() => Activo))
            {
                if (string.IsNullOrEmpty(Activo))
                    return "El campo Activo es Obligatorio";
            }
    /*        if (propiedad == BindableBase.GetPropertyName(() => AplicaIVA))
            {
                if (string.IsNullOrEmpty(AplicaIVA))
                    return "El campo Aplica IVA es Obligatorio";
            }
            if (propiedad == BindableBase.GetPropertyName(() => AplicaISR))
            {
                if (string.IsNullOrEmpty(AplicaISR))
                    return "El campo AplicaISR es Obligatorio";
            }*/

            if (this.TipoComponenteId != 4) //Cuando el componente es diferente de servicios solicitara datos de inventario y unidades
            {
                if (propiedad == BindableBase.GetPropertyName(() => Inventariable))
                {
                    if (string.IsNullOrEmpty(Inventariable))
                        return "El campo Inventariable es Obligatorio";
                }
                if (propiedad == BindableBase.GetPropertyName(() => TipoSeguimiento))
                {
                    if (string.IsNullOrEmpty(TipoSeguimiento))
                        return "El campo Tipo Seguimiento es Obligatorio";
                }
                if (propiedad == BindableBase.GetPropertyName(() => GrupoUnidadesId))
                {
                    if (GrupoUnidadesId ==null)
                        return "El campo Grupo de Unidades es Obligatorio";
                }
                if (propiedad == BindableBase.GetPropertyName(() => UnidadInventarioId))
                {
                    if (UnidadInventarioId ==null)
                        return "El campo Unidad de Inventario es Obligatorio";
                }

            }
        /*  if (this.TipoComponenteId == 3 || this.TipoComponenteId == 7) //Cuando el componente es diferente de servicios solicitara datos de inventario y unidades
            {
                if (propiedad == BindableBase.GetPropertyName(() => Modelo))
                {
                    if (string.IsNullOrEmpty(Modelo))
                        return "El campo Modelo es Obligatorio";
                }

            }*/
            return null;

            }
        }
}

using CaficaERP.Model.Compras;
using CaficaERP.Model.Inventarios;
using CaficaERP.Model.Ventas.Monedero;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Generales
{
    public class Unidades : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Unidades()
        {
            this.Componentes = new ObservableCollection<Componentes>();
            this.Componentes1 = new ObservableCollection<Componentes>();
            this.Componentes2 = new ObservableCollection<Componentes>();
            this.ComponentesCodigosBarras = new ObservableCollection<ComponentesCodigosBarras>();
            this.ComponentesFormulaDetalles = new ObservableCollection<ComponentesFormulaDetalles>();
            this.ComprasDocsDetalles = new ObservableCollection<ComprasDocsDetalles>();
            this.ComprasDocsDetalles1 = new ObservableCollection<ComprasDocsDetalles>();
            this.GruposUnidadesDetalle = new ObservableCollection<GruposUnidadesDetalle>();
            this.GruposUnidadesDetalle1 = new ObservableCollection<GruposUnidadesDetalle>();
            this.Impuestos = new ObservableCollection<Impuestos>();
            this.PremiosMonederoDetalles = new ObservableCollection<PremiosMonederoDetalles>();
            this.PremiosMonederoDetalles1 = new ObservableCollection<PremiosMonederoDetalles>();
        }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Componentes> Componentes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Componentes> Componentes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Componentes> Componentes2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComponentesCodigosBarras> ComponentesCodigosBarras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComponentesFormulaDetalles> ComponentesFormulaDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComprasDocsDetalles> ComprasDocsDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComprasDocsDetalles> ComprasDocsDetalles1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<GruposUnidadesDetalle> GruposUnidadesDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<GruposUnidadesDetalle> GruposUnidadesDetalle1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Impuestos> Impuestos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<PremiosMonederoDetalles> PremiosMonederoDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<PremiosMonederoDetalles> PremiosMonederoDetalles1 { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                {
                    return "El campo nombre es obligatorio";
                  
                }
                else if (Nombre.Length < 3)
                    return "La unidad debe de contener al menos 3 caracteres";
               
            }
            if (propiedad == BindableBase.GetPropertyName(() => Abreviatura))
            {
                if (string.IsNullOrEmpty(Abreviatura))
                    return "El campo nombre   abreviado  es obligatorio";
                
            }
            return null;
        }
    }

    }

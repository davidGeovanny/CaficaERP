using CaficaERP.Model.Generales;
using CaficaERP.Model.Inventarios;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Compras
{
    public class ComprasDocsDetalles : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComprasDocsDetalles()
        {
            this.ComprasDocsRelacionesDetalles = new ObservableCollection<ComprasDocsRelacionesDetalles>();
            this.ComprasDocsLotesSeries = new ObservableCollection<ComprasDocsLotesSeries>();
            this.ComprasDocsRelacionesDetalles1 = new ObservableCollection<ComprasDocsRelacionesDetalles>();
            this.LstUnidades = new ObservableCollection<Unidades>();
            
            
        }

        
        public long ComprasDocsId { get; set; }
        public long ComponenteId { get; set; }
        public double CantidadCompra { get; set; }
        public Nullable<double> CantidadPendiente { get; set; }
        public long UnidadCompraId { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<long> UnidadId { get; set; }
        public Nullable<long> GrupoUnidadesId { get; set; }
        public Nullable<double> PrecioUnitario { get; set; }
        public Nullable<double> DescuentoPorcentaje { get; set; }
        public Nullable<double> DescuentoImporte { get; set; }
        public Nullable<double> Importe { get; set; }
        public string Notas { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        //variable para buscar un componente dentro del gri
        public virtual string nombrecomponente { get; set; }

        public virtual Componentes Componentes { get; set; }
        public virtual ComprasDocs ComprasDocs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComprasDocsRelacionesDetalles> ComprasDocsRelacionesDetalles { get; set; }
        public virtual GruposUnidades GruposUnidades { get; set; }
        public virtual Unidades Unidades { get; set; }
        public virtual Unidades Unidades1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComprasDocsLotesSeries> ComprasDocsLotesSeries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComprasDocsRelacionesDetalles> ComprasDocsRelacionesDetalles1 { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------

        public virtual ObservableCollection<Unidades> LstUnidades { get; set; }

        public override string Validar(string propiedad)
        {
         /*   if (propiedad == BindableBase.GetPropertyName(() => Componentes))
            {
                if (Componentes.ComponentesImpuestos.Count < 1) return("Se ocupa");
            }*/
                return null;
        }
    }
}

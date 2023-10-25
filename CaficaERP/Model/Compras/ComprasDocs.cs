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
    public class ComprasDocs : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComprasDocs()
        {
            this.ComprasDocsDetalles = new System.Collections.ObjectModel.ObservableCollection<ComprasDocsDetalles>();
            this.ComprasDocsRelaciones = new System.Collections.ObjectModel.ObservableCollection<ComprasDocsRelacionesl>();
            this.ComprasDocsRelaciones1 = new System.Collections.ObjectModel.ObservableCollection<ComprasDocsRelacionesl>();
            this.ComprasDocsImpuestos = new System.Collections.ObjectModel.ObservableCollection<ComprasDocsImpuestos>();
        }

        public string TipoDocumento { get; set; }
        public Nullable<long> SolicitanteId { get; set; }
        public Nullable<long> DepartamentoId { get; set; }
        public Nullable<long> AlmacenId { get; set; }
        public System.DateTime FechaDocumento { get; set; }
        public string Notas { get; set; }
        public string Estado { get; set; }
        public Nullable<long> ProveedorId { get; set; }
        public string Folio { get; set; }
        public string FolioProveedor { get; set; }
        public Nullable<long> MonedaId { get; set; }
        public Nullable<double> TipoCambio { get; set; }
        public string TipoDescuento { get; set; }
        public Nullable<double> DescuentoPorcentaje { get; set; }
        public Nullable<double> DescuentoImporte { get; set; }
        public Nullable<System.DateTime> FechaEntrega { get; set; }
        public Nullable<double> Subtotal { get; set; }
        public Nullable<double> Impuestos { get; set; }
        public Nullable<double> Retenciones { get; set; }
        public Nullable<double> Total { get; set; }
        public string ModuloOrigen { get; set; }
        public Nullable<long> CondicionesPagoId { get; set; }
        public Nullable<System.DateTime> FechaEnvio { get; set; }
        public string Enviado { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComprasDocsDetalles> ComprasDocsDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComprasDocsRelacionesl> ComprasDocsRelaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComprasDocsRelacionesl> ComprasDocsRelaciones1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ComprasDocsImpuestos> ComprasDocsImpuestos { get; set; }
        public virtual Almacenes Almacenes { get; set; }
        public virtual CondicionesPago CondicionesPago { get; set; }
        public virtual Departamentos Departamentos { get; set; }
        public virtual Monedas Monedas { get; set; }
        public virtual Proveedores Proveedores { get; set; }
        public virtual Responsables Responsables { get; set; }

        public override string Validar(string propiedad)
        {
       /*     if (propiedad == BindableBase.GetPropertyName(() => ComprasDocsDetalles))
            {
                if (ComprasDocsDetalles.Count == 0)
                return "No ha realizado ningun movimiento, no es posible guardar";
            if (ComprasDocsDetalles.Where(c => c.CantidadCompra == 0).Count() > 0)
                return "No se permite guardar con componentes en cantidad cero";
            foreach (ComprasDocsDetalles detalle in ComprasDocsDetalles)
            {

                string error = detalle.Errores();
                if (!string.IsNullOrEmpty(error))
                    return error;

            }
            }*/
            return null;
        }
    }
}

using CaficaERP.Model.Compras;
using CaficaERP.Model.Inventarios;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Generales
{
    public partial class Impuestos :BaseModel
    {
        public Impuestos()
        {
            this.ComponentesImpuestos = new HashSet<ComponentesImpuestos>();
            this.ComprasDocsImpuestos = new HashSet<ComprasDocsImpuestos>();
            this.ImpuestosGravados = new HashSet<ImpuestosGravados>();
            this.ImpuestosGravados1 = new System.Collections.ObjectModel.ObservableCollection<ImpuestosGravados>();
          
        }

      
        public string Nombre { get; set; }
        public string Naturaleza { get; set; }
        public string Tipo { get; set; }
        public string TipoCalculo { get; set; }
        public Nullable<double> Porcentaje { get; set; }
        public Nullable<double> CuotaUnidad { get; set; }
        public Nullable<long> UnidadId { get; set; }
        public string Predeterminado { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComponentesImpuestos> ComponentesImpuestos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComprasDocsImpuestos> ComprasDocsImpuestos { get; set; }
        public virtual Unidades Unidades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImpuestosGravados> ImpuestosGravados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ImpuestosGravados> ImpuestosGravados1 { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => ImpuestosGravados1))
            {
                if (ImpuestosGravados1 != null)
                {
                    foreach (ImpuestosGravados detalle in ImpuestosGravados1)
                    {
                        if(detalle.ImpuestoActual==null)
                               detalle.ImpuestoActual = this;
                      
                        string error = detalle.Errores();
                        if (!string.IsNullOrEmpty(error))
                            return error;

                       
                    }
                }


            }
            return null;
        }
    }
}

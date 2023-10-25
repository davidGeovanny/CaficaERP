using CaficaERP.Model.Compras;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class LotesSeries : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LotesSeries()
        {
            this.ComprasDocsLotesSeries = new ObservableCollection<ComprasDocsLotesSeries>();
            this.ExistenciasLotesSeries = new ObservableCollection<ExistenciasLotesSeries>();
            this.InventariosESLotesSeries = new ObservableCollection<InventariosESLotesSeries>();
            this.InventariosFisicosLotesSeries = new ObservableCollection<InventariosFisicosLotesSeries>();
            this.ResguardosLotesSeries = new ObservableCollection<ResguardosLotesSeries>();
        }

        public long ComponenteId { get; set; }
        public string Lote { get; set; }
        private Nullable<System.DateTime> _FechaCaducidad;
        public string NumeroSerie { get; set; }
        public string UsuarioCreo { get; set; }
        private Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Componentes Componentes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComprasDocsLotesSeries> ComprasDocsLotesSeries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ExistenciasLotesSeries> ExistenciasLotesSeries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosESLotesSeries> InventariosESLotesSeries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<InventariosFisicosLotesSeries> InventariosFisicosLotesSeries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ResguardosLotesSeries> ResguardosLotesSeries { get; set; }

        public string SerieLote
        {
            get
            {
                string SerieLote = NumeroSerie == null ? Lote : NumeroSerie;
                return SerieLote;
            }
            set
            {
                if (Componentes.TipoSeguimiento == "LOTES")
                    Lote = value;
                else
                    NumeroSerie = value;
            }
        }

        public DateTime? FechaCaducidad
        {
            get
            {
                return _FechaCaducidad;
            }

            set
            {
                //if (Componentes.TipoSeguimiento == "LOTES")
                    _FechaCaducidad = value;
             //   else
              //      _FechaCaducidad = null;
            }
        }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

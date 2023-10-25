using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class TiposComponentes : BaseModel
    {
        public TiposComponentes()
        {
            this.Almacenes = new System.Collections.ObjectModel.ObservableCollection<Almacenes>();
            this.Componentes = new System.Collections.ObjectModel.ObservableCollection<Componentes>();
            this.GruposComponentes = new System.Collections.ObjectModel.ObservableCollection<GruposComponentes>();
        }

        public string Nombre { get; set; }
        public string Prefijo { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<Almacenes> Almacenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<Componentes> Componentes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<GruposComponentes> GruposComponentes { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

using CaficaERP.Model.Generales;
using DevExpress.Mvvm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class GruposComponentes : BaseModel
    {
        public GruposComponentes()
        {
            this.AlmacenesGruposComponentes = new System.Collections.ObjectModel.ObservableCollection<AlmacenesGruposComponentes>();
            this.Componentes = new ObservableCollection<Componentes>();
            this.SubgruposComponentes = new System.Collections.ObjectModel.ObservableCollection<SubgruposComponentes>();
        }
        public string Nombre { get; set; }
        public long TipoComponenteId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<AlmacenesGruposComponentes> AlmacenesGruposComponentes { get; set; }
        public virtual ObservableCollection<Componentes> Componentes { get; set; }
        public virtual TiposComponentes TiposComponentes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<SubgruposComponentes> SubgruposComponentes { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                {
                    return "El campo nombre del grupo es obligatorio";
                    
                }                  
            }
            if (propiedad == BindableBase.GetPropertyName(() => TipoComponenteId))
            {
                if (TipoComponenteId == 0)
                    return "El campo tipo de componente es obligatorio";
            }
            return null;
        }
    }
}

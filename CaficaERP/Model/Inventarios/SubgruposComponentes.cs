using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class SubgruposComponentes : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubgruposComponentes()
        {
            this.Componentes = new System.Collections.ObjectModel.ObservableCollection<Componentes>();
        }
        public string Nombre { get; set; }
        public long GrupoComponentesId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual GruposComponentes GruposComponentes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<Componentes> Componentes { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                {
                    return "El campo nombre  es obligatorio";
                    
                }
                else if (Nombre.Length < 3)
                    return "El subgrupo debe de contener al menos 3 caracteres";
            
            }
            if (propiedad == BindableBase.GetPropertyName(() => GrupoComponentesId))
            {
                if (GrupoComponentesId == 0)
                    return "El campo grupo de componente es obligatorio";

          

            }
            return null;
        }
    }
}

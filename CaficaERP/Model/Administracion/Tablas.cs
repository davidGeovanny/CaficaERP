using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CaficaERP.Model.Administracion
{
   public class Tablas : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tablas()
        {
            this.VistasTablas = new System.Collections.ObjectModel.ObservableCollection<VistasTablas>();
        }
        public string Nombre { get; set; }
        public string UsuarioCreo { get; set; }
        public bool isChecked { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual System.Collections.ObjectModel.ObservableCollection<VistasTablas> VistasTablas { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El campo Nombre es Obligatorio";
                if (Nombre.Length > 45)
                    return "El campo contiene demasiados Caracteres";

                return null;
            }
            return null;
        }
    }
}

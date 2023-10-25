using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace CaficaERP.Model.Administracion
{
    public class Modulos : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modulos()
        {
            this.GruposVistas = new ObservableCollection<GruposVistas>();
            this.VistasGruposVistas = new ObservableCollection<VistasGruposVistas>();
        }

        public string Nombre { get; set; }
        public long SistemaId { get; set; }
        public Nullable<sbyte> Orden { get; set; }
        public string UsuarioCreo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public System.DateTime FechaUltimaModificacion { get; set; }

        public virtual Sistemas Sistemas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<GruposVistas> GruposVistas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<VistasGruposVistas> VistasGruposVistas { get; set; }

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
            if (propiedad == BindableBase.GetPropertyName(() => SistemaId))
            {
                if (SistemaId == 0)
                    return "No ha escogido un Sistema";

                return null;

            }
            return null;
        }
    }
}

using CaficaERP.Model;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Administracion
{
    public class AccionesVistas : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccionesVistas()
        {
            this.RolesAcciones = new ObservableCollection<RolesAcciones>();
        }
        public string Nombre { get; set; }
        public long VistaId { get; set; }
        public long GrupoVistaId { get; set; }
        public long ModuloId { get; set; }
        public long SistemaId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public string Tipo { get; set; }

        public virtual GruposVistas GruposVistas { get; set; }
        public virtual Modulos Modulos { get; set; }
        public virtual Sistemas Sistemas { get; set; }
        public virtual Vistas Vistas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<RolesAcciones> RolesAcciones { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El campo Nombre es obligatorio";
                if (Nombre.Length >= 45)
                    return "El campo Nombre sobre pasa los caracteres permitidos";
                return null;
            }
            if (propiedad == BindableBase.GetPropertyName(() => VistaId))
            {
                if (VistaId == 0)
                    return "El campo Vista es obligatorio";
                return null;
            }
            if (propiedad == BindableBase.GetPropertyName(() => Tipo))
            {
                if (string.IsNullOrEmpty(Tipo))
                    return "El campo Tipo es obligatorio";
                return null;
            }
            return null;
        }
    }
}

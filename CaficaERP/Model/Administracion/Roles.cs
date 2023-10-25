using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Administracion
{
    public class Roles :BaseModel
    {
        public Roles()
        {
            this.BDEmpresasRoles = new System.Collections.ObjectModel.ObservableCollection<BDEmpresasRoles>();
            this.RolesAcciones = new System.Collections.ObjectModel.ObservableCollection<RolesAcciones>();
            this.SistemasRoles = new System.Collections.ObjectModel.ObservableCollection<SistemasRoles>();
            this.UsuariosRoles = new ObservableCollection<UsuariosRoles>();
        }
        public string Nombre { get; set; }
        public string Administrador { get; set; }
        public string UsuarioCreo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public System.DateTime FechaUltimaModificacion { get; set; }

        
        public virtual System.Collections.ObjectModel.ObservableCollection<BDEmpresasRoles> BDEmpresasRoles { get; set; }
        
        public virtual System.Collections.ObjectModel.ObservableCollection<RolesAcciones> RolesAcciones { get; set; }
        
        public virtual System.Collections.ObjectModel.ObservableCollection<SistemasRoles> SistemasRoles { get; set; }
        public virtual ObservableCollection<UsuariosRoles> UsuariosRoles { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El campo nombre del rol es obligatorio";
                return null;
            }
            if (propiedad == BindableBase.GetPropertyName(() => BDEmpresasRoles))
            {
                if (BDEmpresasRoles.ToList().Count==0 || BDEmpresasRoles==null)
                    return "Al menos debes seleccionar una empresa";
                return null;
            }
            if (propiedad == BindableBase.GetPropertyName(() => RolesAcciones))
            {
                if (RolesAcciones.ToList().Count == 0 || RolesAcciones == null)
                    return "Al menos debes seleccionar un permiso en la pestaña de permisos";
                return null;
            }
            return null;
        }
    }
}




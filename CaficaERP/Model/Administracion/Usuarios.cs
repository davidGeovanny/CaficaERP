using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CaficaERP.Model.Administracion
{
    public class Usuarios : BaseModel
    {
        public Usuarios()
        {
          //  this.BanEliminar = 0;
            this.UsuariosRoles = new System.Collections.ObjectModel.ObservableCollection<UsuariosRoles>();
        }
        public string NombreCompleto { get; set; }
        public string Nombre { get; set; }
        public string  Contrasena { get; set; }
        public string Status { get; set; }
        public string ClaveApp { get; set; }
        public string UsuarioCreo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public System.DateTime FechaUltimaModificacion { get; set; }


        public virtual System.Collections.ObjectModel.ObservableCollection<UsuariosRoles> UsuariosRoles { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => NombreCompleto))
            {
               if (string.IsNullOrEmpty(NombreCompleto))
                    return "El campo nombre completo es obligatorio";
                
            }
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre)) { 
                    return "El campo nombre del usuario es obligatorio";
                
                }
                else if (Nombre.Length<5)
                    return "El usuario debe de contener al menos 5 caracteres";
               
            }
            if (propiedad == BindableBase.GetPropertyName(() => Status))
            {
                if (string.IsNullOrEmpty(Status))
                    return "El campo status  es obligatorio";
               

            }
            if (propiedad == BindableBase.GetPropertyName(() => UsuariosRoles))
            {
                if(UsuariosRoles.Count==0)
                    return "Debes de agregar al menos un rol al usuario";
               
            }
            if (propiedad == BindableBase.GetPropertyName(() => Contrasena))
            {
                if(this.Id==0)
                {
                    if (string.IsNullOrEmpty(Contrasena)) { 
                        return "El campo contraseña es obligatorio";
                  
                       
                    }
                    else if (Contrasena.Length < 6)
                        return "La contraseña debe tener al menos 6 caracteres";
                   
                }
                if (!string.IsNullOrEmpty(Contrasena) &&Contrasena.Length < 6)
                    return "La contraseña debe tener al menos 6 caracteres";
               

            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace CaficaERP.Model.Administracion
{
    public class Sistemas : BaseModel
    {
        public Sistemas()
        {
            this.GruposVistas = new ObservableCollection<GruposVistas>();
            this.Modulos = new ObservableCollection<Modulos>();
            this.SistemasRoles = new ObservableCollection<SistemasRoles>();
            this.VistasGruposVistas = new ObservableCollection<VistasGruposVistas>();
        }
        public string Nombre { get; set; }
        public string UsuarioCreo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public System.DateTime FechaUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<GruposVistas> GruposVistas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Modulos> Modulos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<SistemasRoles> SistemasRoles { get; set; }
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
                if (!Regex.IsMatch(Nombre, @"^[a-zA-Z]+$"))
                    return "El campo solo debe contener Letras";

                return null;
            }
            return null;
        }
    }
}

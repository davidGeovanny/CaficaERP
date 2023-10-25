using CaficaERP.Model.Compras;
using CaficaERP.Model.Inventarios;
using CaficaERP.Model.Ventas.Monedero;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CaficaERP.Model.Generales
{
    public class Paises :BaseModel
    {
        public Paises()
        {
            this.Almacenes = new ObservableCollection<Almacenes>();
            this.Ciudades = new ObservableCollection<Ciudades>();
            this.CodigosPostales = new ObservableCollection<CodigosPostales>();
            this.Colonias = new ObservableCollection<Colonias>();
            this.Estados = new ObservableCollection<Estados>();
            this.Municipios = new ObservableCollection<Municipios>();
            this.ProveedoresContactos = new ObservableCollection<ProveedoresContactos>();
            this.ProveedoresDirecciones = new ObservableCollection<ProveedoresDirecciones>();
            this.UsuariosMonedero = new ObservableCollection<UsuariosMonedero>();
        }

        public string Nombre { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Almacenes> Almacenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Ciudades> Ciudades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<CodigosPostales> CodigosPostales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Colonias> Colonias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Estados> Estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Municipios> Municipios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ProveedoresContactos> ProveedoresContactos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ProveedoresDirecciones> ProveedoresDirecciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<UsuariosMonedero> UsuariosMonedero { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El campo Nombre es Obligatorio";
                if (Nombre.Length > 45)
                    return "El campo contiene demasiados Caracteres";
            }


            return null;
        }
    }
}

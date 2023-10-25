using CaficaERP.Model.Compras;
using CaficaERP.Model.Inventarios;
using CaficaERP.Model.Ventas.Monedero;
using DevExpress.Mvvm;
using System;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Generales
{
    public class Ciudades :BaseModel
    {
        public Ciudades()
        {
            this.Almacenes = new ObservableCollection<Almacenes>();
            this.CodigosPostales = new ObservableCollection<CodigosPostales>();
            this.Colonias = new ObservableCollection<Colonias>();
            this.ProveedoresContactos = new ObservableCollection<ProveedoresContactos>();
            this.ProveedoresDirecciones = new ObservableCollection<ProveedoresDirecciones>();
            this.UsuariosMonedero = new ObservableCollection<UsuariosMonedero>();
        }
        public string Nombre { get; set; }
        public long MunicipioId { get; set; }
        public long EstadoId { get; set; }
        public long PaisId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Estados Estados { get; set; }
        public virtual Paises Paises { get; set; }
        public virtual Municipios Municipios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Almacenes> Almacenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<CodigosPostales> CodigosPostales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Colonias> Colonias { get; set; }
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
                //  if (!Regex.IsMatch(Nombre, @"^[a-zA-Z]+$"))
                //      return "El campo solo debe contener Letras";

                return null;
            }
            if (propiedad == BindableBase.GetPropertyName(() => PaisId))
            {
                if (PaisId == 0)
                    return "El campo País es Obligatorio";

                return null;

            }
            if (propiedad == BindableBase.GetPropertyName(() => EstadoId))
            {
                if (EstadoId == 0)
                    return "El campo Estado es Obligatorio";

                return null;

            }
            if (propiedad == BindableBase.GetPropertyName(() => MunicipioId))
            {
                if (EstadoId == 0)
                    return "El campo Municipio es Obligatorio";

                return null;

            }
            return null;
        }
    }
}

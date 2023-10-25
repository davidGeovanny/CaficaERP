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
    public class Colonias :BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Colonias()
        {
            this.Almacenes = new ObservableCollection<Almacenes>();
            this.ProveedoresContactos = new ObservableCollection<ProveedoresContactos>();
            this.ProveedoresDirecciones = new ObservableCollection<ProveedoresDirecciones>();
            this.UsuariosMonedero = new ObservableCollection<UsuariosMonedero>();
        }
        public string Nombre { get; set; }
        public long CodigoPostalId { get; set; }
        public long CiudadId { get; set; }
        public long MunicipioId { get; set; }
        public long EstadoId { get; set; }
        public long PaisId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Ciudades Ciudades { get; set; }
        public virtual CodigosPostales CodigosPostales { get; set; }
        public virtual Municipios Municipios { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual Paises Paises { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Almacenes> Almacenes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ProveedoresContactos> ProveedoresContactos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ProveedoresDirecciones> ProveedoresDirecciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<UsuariosMonedero> UsuariosMonedero { get; set; }

        //Propiedad para unir toda la direccion
        public string Direccion
        {
            get
            {
              
                return Nombre + " " + CodigosPostales?.Codigo.ToString() ?? "" + " " + Ciudades?.Nombre.ToString() ?? ""  + "," + Municipios?.Nombre.ToString() ?? "" + "," + Estados?.Nombre.ToString() ?? "" + "," + Paises?.Nombre.ToString() ?? "";
            }
            set
            {
                value=null;
            }
        }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El campo nombre esta vacio.";
                return null;
            }
          


            return null;
        }
    }
}

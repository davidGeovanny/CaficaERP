using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Ventas.Monedero
{
    public class UsuariosMonedero : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsuariosMonedero()
        {
            this.MovimientosMonedero = new ObservableCollection<MovimientosMonedero>();
            this.SaldosMonedero = new ObservableCollection<SaldosMonedero>();
            this.SolicitudesCanjeMonedero = new ObservableCollection<SolicitudesCanjeMonedero>();
            this.SolicitudesCanjeMonederoDetalles = new ObservableCollection<SolicitudesCanjeMonederoDetalles>();
        }

        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public Nullable<long> ColoniaId { get; set; }
        public Nullable<long> CodigoPostalId { get; set; }
        public Nullable<long> CiudadId { get; set; }
        public Nullable<long> MunicipioId { get; set; }
        public Nullable<long> EstadoId { get; set; }
        public Nullable<long> PaisId { get; set; }
        public string Sexo { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Activo { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Ciudades Ciudades { get; set; }
        public virtual CodigosPostales CodigosPostales { get; set; }
        public virtual Colonias Colonias { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual Municipios Municipios { get; set; }
        public virtual Paises Paises { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<SaldosMonedero> SaldosMonedero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<SolicitudesCanjeMonedero> SolicitudesCanjeMonedero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<SolicitudesCanjeMonederoDetalles> SolicitudesCanjeMonederoDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<MovimientosMonedero> MovimientosMonedero { get; set; }

        public override string Validar(string propiedad)
        {

            return null;
        }
    }
}

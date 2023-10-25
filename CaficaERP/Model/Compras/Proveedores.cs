using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Compras
{
    public class Proveedores : BaseModel
    {

        public Proveedores()
        {
            this.ProveedoresDirecciones = new System.Collections.ObjectModel.ObservableCollection<ProveedoresDirecciones>();
            this.ProveedoresContactos = new System.Collections.ObjectModel.ObservableCollection<ProveedoresContactos>();
        }

        public string Nombre { get; set; }
        public string NombreComercial { get; set; }
        public string RFC { get; set; }
        public Nullable<long> GruposProveedoresId { get; set; }
        public Nullable<long> GiroId { get; set; }
        public string Email { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Activo { get; set; }
        public Nullable<long> MonedaId { get; set; }
        public Nullable<long> CondicionesPagoId { get; set; }
        public Nullable<double> LimiteCredito { get; set; }
        public string Celular { get; set; }
        public string Notas { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual CondicionesPago CondicionesPago { get; set; }
        public virtual Giros Giros { get; set; }
        public virtual GrupoProveedores GrupoProveedores { get; set; }
        
        public virtual System.Collections.ObjectModel.ObservableCollection<ProveedoresDirecciones> ProveedoresDirecciones { get; set; }
        
        public virtual System.Collections.ObjectModel.ObservableCollection<ProveedoresContactos> ProveedoresContactos { get; set; }
        public virtual Monedas Monedas { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

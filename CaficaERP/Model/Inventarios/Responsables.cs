using CaficaERP.Model.Compras;
using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class Responsables : BaseModel
    {
        public Responsables()
        {
            this.ComprasDocs = new ObservableCollection<ComprasDocs>();
            this.Resguardos = new ObservableCollection<Resguardos>();
            this.ResguardosLotesSeries = new ObservableCollection<ResguardosLotesSeries>();
        }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public string CorreoElectronico { get; set; }
        public Nullable<long> PuestoId { get; set; }
        public Nullable<long> AreaId { get; set; }
        public Nullable<long> DepartamentoId { get; set; }

        public virtual Areas Areas { get; set; }
        public virtual ObservableCollection<ComprasDocs> ComprasDocs { get; set; }
        public virtual Departamentos Departamentos { get; set; }
        public virtual Puestos Puestos { get; set; }
        public virtual ObservableCollection<Resguardos> Resguardos { get; set; }
        public virtual ObservableCollection<ResguardosLotesSeries> ResguardosLotesSeries { get; set; }

        public string NombreCompleto
        {
            get
            {
                return Nombre +" " + Paterno + " " + Materno;
            }
            set
            {
                value = null;
            }
        }
        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

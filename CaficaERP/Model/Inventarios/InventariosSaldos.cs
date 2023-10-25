using System;

namespace CaficaERP.Model.Inventarios
{
    public class InventariosSaldos : BaseModel
    {
        public long ComponenteId { get; set; }
        public long AlmacenId { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int UltimoDia { get; set; }
        public double EntradasUnidades { get; set; }
        public double SalidasUnidades { get; set; }
        public double EntradasCosto { get; set; }
        public double SalidasCosto { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Almacenes Almacenes { get; set; }
        public virtual Componentes Componentes { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}
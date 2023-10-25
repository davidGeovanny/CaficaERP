using System;

namespace CaficaERP.Model.Inventarios
{
    public class InventariosCostos : BaseModel
    {
        public long ComponenteId { get; set; }
        public long AlmacenId { get; set; }
        public System.DateTime Fecha { get; set; }
        public double Existencia { get; set; }
        public double CostoTotal { get; set; }
        public string Activo { get; set; }
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
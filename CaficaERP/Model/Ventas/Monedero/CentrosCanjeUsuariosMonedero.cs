using System;

namespace CaficaERP.Model.Ventas.Monedero
{
    public class CentrosCanjeUsuariosMonedero : BaseModel
    {
        public long UsuarioId { get; set; }
        public long CentroCanjeMonederoId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual CentrosCanjeMonedero CentrosCanjeMonedero { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}
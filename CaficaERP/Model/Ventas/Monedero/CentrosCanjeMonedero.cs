using CaficaERP.Model.Inventarios;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Ventas.Monedero
{
   public class CentrosCanjeMonedero : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CentrosCanjeMonedero()
        {
            this.CentrosCanjeUsuariosMonedero = new ObservableCollection<CentrosCanjeUsuariosMonedero>();
            this.MovimientosMonedero = new ObservableCollection<MovimientosMonedero>();
        }
        public string Nombre { get; set; }
        public long AlmacenId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Almacenes Almacenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<CentrosCanjeUsuariosMonedero> CentrosCanjeUsuariosMonedero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<MovimientosMonedero> MovimientosMonedero { get; set; }

        public override string Validar(string propiedad)
        {
            if(propiedad == BindableBase.GetPropertyName(() => Nombre))
            { 
                if (string.IsNullOrEmpty(Nombre))
                {
                    return "El campo Nombre es obligatorio";
                }
            }
            if (propiedad == BindableBase.GetPropertyName(() => AlmacenId))
            {
                if (AlmacenId == 0)
                {
                    return "El campo Almacen es obligatorio";
                }
            }
            return null;
        }
    }
}

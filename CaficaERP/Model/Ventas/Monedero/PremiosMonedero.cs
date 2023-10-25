using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Ventas.Monedero
{
    public class PremiosMonedero: BaseModel
    {

        public PremiosMonedero()
        {
            this.PremiosMonederoDetalles = new ObservableCollection<PremiosMonederoDetalles>();
            this.MovimientosMonederoDetalles = new ObservableCollection<MovimientosMonederoDetalles>();
            this.SolicitudesCanjeMonederoDetalles = new ObservableCollection<SolicitudesCanjeMonederoDetalles>();
        }

        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaInicia { get; set; }
        public Nullable<System.DateTime> FechaTermina { get; set; }
        public double PuntosCanje { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public string ImagenBase64 { get; set; }

        public virtual ObservableCollection<PremiosMonederoDetalles> PremiosMonederoDetalles { get; set; }
        public virtual ObservableCollection<MovimientosMonederoDetalles> MovimientosMonederoDetalles { get; set; }
        public virtual ObservableCollection<SolicitudesCanjeMonederoDetalles> SolicitudesCanjeMonederoDetalles { get; set; }

        public byte[] Imagen
        {
            get
            {
                if (this.ImagenBase64 != null)
                {
                    return Convert.FromBase64String(this.ImagenBase64);
                }
                else
                    return null;

            }
            set
            {
                value = null;
            }
        }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => FechaTermina))
            {
                if (FechaTermina<FechaInicia)
                    return "La fecha termina debe ser mayor que la fecha inicia.";
            }

            if (propiedad == BindableBase.GetPropertyName(() => FechaInicia))
            {
                if (FechaInicia > FechaInicia)
                    return "La fecha inicia debe ser menor que la fecha termina.";
            }

            if(propiedad==BindableBase.GetPropertyName(()=>PremiosMonederoDetalles))
            {
                if (PremiosMonederoDetalles.Count == 0)
                    return "Debe contener al menos un componente.";
            }
            return null;
        }

    }
}

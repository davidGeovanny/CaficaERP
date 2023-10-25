using DevExpress.Mvvm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class ResguardosLotesSeries : BaseModel
    {
        public long ResguardosDetalleId { get; set; }
        public Nullable<long> ComponenteId { get; set; }
        public Nullable<long> ResponsableId { get; set; }
        public Nullable<long> ResguardoLotesSeriesOrigenId { get; set; }
        public string TipoDocumento { get; set; }
        public Nullable<long> LotesSeriesId { get; set; }
        public string EstadoDevolucion { get; set; }
        public string Cancelado { get; set; } = "NO";
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Componentes Componentes { get; set; }
        public virtual LotesSeries LotesSeries { get; set; }
        public virtual Responsables Responsables { get; set; }
        public virtual Resguardos Resguardos { get; set; }
        public virtual ResguardosDetalles ResguardosDetalles { get; set; }
        [JsonIgnore]
        public virtual ResguardosDetalles Detalle { get; set; }
        //Esta lista de objetos se utiliza para cargar las series disponibles del componente
        [JsonIgnore]
        public virtual System.Collections.ObjectModel.ObservableCollection<LotesSeries> LstLotesSeries { get; set; }

        public ResguardosLotesSeries()
        {
            //Esta lista de objetos se utiliza para cargar las series disponibles del componente
            this.LstLotesSeries = new System.Collections.ObjectModel.ObservableCollection<LotesSeries>();
        }

        public string Seguimiento
        {
            get
            {
                return "Serie:";
            }
        }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => LotesSeries))
            {
                if (Detalle.ResguardosLotesSeries.Where(c => c.LotesSeries != null && c.LotesSeries.NumeroSerie != "" && c.LotesSeries.NumeroSerie != "SIN SERIE").Where(c => LotesSeries!= null && c.LotesSeries.NumeroSerie == LotesSeries.NumeroSerie).Count() > 1)
                    return "El numero de serie " + LotesSeries.SerieLote + " que intenta registrar, ya se encuentra seleccionado en el componente " + Detalle.Componentes.Nombre;
            }
            if (propiedad == BindableBase.GetPropertyName(() => EstadoDevolucion))
            {
                if (TipoDocumento == "DEVOLUCION" && EstadoDevolucion == null)
                    return "Es obligatorio seleccionar el estatus de la devolución";
            }
            return null;
        }
    }
}

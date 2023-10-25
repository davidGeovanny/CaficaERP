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
    public class ResguardosDetalles : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResguardosDetalles()
        {
            this.ResguardosLotesSeries = new System.Collections.ObjectModel.ObservableCollection<ResguardosLotesSeries>();
            //Esta lista de objetos se utiliza para cargar las series disponibles del componente
            this.LstLotesSeries = new System.Collections.ObjectModel.ObservableCollection<LotesSeries>();
        }

        public long ResguardoId { get; set; }
        public string TipoDocumento { get; set; }
        public Nullable<long> ResponsableId { get; set; }
        public long ComponenteId { get; set; }
        public double Cantidad { get; set; }
        public long ComponentesAlmacenesId { get; set; }
        public string Notas { get; set; }
        public Nullable<long> AlmacenId { get; set; }
        public string Cancelado { get; set; } = "NO";
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }


        
        public virtual Almacenes Almacenes { get; set; }
        public virtual ComponentesAlmacenes ComponentesAlmacenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ResguardosLotesSeries> ResguardosLotesSeries { get; set; }
        public virtual Componentes Componentes { get; set; }
        public virtual Resguardos Resguardos { get; set; }
        //Esta lista de objetos se utilizr para cargar las series disponibles del componente
        [JsonIgnore]
        public virtual System.Collections.ObjectModel.ObservableCollection<LotesSeries> LstLotesSeries { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Cantidad))
            {
                //Valida que el numero de hijos no sea menor al padre
                if (Componentes.TipoSeguimiento == "NÚMERO DE SERIE" && Cantidad < ResguardosLotesSeries.Count)
                    return "No puede escribir un valor menor a la existencia, elimine manualmente los componentes que no necesite.";
                return null;
            }
            if (propiedad == BindableBase.GetPropertyName(() => ResguardosLotesSeries))
            {
                foreach (ResguardosLotesSeries detalle in ResguardosLotesSeries)
                {
                    if (detalle.Detalle == null)
                        detalle.Detalle = this;
                }
            }
            return null;
        }
    }
}

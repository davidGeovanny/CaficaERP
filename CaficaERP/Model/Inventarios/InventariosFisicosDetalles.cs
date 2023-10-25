using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class InventariosFisicosDetalles : BaseModel
    {
       
        public InventariosFisicosDetalles()
        {
            this.InventariosFisicosLotesSeries = new System.Collections.ObjectModel.ObservableCollection<InventariosFisicosLotesSeries>();
        }

       
        public long InventariosFisicosId { get; set; }
        public Nullable<long> InventariosESDetalleId { get; set; }
        public long ComponenteId { get; set; }
        public double ExistenciaFisica { get; set; }
        public Nullable<double> ExistenciaTeorica { get; set; }
        public Nullable<double> Diferencia { get; set; }
        public long ComponentesAlmacenesId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual ComponentesAlmacenes ComponentesAlmacenes { get; set; }
        public virtual InventariosESDetalles InventariosESDetalles { get; set; }
        public virtual Componentes Componentes { get; set; }
        public virtual InventariosFisicos InventariosFisicos { get; set; }
        public virtual System.Collections.ObjectModel.ObservableCollection<InventariosFisicosLotesSeries> InventariosFisicosLotesSeries { get; set; }
        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => ExistenciaFisica))
            {
                //Numero de serie solo permite valores numericos
                if(Componentes.TipoSeguimiento == "NÚMERO DE SERIE" && ExistenciaFisica.ToString().Contains("."))
                    return "Los componetes con tipo de seguimiento NUMERO DE SERIE solo permiten cantidades enteras";
                //Valida que el numero de hijos no sea menor al padre
                if(Componentes.TipoSeguimiento== "NÚMERO DE SERIE" && ExistenciaFisica < InventariosFisicosLotesSeries.Count)
                    return "No puede escribir un valor menor a la existencia, elimine manualmente los componentes que no necesite.";
                //Valida que el numero de hijo no sea menos al padre
                if(Componentes.TipoSeguimiento == "LOTES" && InventariosFisicosLotesSeries.Sum(v => v.Cantidad) > ExistenciaFisica)
                    return "La existencia de los lotes no puede ser mayor a la de la existencia principal.";
                return null;
            }
            if (propiedad == BindableBase.GetPropertyName(() => InventariosFisicosLotesSeries))
            {
                foreach(InventariosFisicosLotesSeries detalle in InventariosFisicosLotesSeries)
                {
                    if (detalle.Detalle == null)
                        detalle.Detalle = this;
                }
            }
            return null;
        }
    }
}

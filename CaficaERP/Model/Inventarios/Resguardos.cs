using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class Resguardos : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resguardos()
        {
            this.ResguardosDetalles = new System.Collections.ObjectModel.ObservableCollection<ResguardosDetalles>();
            this.ResguardosLotesSeries = new ObservableCollection<ResguardosLotesSeries>();
        }

        public long AlmacenId { get; set; }
        public System.DateTime Fecha { get; set; }
        public string TipoDocumento { get; set; }
        public string Descripcion { get; set; }
        public Nullable<long> ResponsableId { get; set; }
        public Nullable<long> InventariosESId { get; set; }
        public string Cancelado { get; set; } = "NO";
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Almacenes Almacenes { get; set; }
        public virtual Responsables Responsables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ResguardosDetalles> ResguardosDetalles { get; set; }
        public virtual ObservableCollection<ResguardosLotesSeries> ResguardosLotesSeries { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => ResguardosDetalles))
            {
                if (ResguardosDetalles.Count == 0)
                    return "No ha realizado ningun movimiento, no es posible guardar";
                if (ResguardosDetalles.Where( c => c.Cantidad==0).Count() > 0)
                    return "No se permite generar resguardos con componentes en cantidad 0";
                foreach (ResguardosDetalles detalle in ResguardosDetalles)
                {
                    /*if (detalle.Componentes.TipoSeguimiento == "NÚMERO DE SERIE")
                    {
                        if (detalle.ResguardosLotesSeries.Sum(c => c.Cantidad) != detalle.Cantidad)
                            return "La existencia fisica del componete " + detalle.Componentes.Nombre + " no coincide con la cantidad de sus hijos";
                    }*/
                    string error = detalle.Errores();
                    if (!string.IsNullOrEmpty(error))
                        return error;
                    foreach (ResguardosLotesSeries detalleloteserie in detalle.ResguardosLotesSeries)
                    {
                        string error_loteseries = detalleloteserie.Errores();
                        if (!string.IsNullOrEmpty(error_loteseries))
                            return error_loteseries;
                    }
                }
            }
            if (propiedad == BindableBase.GetPropertyName(() => ResponsableId))
            {
                if (ResponsableId == 0 || ResponsableId == null)
                    return "Para poder continuar, es necesario seleccionar un responsable";
            }
            if (propiedad == BindableBase.GetPropertyName(() => AlmacenId))
            {
                if (AlmacenId == 0)
                    return "Para poder continuar, es necesario seleccionar un almacen";
            }
            return null;
        }
    }
}

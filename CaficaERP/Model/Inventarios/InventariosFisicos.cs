using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class InventariosFisicos : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventariosFisicos()
        {
            this.InventariosFisicosDetalles = new System.Collections.ObjectModel.ObservableCollection<InventariosFisicosDetalles>();
        }
        public long AlmacenId { get; set; }
        public long Folio { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public Nullable<long> InventariosESEntradaId { get; set; }
        public Nullable<long> InventariosESSalidaId { get; set; }
        public Nullable<System.DateTime> FechaHoraCancelacion { get; set; }
        public Nullable<System.DateTime> FechaHoraAplicacion { get; set; }
        public string UsuarioCancelo { get; set; }
        public string UsuarioAplico { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Almacenes Almacenes { get; set; }
        public virtual InventariosES InventariosES { get; set; }
        public virtual InventariosES InventariosES1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<InventariosFisicosDetalles> InventariosFisicosDetalles { get; set; }
        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => AlmacenId))
            {
                if (AlmacenId == 0)
                    return "Para poder continuar, es necesario seleccionar un almacen";
            }
            if (propiedad == BindableBase.GetPropertyName(() => InventariosFisicosDetalles))
            {
                if(InventariosFisicosDetalles.Count == 0)
                    return "No ha realizado ningun movimiento, no es posible guardar";
                foreach (InventariosFisicosDetalles detalle in InventariosFisicosDetalles)
                {
                    if(detalle.Componentes.TipoSeguimiento=="LOTES" || detalle.Componentes.TipoSeguimiento == "NÚMERO DE SERIE")
                    { 
                        if(detalle.InventariosFisicosLotesSeries.Sum(c => c.Cantidad) != detalle.ExistenciaFisica)
                            return "La existencia fisica del componete " + detalle.Componentes.Nombre + " no coincide con la cantidad de sus hijos";
                        if(detalle.InventariosFisicosLotesSeries.Where(c => c.Cantidad==0).Count() > 0)
                            return "El componente " + detalle.Componentes.Nombre + " tiene hijos con cantidad cero, elimine estos para poder continuar";
                    }
                    string error = detalle.Errores();
                    if (!string.IsNullOrEmpty(error))
                        return error;
                    foreach (InventariosFisicosLotesSeries detalleloteserie in detalle.InventariosFisicosLotesSeries)
                    {
                        string error_loteseries = detalleloteserie.Errores();
                        if (!string.IsNullOrEmpty(error_loteseries))
                            return error_loteseries;
                    }
                }
            }
            return null;
        }
    }
}

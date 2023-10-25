using System;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Inventarios
{
    public class InventariosFisicosLotesSeries : BaseModel
    {
        public long InventariosFisicosDetalleId { get; set; }
        public double Cantidad { get; set; }
        public Nullable<long> LotesSeriesId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public virtual LotesSeries LotesSeries { get; set; }
        public virtual InventariosFisicosDetalles InventariosFisicosDetalles { get; set; }
        public virtual InventariosFisicosDetalles Detalle { get; set; }

        public string  Seguimiento
        {
            get
            {
                if (LotesSeries.Componentes != null)
                    return LotesSeries.Componentes.TipoSeguimiento == "LOTES" ? "Lote:" : "Serie:";
                else
                    return "";
            }
        }
        public string Caducidad
        {
            get
            {
                if (LotesSeries.Componentes != null)
                    return LotesSeries.Componentes.TipoSeguimiento == "LOTES" ? "Caducidad:" : "";
                else
                    return "";
            }
        }
        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Cantidad))
            {
                if (Seguimiento=="Serie:" && Cantidad != 1)
                    return "La cantidad de una Serie nunca puede ser diferente a 1";
                if (Seguimiento == "Lote:" && Detalle.InventariosFisicosLotesSeries.Sum(v => v.Cantidad) > Detalle.ExistenciaFisica)
                    return "La existencia de los lotes no puede ser mayor a la de la existencia principal";
                if (Seguimiento == "Lote:" && Detalle.InventariosFisicosLotesSeries.Where(v => v.Cantidad==0).Count() > 1)
                    return "No pueden existir mas de un registro de tipo lote con cantidad 0";
                return null;
            }
            if (propiedad == BindableBase.GetPropertyName(() => LotesSeries))
            {
                if (Detalle.InventariosFisicosLotesSeries.Where(c => !String.IsNullOrEmpty(c.LotesSeries.SerieLote) && c.LotesSeries.SerieLote != "SIN SERIE" && c.LotesSeries.SerieLote != "SIN LOTE").Where(c => c.LotesSeries.SerieLote == LotesSeries.SerieLote).Count() > 1)
                    return "El numero de serie o lote " +  LotesSeries.SerieLote + " que intenta registrar, ya se encuentra en el componente " + LotesSeries.Componentes.Nombre;
                if (Detalle.Componentes.TipoSeguimiento == "LOTES" && Cantidad != 0 && LotesSeries.FechaCaducidad == null )
                    return "En los componentes de tipo LOTES, la fecha de caducidad es obligatoria";
            }
            return null;
        }
    }
}

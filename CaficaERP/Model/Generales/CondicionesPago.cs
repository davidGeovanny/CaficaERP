using CaficaERP.Model.Compras;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Generales
{
  public  class CondicionesPago : BaseModel
    {
        public CondicionesPago() 
        {
            this.ComprasDocs = new ObservableCollection<ComprasDocs>();
            this.CondicionesPagoPlazos = new ObservableCollection<CondicionesPagoPlazos>();
            this.Proveedores = new ObservableCollection<Proveedores>();
        }

        
        public string Nombre { get; set; }
        public Nullable<double> DescProntoPago { get; set; }
        public Nullable<int> DiasProntoPago { get; set; }
        public string Predeterminado { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<ComprasDocs> ComprasDocs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<CondicionesPagoPlazos> CondicionesPagoPlazos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Proveedores> Proveedores { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => CondicionesPagoPlazos))
            {
                if (Math.Round(CondicionesPagoPlazos.Sum(a=>a.Porcentaje),2)!=100)
                    return("El porcentaje debe ser al 100%");
                foreach (CondicionesPagoPlazos detalle in CondicionesPagoPlazos)
                {
                    if (detalle.diaactual == null)
                        detalle.diaactual = this;

                    string error = detalle.Errores();
                    if (!string.IsNullOrEmpty(error))
                        return error;


                }

            }
            if(propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if(string.IsNullOrWhiteSpace(Nombre))
                    return ("El nombre no a sido indicado.Indiquelo antes de continuar");
            }

            return null;
        }
    }
}

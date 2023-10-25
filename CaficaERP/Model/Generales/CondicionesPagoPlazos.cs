using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Generales
{
  public  class CondicionesPagoPlazos :BaseModel
    {
      
        public long CondicionesPagoId { get; set; }
        public int Dias { get; set; }
        public double Porcentaje { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual CondicionesPago diaactual { get; set; }

        public override string Validar(string propiedad)
        {
            if (diaactual != null)
            {
                if (propiedad == BindableBase.GetPropertyName(() => Dias))
                   {
                    if (diaactual.CondicionesPagoPlazos.Where(b => b.Dias==Dias).Count()>1)
                        return "El impuesto que intenta registrar, ya se enc do";
                }
            }
            return null;
        }
    }
}

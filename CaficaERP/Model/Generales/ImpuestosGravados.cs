using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Generales
{
    public partial class ImpuestosGravados:BaseModel
    {
       
        public long ImpuestoId { get; set; }
        public long ImpuestoGravadoId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Impuestos Impuestos { get; set; }

        public virtual Impuestos ImpuestoActual { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => ImpuestoGravadoId))
            {
                if(ImpuestoActual != null)
                {
                    if (ImpuestoActual.ImpuestosGravados1.Where(b=>b.ImpuestoGravadoId!=0).Where(c => c.ImpuestoGravadoId == ImpuestoGravadoId).Count() > 1)
                        return "El impuesto que intenta registrar, ya se encuentra seleccionado";
                }

              
            }
            return null;
        }
    }
}

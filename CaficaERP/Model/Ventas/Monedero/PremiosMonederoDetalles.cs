using CaficaERP.Model.Generales;
using CaficaERP.Model.Inventarios;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Ventas.Monedero
{
    public class PremiosMonederoDetalles:BaseModel
    {
        public PremiosMonederoDetalles()
        {
            this.Componentes = new Componentes();
            this.LstUnidades = new System.Collections.ObjectModel.ObservableCollection<Unidades>();
        }

        public long PremioMonederoId { get; set; }
        public long ComponenteId { get; set; }
        public double Cantidad { get; set; }
        public long UnidadId { get; set; }
        public double CantidadReal { get; set; }
        public long UnidadRealId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Componentes Componentes { get; set; }
        public virtual PremiosMonedero PremiosMonedero { get; set; }
        public virtual Unidades Unidades { get; set; }
        public virtual Unidades Unidades1 { get; set; }

        public virtual System.Collections.ObjectModel.ObservableCollection<Unidades> LstUnidades { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

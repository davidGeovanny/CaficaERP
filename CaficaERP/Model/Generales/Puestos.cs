using CaficaERP.Model.Inventarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Generales
{
    public class Puestos : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Puestos()
        {
            this.Responsables = new ObservableCollection<Responsables>();
        }

        public string Nombre { get; set; }
        public long DepartamentoId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual Departamentos Departamentos { get; set; }

        public virtual ObservableCollection<Responsables> Responsables { get; set; }

        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

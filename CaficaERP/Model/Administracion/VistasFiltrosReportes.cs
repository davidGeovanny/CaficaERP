using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Administracion
{
    public class VistasFiltrosReportes
    {
        public long Id { get; set; }
        public long VistaId { get; set; }
        public string Etiqueta { get; set; }
        public string Tipo { get; set; }
        public string Lista { get; set; }
        public string MetodoLista { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public string Columnas { get; set; }
        public string NombreParametro { get; set; }   
        public string DependeDeEtiqueta { get; set; }
        public Nullable<int> Orden { get; set; }
        public string CampoValue { get; set; }
        public string CampoDisplay { get; set; }
    }
}

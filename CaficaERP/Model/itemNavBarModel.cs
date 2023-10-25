using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaficaERP.Model
{
    using System;
    using System.Collections.Generic;

    public class ItemNavBarModel
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public string ImagenMenu { get; set; }
        public string Parametros { get; set; } // Contiene el campo Id , Tipo , Parametros de la vista
        
    }
}
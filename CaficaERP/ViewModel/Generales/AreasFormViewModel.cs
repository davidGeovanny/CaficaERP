using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Generales
{
    public class AreasFormViewModel : FormularioViewModel<Areas>
    {
        public AreasFormViewModel()
        {

        }
        public AreasFormViewModel(Areas item, string conexion) : base(item, conexion)
        {

        }
    }
}

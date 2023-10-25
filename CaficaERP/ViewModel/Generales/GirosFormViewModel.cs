
using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Generales
{
    public class GirosFormViewModel : FormularioViewModel<Giros>
    {

        public GirosFormViewModel()
        {


        }
        public GirosFormViewModel(Giros item, string conexion) : base(item, conexion)
        {

        }

    }
}

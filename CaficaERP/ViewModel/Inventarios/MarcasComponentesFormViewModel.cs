using CaficaERP.Model.Inventarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Inventarios
{
    public class MarcasComponentesFormViewModel : FormularioViewModel<MarcasComponentes>
    {
        public MarcasComponentesFormViewModel()
        {

        }

        public MarcasComponentesFormViewModel(MarcasComponentes item, string conexion) : base(item, conexion)
        {



        }


    }
}

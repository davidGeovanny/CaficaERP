using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Generales
{
    public class DepartamentosFormViewModel : FormularioViewModel<Departamentos>
    {
        public DepartamentosFormViewModel()
        {

        }
        public DepartamentosFormViewModel(Departamentos item, string conexion) : base(item, conexion)
        {

        }
    }
}

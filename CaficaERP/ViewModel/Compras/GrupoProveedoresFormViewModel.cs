using CaficaERP.Model.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Compras
{
   public class GrupoProveedoresFormViewModel : FormularioViewModel<GrupoProveedores>
    {
        public GrupoProveedoresFormViewModel()
        {


        }
        public GrupoProveedoresFormViewModel(GrupoProveedores item, string conexion) : base(item, conexion)
        {

        }

    }
}

using CaficaERP.Model.Generales;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Generales
{
  public  class UnidadesFormViewModel : FormularioViewModel<Unidades>
    {
      

        public UnidadesFormViewModel()
        {
           
        }

        public UnidadesFormViewModel(Unidades item, string conexion) : base(item, conexion)
        {

           

        }

      
     
    }
}

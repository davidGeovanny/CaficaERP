using CaficaERP.Model.Administracion;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Administracion
{
    class SistemasFormViewModel : FormularioViewModel<Sistemas>
    {
     

        public SistemasFormViewModel()
        {
            
        }

        public SistemasFormViewModel(Sistemas item, string conexion) : base(item, conexion)
        {
         
        }

    }
}

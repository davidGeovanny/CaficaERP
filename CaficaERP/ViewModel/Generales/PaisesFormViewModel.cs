
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
    public class PaisesFormViewModel : FormularioViewModel<Paises>
    {

        public PaisesFormViewModel()
        {
     

        }
        public PaisesFormViewModel(Paises item, string conexion) : base(item, conexion)
        {

        }

        
    }
}

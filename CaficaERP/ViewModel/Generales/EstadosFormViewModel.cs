using CaficaERP.Model.Generales;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Generales
{
    public class EstadosFormViewModel : FormularioViewModel<Estados>
    {
        private Paises _PaisSeleccionado;

        public EstadosFormViewModel()
        {
            CargarPaises();
        }

        public EstadosFormViewModel(Estados item, string conexion) : base(item, conexion)
        {

        }

        public override void CargarItem()
        {
            base.CargarItem();
            CargarPaises();
            PaisSeleccionado = LstPaises.Single(x => x.Id == Item.PaisId);
        }
        public Paises PaisSeleccionado
        {
            get
            {
                return _PaisSeleccionado;
            }

            set
            {
                SetProperty(ref _PaisSeleccionado, value, () => PaisSeleccionado);
            }
        }

    }
}

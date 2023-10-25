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
    public class MunicipiosFormViewModel :FormularioViewModel<Municipios>
    {
        private Paises _PaisSeleccionado;
        private Estados _EstadoSeleccionado;

        public MunicipiosFormViewModel()
        {
            CargarPaises();
        }

        public MunicipiosFormViewModel(Municipios item, string conexion) : base(item, conexion)
        {

        }

        public override void CargarItem()
        {
            base.CargarItem();
            CargarPaises();
            PaisSeleccionado = LstPaises.Single(x => x.Id == Item.PaisId);
            CargarEstados(PaisSeleccionado);
            EstadoSeleccionado = LstEstados.Single(x => x.Id == Item.EstadoId);
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
                CargarEstados(PaisSeleccionado);
            }
        }

      

        public Estados EstadoSeleccionado
        {
            get
            {
                return _EstadoSeleccionado;
            }

            set
            {
                SetProperty(ref _EstadoSeleccionado, value, () => EstadoSeleccionado);
            }
        }

      
    }
}

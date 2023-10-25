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
    class ColoniasFormViewModel :FormularioViewModel<Colonias>
    {
        private Paises _PaisSeleccionado;
        private Estados _EstadoSeleccionado;
        private Municipios _MunicipioSeleccionado;
        private Ciudades _CiudadSeleccionada;
        private CodigosPostales _CodigoPostalSeleccionado;

        public ColoniasFormViewModel()
        {
            PaisSeleccionado = new Paises();
            EstadoSeleccionado = new Estados();
            MunicipioSeleccionado = new Municipios();
            CiudadSeleccionada = new Ciudades();
            CodigoPostalSeleccionado = new CodigosPostales();
            CargarPaises();
           

        }
        public ColoniasFormViewModel(Colonias item, string conexion) : base(item, conexion)
        {

        }

        public override void CargarItem()
        {
            base.CargarItem();
            CargarPaises();
            PaisSeleccionado = LstPaises.Single(x => x.Id == Item.PaisId);
            CargarEstados(PaisSeleccionado);
            EstadoSeleccionado = LstEstados.Single(x => x.Id == Item.EstadoId);
            CargarMunicipios(EstadoSeleccionado);
            MunicipioSeleccionado = LstMunicipios.Single(x => x.Id == Item.MunicipioId);
            CargarCiudades(MunicipioSeleccionado);
            CiudadSeleccionada = LstCiudades.Single(x => x.Id == Item.CiudadId);
            CargarCodigosPostales(CiudadSeleccionada);
            CodigoPostalSeleccionado = LstCodigosPostales.Single(x => x.Id == Item.CodigoPostalId);
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
                CargarMunicipios(EstadoSeleccionado);
            }
        }

        public Municipios MunicipioSeleccionado
        {
            get
            {
                return _MunicipioSeleccionado;
            }

            set
            {
                SetProperty(ref _MunicipioSeleccionado, value, () => MunicipioSeleccionado);
                CargarCiudades(MunicipioSeleccionado);
            }
        }

        public Ciudades CiudadSeleccionada
        {
            get
            {
                return _CiudadSeleccionada;
            }

            set
            {
                SetProperty(ref _CiudadSeleccionada, value, () => CiudadSeleccionada);
                CargarCodigosPostales(CiudadSeleccionada);
            }
        }

       
        public CodigosPostales CodigoPostalSeleccionado
        {
            get
            {
                return _CodigoPostalSeleccionado;
            }

            set
            {
                SetProperty(ref _CodigoPostalSeleccionado, value, () => CodigoPostalSeleccionado);
            }
        }

   
    }
}

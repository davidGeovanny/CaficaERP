using CaficaERP.Model.Generales;
using CaficaERP.Model.Inventarios;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Inventarios
{
    public class AlmacenesFormViewModel : FormularioViewModel <Almacenes>
    {
        private TiposComponentes _TipoComponenteSeleccionado;
        private List<object> _SelectedGrupoComponentes;
        private Colonias _Colonia;
        private Colonias _ColoniaSeleccionada;
        private bool _AlmacenVirtual;

        public TiposComponentes TipoComponenteSeleccionado
        {
            get
            {
                return _TipoComponenteSeleccionado;
            }

            set
            {
                SetProperty(ref _TipoComponenteSeleccionado, value, () => TipoComponenteSeleccionado);
                if(value != null)
                    CargarGruposComponentesXTipo(value.Id);
            }
        }

        public List<object> SelectedGrupoComponentes
        {
            get
            {
                return _SelectedGrupoComponentes;
            }

            set
            {
                SetProperty(ref _SelectedGrupoComponentes, value, () => SelectedGrupoComponentes);
            }
        }

        public Colonias Colonia
        {
            get
            {
                return _Colonia;
            }

            set
            {
                SetProperty(ref _Colonia, value, () => Colonia);
            }
        }
        public bool AlmacenVirtual
        {
            get
            {
                return _AlmacenVirtual;
            }

            set
            {
                SetProperty(ref _AlmacenVirtual, value, () => AlmacenVirtual);
            }
        }

        public Colonias ColoniaSeleccionada
        {
            get
            {
                return _ColoniaSeleccionada;
            }

            set
            {
                SetProperty(ref _ColoniaSeleccionada, value, () => ColoniaSeleccionada);
            }
        }

        public AlmacenesFormViewModel()
        {
            SelectedGrupoComponentes=new List<object>();

            CargarTiposComponentes();
            CargarSiNo();
            CargarDirecciones();
            CargarTipoAlmacen();
        }
        public AlmacenesFormViewModel(Almacenes item, string conexion) : base(item, conexion)
        {

        }
        public override void CargarItem()
        {
            try
            {
                base.CargarItem();

                //Carga el objeto directamente del WS
                SelectedGrupoComponentes = new List<object>();
                ColoniaSeleccionada = new Colonias();
                Colonia = new Colonias();

                CargarTiposComponentes();
                CargarSiNo();
                CargarDirecciones();
                CargarTipoAlmacen();

                //Carga compo Tipo Componentes
                TipoComponenteSeleccionado = LstTiposComponentes.Single(x => x.Id == Item.TipoComponenteId);

                //Verifico si el almacen es virtual
                AlmacenVirtual = Item.Virtual == "SI" ? true : false;

                //Busca la direccion y la carga para ser mostrados en el lookupedit
                ColoniaSeleccionada =Item.ColoniaId!=null ? LstDirecciones.Single(x => x.Id == Item.ColoniaId) : null;

                //Carga la lista de objectos relacionada con el listbox de GrupoConceptos
                foreach (AlmacenesGruposComponentes agp in Item.AlmacenesGruposComponentes)
                {
                    //Busca el item seleccionado para poner el check en true
                    var item = LstGruposComponentes.Where(x => x.TipoComponenteId == Item.TipoComponenteId).Single(x => x.Id == agp.GrupoComponentesId);
                    SelectedGrupoComponentes.Add(item);
                }
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void GuardarItem()
        {
            if (SelectedGrupoComponentes==null)
                throw new Exception("Al menos debes seleccionar un Grupos Componentes");
            if (SelectedGrupoComponentes.Count == 0)
                throw new Exception("Al menos debes seleccionar un Grupos Componentes");

            //Obtengo los valores seleccion de grupos componentes
            Item.AlmacenesGruposComponentes.Clear();
            foreach (GruposComponentes gp in SelectedGrupoComponentes)
            {
                Item.AlmacenesGruposComponentes.Add(new AlmacenesGruposComponentes
                {
                    GrupoComponentesId = gp.Id,
                    AlmacenId = Item.Id
                });
            }

            //Verifico si el almacen es virtual
            Item.Virtual = AlmacenVirtual == true ? "SI" : "NO";

            //Asigno la direccion al objeto almacen
            if (Colonia != null)
            {
                Item.ColoniaId = Colonia.Id;
                Item.CodigoPostalId = Colonia.CodigoPostalId;
                Item.CiudadId = Colonia.CiudadId;
                Item.MunicipioId = Colonia.MunicipioId;
                Item.EstadoId = Colonia.EstadoId;
                Item.PaisId = Colonia.PaisId;
            }
            base.GuardarItem();
        }
        public override void Limpiar()
        {
            try
            {
                base.Limpiar();
                LstGruposComponentes=null;
                AlmacenVirtual = false;
                SelectedGrupoComponentes = null;
                ColoniaSeleccionada = null;
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
         }
    }
}

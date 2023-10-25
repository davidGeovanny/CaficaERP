using CaficaERP.Model.Generales;
using DevExpress.Xpf.Core;
using System;
using System.Linq;
using System.Windows;

namespace CaficaERP.ViewModel.Generales
{
    public class PuestosFormViewModel : FormularioViewModel<Puestos>
    {
        private Departamentos _DepartamentoSeleccionado;
        private Departamentos _AreaSeleccionado;
        private Departamentos _PuestosSeleccionado;

        public Departamentos DepartamentoSeleccionado
        {
            get
            {
                return _DepartamentoSeleccionado;
            }

            set
            {
                SetProperty(ref _DepartamentoSeleccionado, value, () => DepartamentoSeleccionado);
            }
        }

        public Departamentos AreaSeleccionado
        {
            get
            {
                return _AreaSeleccionado;
            }

            set
            {
                SetProperty(ref _AreaSeleccionado, value, () => AreaSeleccionado);
            }
        }

        public Departamentos PuestosSeleccionado
        {
            get
            {
                return _PuestosSeleccionado;
            }

            set
            {
                SetProperty(ref _PuestosSeleccionado, value, () => PuestosSeleccionado);
            }
        }

        public PuestosFormViewModel()
        {
            CargarDepartamentos();
        }
        public PuestosFormViewModel(Puestos item, string conexion) : base(item, conexion)
        {

        }
        public override void CargarItem()
        {
            try
            {
                base.CargarItem();
                //Carga el objeto directamente del WS
                CargarDepartamentos();
                DepartamentoSeleccionado = LstDepartamentos.Single(x => x.Id == Item.DepartamentoId);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
    }
}

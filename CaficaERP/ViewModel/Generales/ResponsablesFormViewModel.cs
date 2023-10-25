using CaficaERP.Model.Generales;
using CaficaERP.Model.Inventarios;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Generales
{
    public class ResponsablesFormViewModel : FormularioViewModel<Responsables>
    {
        private Departamentos _DepartamentoSeleccionado;
        private Areas _AreaSeleccionado;
        private Puestos _PuestosSeleccionado;
        private System.Collections.ObjectModel.ObservableCollection<Puestos> _LstPuestos;

        public Departamentos DepartamentoSeleccionado
        {
            get
            {
                return _DepartamentoSeleccionado;
            }

            set
            {
                SetProperty(ref _DepartamentoSeleccionado, value, () => DepartamentoSeleccionado);
                CargaPuestosxDepartamento(value.Id);
            }
        }
        public Areas AreaSeleccionado
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

        public Puestos PuestosSeleccionado
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

        public System.Collections.ObjectModel.ObservableCollection<Puestos> LstPuestos
        {
            get
            {
                return _LstPuestos;
            }

            set
            {
                SetProperty(ref _LstPuestos, value, () => LstPuestos);
            }
        }

        public ResponsablesFormViewModel()
        {
            CargarDepartamentos();
            CargarAreas();
        }
        public ResponsablesFormViewModel(Responsables item, string conexion) : base(item, conexion)
        {
    
        }
        public void CargaPuestosxDepartamento(long IdDepartamento)
        {
            try
            {
                LstPuestos = null;
                ServicioWS Ws1 = new ServicioWS("ServiciosERP/Generales/WSPuestos.svc", "CargaPuestosxDepartamento", IdDepartamento, typeof(System.Collections.ObjectModel.ObservableCollection<Puestos>), "id");
                LstPuestos = (System.Collections.ObjectModel.ObservableCollection<Puestos>)Ws1.Peticion();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void CargarItem()
        {
            try
            {
                base.CargarItem();
                //Carga el objeto directamente del WS
                CargarDepartamentos();
                CargarAreas();
                if (Item.DepartamentoId!= null )  DepartamentoSeleccionado = LstDepartamentos.Single(x => x.Id == Item.DepartamentoId);
                if (Item.AreaId != null)          AreaSeleccionado = LstAreas.Single(x => x.Id == Item.AreaId);
                if (Item.PuestoId != null)        PuestosSeleccionado = LstPuestos.Single(x => x.Id == Item.PuestoId);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

    }
}

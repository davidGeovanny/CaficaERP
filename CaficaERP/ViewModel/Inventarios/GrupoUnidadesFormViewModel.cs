using CaficaERP.Model.Inventarios;
using DevExpress.Mvvm;
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
    public class GrupoUnidadesFormViewModel : FormularioViewModel<GruposUnidades>
    {
        private GruposUnidadesDetalleTemp _GrupoUnidadSeleccionado;
        private System.Collections.ObjectModel.ObservableCollection<GruposUnidadesDetalleTemp> _GruposUnidadesDetalleTemp;
        public DelegateCommand DcActualizarUnidadBase { get; set; }
        public DelegateCommand DcEliminaFila { get; set; }

        public GruposUnidadesDetalleTemp GrupoUnidadSeleccionado
        {
            get
            {
                return _GrupoUnidadSeleccionado;
            }

            set
            {
                SetProperty(ref _GrupoUnidadSeleccionado, value, () => GrupoUnidadSeleccionado);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<GruposUnidadesDetalleTemp> GruposUnidadesDetalleTemp
        {
            get
            {
                return _GruposUnidadesDetalleTemp;
            }

            set
            {
                _GruposUnidadesDetalleTemp = value;
            }
        }
        public GrupoUnidadesFormViewModel()
        {
            GrupoUnidadSeleccionado = new GruposUnidadesDetalleTemp();
            GruposUnidadesDetalleTemp = new System.Collections.ObjectModel.ObservableCollection<GruposUnidadesDetalleTemp>();
            DcActualizarUnidadBase = new DelegateCommand(ActualizarUnidadBase);
            DcEliminaFila = new DelegateCommand(EliminaFila);

            CargarUnidades();
        }
        public GrupoUnidadesFormViewModel(GruposUnidades item, string conexion) : base(item, conexion)
        {


        }
        public override void CargarItem()
        {
            try
            {
                base.CargarItem();

                GrupoUnidadSeleccionado = new GruposUnidadesDetalleTemp();
                GruposUnidadesDetalleTemp = new System.Collections.ObjectModel.ObservableCollection<GruposUnidadesDetalleTemp>();
                DcActualizarUnidadBase = new DelegateCommand(ActualizarUnidadBase);
                DcEliminaFila = new DelegateCommand(EliminaFila);

                CargarUnidades();
                CargarTemporles();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        //Metodo que iniciliaza los valores temporales
        public void CargarTemporles()
        {
            //Pasa el objeto real al temporal
            //Pasao el objeto temporar al objecto real para enviarse al servidor
            GruposUnidadesDetalleTemp.Clear();
            foreach (GruposUnidadesDetalle Gu in Item.GruposUnidadesDetalle)
            {
                GruposUnidadesDetalleTemp.Add(new GruposUnidadesDetalleTemp
                {
                    Id = Gu.Id,
                    GrupoUnidadesId = Gu.GrupoUnidadesId,
                    CantidadEquivalente = Gu.CantidadEquivalente,
                    UnidadEquivalenteId = Gu.UnidadEquivalenteId,
                    UnidadBaseId = Gu.UnidadBaseId,
                    CantidadBase = Gu.CantidadBase,
                    UsuarioCreo = Gu.UsuarioCreo,
                    FechaCreacion = Gu.FechaCreacion,
                    UsuarioModifico = Gu.UsuarioModifico,
                    FechaUltimaModificacion = Gu.FechaUltimaModificacion
                });
                RaisePropertyChanged(() => GruposUnidadesDetalleTemp);
            }
        }
        public void EliminaFila()
        {
            try
            {
                if (GruposUnidadesDetalleTemp.ToList()[0] == GrupoUnidadSeleccionado)
                    throw new Exception("La primera fila de las equivalencia no puede ser eliminada");

                GruposUnidadesDetalleTemp.Remove(GrupoUnidadSeleccionado);
                GrupoUnidadSeleccionado = null;
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
               MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void ActualizarUnidadBase()
        {
            try
            {
                //La primera fila del grid no es modicable
                GruposUnidadesDetalleTemp.ToList()[0].CantidadBase = 1;
                GruposUnidadesDetalleTemp.ToList()[0].CantidadEquivalente = 1;
                foreach (GruposUnidadesDetalleTemp Gu in GruposUnidadesDetalleTemp)
                {
                    Gu.UnidadBaseId = GruposUnidadesDetalleTemp.ToList()[0].UnidadEquivalenteId;
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
            if (GruposUnidadesDetalleTemp.ToList().Count == 0)
                throw new Exception("Al menos debes capturar una equivalencia");

            foreach (GruposUnidadesDetalleTemp Gu in GruposUnidadesDetalleTemp)
            {
                var item = GruposUnidadesDetalleTemp.Where(x => x.UnidadEquivalenteId == Gu.UnidadEquivalenteId).ToList();
                if (item.Count > 1)
                    throw new Exception("No pueden existir dos veces la misma Unidad Equivalente");
            }

            if (GruposUnidadesDetalleTemp.Where(x => x.CantidadEquivalente == 0).ToList().Count > 0 || GruposUnidadesDetalleTemp.Where(x => x.CantidadBase == 0).ToList().Count > 0)
                throw new Exception("Cantidad Base y Cantidad Equivalente no pueden tener valor 0");

            //Pasao el objeto temporar al objecto real para enviarse al servidor
            Item.GruposUnidadesDetalle.Clear();
            foreach (GruposUnidadesDetalleTemp Gu in GruposUnidadesDetalleTemp)
            {
                Item.GruposUnidadesDetalle.Add(new GruposUnidadesDetalle
                {
                    Id = Gu.Id,
                    GrupoUnidadesId = Item.Id,
                    CantidadEquivalente = Gu.CantidadEquivalente,
                    UnidadEquivalenteId = Gu.UnidadEquivalenteId,
                    UnidadBaseId = Gu.UnidadBaseId,
                    CantidadBase = Gu.CantidadBase,
                    UsuarioCreo=Gu.UsuarioCreo,
                    FechaCreacion=Gu.FechaCreacion,
                    UsuarioModifico=Gu.UsuarioModifico,
                    FechaUltimaModificacion=Gu.FechaUltimaModificacion
                });
            }

            base.GuardarItem();
        }
        public override void Limpiar()
        {
            base.Limpiar();
            GruposUnidadesDetalleTemp.Clear();
        }
    }
    public class GruposUnidadesDetalleTemp : ViewModelBase
    {
        private long _Id;
        private long _GrupoUnidadesId;
        private double _CantidadEquivalente;
        private long _UnidadEquivalenteId;
        private double _CantidadBase;
        private long _UnidadBaseId;
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public long Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public long GrupoUnidadesId
        {
            get
            {
                return _GrupoUnidadesId;
            }

            set
            {
                _GrupoUnidadesId = value;
                RaisePropertyChanged(() => GrupoUnidadesId);
            }
        }

        public double CantidadEquivalente
        {
            get
            {
                return _CantidadEquivalente;
            }

            set
            {
                _CantidadEquivalente = value;
                RaisePropertyChanged(() => CantidadEquivalente);
            }
        }

        public long UnidadEquivalenteId
        {
            get
            {
                return _UnidadEquivalenteId;
            }

            set
            {
                _UnidadEquivalenteId = value;
                RaisePropertyChanged(() => UnidadEquivalenteId);
            }
        }

        public double CantidadBase
        {
            get
            {
                return _CantidadBase;
            }

            set
            {
                _CantidadBase = value;
                RaisePropertyChanged(() => CantidadBase);
            }
        }

        public long UnidadBaseId
        {
            get
            {
                return _UnidadBaseId;
            }

            set
            {
                _UnidadBaseId = value;
                RaisePropertyChanged(() => UnidadBaseId);
            }
        }
    }
}

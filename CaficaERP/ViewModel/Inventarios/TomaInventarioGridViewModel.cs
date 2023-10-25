using CaficaERP.Model.Inventarios;
using CaficaERP.Views.Inventarios;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
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
    public class TomaInventarioGridViewModel : GridViewModel<InventariosFisicos,TomaInventarioFormView, TomaInventarioFormViewModel>
    {
        private string _RutaImagen;
        private bool _OpcionAplicar;
        public DelegateCommand DcAplicarInventario { get; set; }
        public DelegateCommand DcSelectedItemChanged { get; set; }
        public string RutaImagen
        {
            get
            {
                return _RutaImagen;
            }

            set
            {
                SetProperty(ref _RutaImagen, value, () => RutaImagen);
            }
        }

        public bool OpcionAplicar
        {
            get
            {
                return _OpcionAplicar;
            }

            set
            {
                SetProperty(ref _OpcionAplicar, value, () => OpcionAplicar);
            }
        }

        public TomaInventarioGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            FiltradoFechas = true;
            DcAplicarInventario = new DelegateCommand(AplicarInventario);
            DcSelectedItemChanged = new DelegateCommand(SelectedItemChanged);
            /*RutaImagen = "/Imagenes/Barras/cancelar.png";
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Fecha", FieldName = "Fecha", Settings = SettingsType.Default },
                new Column() { Header="Folio", FieldName = "Folio", Settings = SettingsType.Default },
                new Column() { Header="Almacen", FieldName = "Almacenes.Nombre", Settings = SettingsType.Default },
                new Column() { Header="Estado", FieldName = "Estado", Settings = SettingsType.Default },
                new Column() { Header="Descripcion", FieldName = "Descripcion", Settings = SettingsType.Default },
                new Imagen() { Header="Afectar",FieldName = "",ToolTip="Afectar inventario",Settings = SettingsType.Imagen }
            };*/
        }
        public override void Nuevo()
        {
            TomaInventarioFormView FrmITem = new TomaInventarioFormView();
            ViewModelSource.Create(() => new TomaInventarioFormViewModel(FrmITem)
            {
                FormTitulo = "Toma de Inventario",
                TabGridActivo = (TabViewModel)this,
                StrWebService = StrWebService,
                RutaReporteForm = StrReporteForm
            });
        }
        public override void Abrir()
        {
            if (ItemSeleccionado != null)
            {
                if (ItemSeleccionado.Id != 0)
                {
                    TomaInventarioFormView FrmITem = new TomaInventarioFormView();
                    ViewModelSource.Create(() => new TomaInventarioFormViewModel(FrmITem,ItemSeleccionado,StrWebService)
                    {
                        FormTitulo = "Toma de Inventario",
                        TabGridActivo = (TabViewModel)this,
                        RutaReporteForm=StrReporteForm
                        //StrWebService = StrWebService
                    });
                }
            }
        }
        public void AplicarInventario()
        {
            try
            {
                MessageBoxResult guardar_si_no = DXMessageBox.Show(VariablesGlobales.Main, "¿Desea aplicar el inventario seleccionado?", "Confirmación", MessageBoxButton.YesNo,
                                 MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
                if (guardar_si_no == MessageBoxResult.Yes)
                {
                    ServicioWS Ws = new ServicioWS(StrWebService, "aplicarInventario",ItemSeleccionado.Id, typeof(bool), "id");
                    bool aplicado = (bool)Ws.Peticion();

                    this.Refrescar();

                    DXMessageBox.Show(VariablesGlobales.Main,"El inventario fisico ha sido a plicado", "Mensaje", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void SelectedItemChanged()
        {
            try
            {
                InventariosFisicos InvFisico = (InventariosFisicos)ItemSeleccionado;
                OpcionAplicar = InvFisico.Estado == "PENDIENTE" ? true : false;
                RaisePropertyChanged(() => OpcionAplicar);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
    }
}

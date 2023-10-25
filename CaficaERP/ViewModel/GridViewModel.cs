using CaficaERP.Model;
using CaficaERP.Model.Reportes;
using CaficaERP.ViewModel.Administracion;
using CaficaERP.Views;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel
{
    //: ViewModelBase
    public class GridViewModel <TModelo,TFormView,TFormViewModel> : TabViewModel
                                        where TModelo : BaseModel
                                        where TFormViewModel : FormularioViewModel<TModelo>
    {
        //Objetos genericos
        private System.Collections.ObjectModel.ObservableCollection<TModelo> _LstItems;
        private TModelo _ItemSeleccionado;
        private string _StrWebService;
        private string _StrReporte;
        private string _StrReporteForm;
        private string _ColumnaSumar;
        /*private overrride DateTime _FechaInicioFiltrado;
        private DateTime _FechaFinFiltrado;*/
        private System.Collections.ObjectModel.ObservableCollection<TModelo> _VisibleData; //Contiene solo los elementos visibles en el formulario
        public System.Collections.ObjectModel.ObservableCollection<Column> Columns { get; set; } //Columnas del grid principal


        //------------------------------------------------------

        public DelegateCommand DcNuevo { get; set; }
        public DelegateCommand DcAbrir { get; set; }
        public DelegateCommand DcEliminar { get; set; }
        public DelegateCommand DcImprimir { get; set; }
        public DelegateCommand DcRefrescar { get; set; }
        public DelegateCommand DcMeses { get; set; }
        public DelegateCommand DcHome { get; set; }
        public IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(ServiceSearchMode.PreferParents); } }

        public System.Collections.ObjectModel.ObservableCollection<TModelo> LstItems
        {
            get
            {
                return _LstItems;
            }
            set
            {
                SetProperty(ref _LstItems, value, () => LstItems);
            }
        }

        public TModelo ItemSeleccionado
        {
            get
            {
                return _ItemSeleccionado;
            }

            set
            {
                SetProperty(ref _ItemSeleccionado, value, () => ItemSeleccionado);
            }
        }

        public string StrWebService
        {
            get
            {
                return _StrWebService;
            }

            set
            {
                _StrWebService = value;
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<TModelo> VisibleData
        {
            get
            {
                return _VisibleData;
            }

            set
            {
                SetProperty(ref _VisibleData, value, () => VisibleData);
            }
        }

        public string StrReporte
        {
            get
            {
                return _StrReporte;
            }

            set
            {
                _StrReporte = value;
            }
        }
        public string StrReporteForm
        {
            get
            {
                return _StrReporteForm;
            }

            set
            {
                _StrReporteForm = value;
            }
        }

        public string ColumnaSumar
        {
            get
            {
                return _ColumnaSumar;
            }

            set
            {
                SetProperty(ref _ColumnaSumar, value, () => ColumnaSumar);
            }
        }

        /*public DateTime FechaInicioFiltrado
        {
            get
            {
                return _FechaInicioFiltrado;
            }

            set
            {
                _FechaInicioFiltrado = value;
            }
        }

        public DateTime FechaFinFiltrado
        {
            get
            {
                return _FechaFinFiltrado;
            }

            set
            {
                _FechaFinFiltrado = value;
            }
        }*/

        //------------------------------------------------------

        public override void Nuevo()
        {
            try
            {
                NuevoForm();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public void NuevoForm()
        {
            try
            {
                TFormView FrmITem = Activator.CreateInstance<TFormView>();
                TFormViewModel ItemVM = Activator.CreateInstance<TFormViewModel>();
                ItemVM.FormTitulo = this.Titulo;
                ItemVM.TabGridActivo = (TabViewModel)this;
                ItemVM.RutaReporteForm = StrReporteForm;
                ItemVM.StrWebService = this.StrWebService;
                ItemVM.Show(FrmITem);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public void NuevoForm(int tipo)
        {
            try
            {
                TFormView FrmITem = Activator.CreateInstance<TFormView>();
                TFormViewModel ItemVM = (TFormViewModel)Activator.CreateInstance(typeof(TFormViewModel), tipo);
                ItemVM.FormTitulo = this.Titulo;
                ItemVM.TabGridActivo = (TabViewModel)this;
                ItemVM.RutaReporteForm = StrReporteForm;
                ItemVM.StrWebService = this.StrWebService;
                ItemVM.Show(FrmITem);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public override void Abrir()
        {
            try
            {
                if(ItemSeleccionado != null)
                {
                    if (ItemSeleccionado.Id != 0)
                    { 
                        TFormView FrmITem = Activator.CreateInstance<TFormView>();
                        TFormViewModel ItemVM = (TFormViewModel)Activator.CreateInstance(typeof(TFormViewModel), ItemSeleccionado,this.StrWebService);
                        ItemVM.FormTitulo = this.Titulo;
                        ItemVM.RutaReporteForm = StrReporteForm;
                        //ItemVM.TabGridActivo = (GridViewModel<TModelo, TFormView, TFormViewModel>)this;
                        ItemVM.TabGridActivo = (TabViewModel)this;
                        ItemVM.Show(FrmITem);
                    }
                }
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void Eliminar()
        {
            try
            {
                MessageBoxResult eliminar = DXMessageBox.Show(VariablesGlobales.Main, "¿Desea eliminar el item?", "Confirmación", MessageBoxButton.YesNo,
                                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);

                if (eliminar == MessageBoxResult.Yes)
                {
                    ServicioWS Ws = new ServicioWS(StrWebService, "delete", ItemSeleccionado, typeof(TModelo), "item");
                    ItemSeleccionado = (TModelo)Ws.Peticion();
                    Refrescar();
                }
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public override void Imprimir()
        {
            try
            {
                if(VisibleData.Count > 0)
                { 
                    //Recorro el grid para obtener solo los ids y para enviarles al servidor de reportes
                    string ids="";
                    foreach (TModelo item in VisibleData)
                    {
                        //Si el tamaño del string es mayor a 1 le concatena la coma
                        ids += ids.Length > 0 ? "," + item.Id.ToString() : item.Id.ToString();
                    }

                    reportParameter parametro = new reportParameter();
                    parametro.name = "Ids";
                    parametro.value.Add(ids);

                    VisorReporteView FrmReporte = new VisorReporteView();
                    VisorReporteViewModel VmReporte = new VisorReporteViewModel(StrReporte,parametro,"pdf");
                    FrmReporte.DataContext = VmReporte;
                    FrmReporte.Title = "Listado de " + this.Titulo;
                    FrmReporte.Show();
                }
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void Refrescar()
        {
            try
            {
                ServicioWS ws = new ServicioWS(StrWebService, "getall", null, typeof(System.Collections.ObjectModel.ObservableCollection<TModelo>), null);
                LstItems = (System.Collections.ObjectModel.ObservableCollection<TModelo>)ws.Peticion();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void Meses()
        {
            throw new NotImplementedException();
        }
        public override void Home()
        {
            throw new NotImplementedException();
        }
        public override long Siguiente()
        {
            try
            {

                //Obtenemos el index del objeto siguiente
                long SigId = -1;
                if (ItemSeleccionado!=null)
                {
                    
                    int SigIndex = VisibleData.IndexOf(VisibleData.Where(x=>x.Id==ItemSeleccionado.Id).FirstOrDefault()) + 1;
                    if (SigIndex < VisibleData.Count && SigIndex > 0)
                    {
                        var visibleitem = VisibleData.ElementAt(SigIndex);
                        ItemSeleccionado = null;
                        ItemSeleccionado = LstItems.Where(z=>z.Id ==visibleitem.Id).FirstOrDefault();
                        SigId = ItemSeleccionado.Id;
                    }
                }

                return SigId;
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
                return -1;
            }

        }
        public override long Anterior()
        {
            try
            {
                //Obtenemos el index del objeto siguiente
                long AntId = -1;
                if (ItemSeleccionado != null)
                {
                    int AntIndex = VisibleData.IndexOf(VisibleData.Where(x => x.Id == ItemSeleccionado.Id).FirstOrDefault()) - 1;
                    if (AntIndex < VisibleData.Count && AntIndex >= 0)
                    {
                        var visibleitem = VisibleData.ElementAt(AntIndex);
                        ItemSeleccionado = null;
                        ItemSeleccionado = LstItems.Where(z => z.Id == visibleitem.Id).FirstOrDefault();
                        AntId = ItemSeleccionado.Id;
                    }
                }

                return AntId;
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
                return -1;
            }
        }
        //------------------------------------------------------

        public GridViewModel(string WebService,string Reporte,string ReporteForm)
        {
            StrWebService = WebService;
            StrReporte = Reporte;
            StrReporteForm = ReporteForm;

            DcNuevo         =   new DelegateCommand(Nuevo);
            DcAbrir         =   new DelegateCommand(Abrir);
            DcEliminar      =   new DelegateCommand(Eliminar);
            DcImprimir      =   new DelegateCommand(Imprimir);
            DcRefrescar     =   new DelegateCommand(Refrescar);
            DcMeses         =   new DelegateCommand(Meses);
            DcHome          =   new DelegateCommand(Home);

            LstItems = new System.Collections.ObjectModel.ObservableCollection<TModelo>();
            ItemSeleccionado = Activator.CreateInstance<TModelo>();
            VisibleData = new System.Collections.ObjectModel.ObservableCollection<TModelo>();
            //Columns =new System.Collections.ObjectModel.ObservableCollection<Column>();

            Refrescar();

            //Guardar temporalmente la fecha del filtrado
            FechaInicioFiltrado = VariablesGlobales.FechaInicio;
            FechaFinFiltrado = VariablesGlobales.FechaFin;

            //Llena la lista de los objetos visibles 
            foreach (TModelo item in LstItems)
            {
                TModelo NItem = Activator.CreateInstance<TModelo>();
                foreach (PropertyInfo propiedad in NItem.GetType().GetProperties())
                {
                    propiedad.SetValue(NItem,propiedad.GetValue(item, null), null);
                }
                VisibleData.Add(NItem);
            }
        }

   

        //------------------------------------------------------
    }
}

using CaficaERP.Model;
using CaficaERP.Model.Administracion;
using CaficaERP.Model.Generales;
using CaficaERP.Model.Inventarios;
using CaficaERP.Model.Reportes;
using CaficaERP.Views;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.ObjectModel;
using System.Web.UI;
using System.Windows;
using System.Windows.Input;

namespace CaficaERP.ViewModel
{
    public class FormularioViewModel <TModelo> : ListasFormulario
                                        where TModelo : BaseModel
    {
        //------------------------------------------------------

        public DelegateCommand DcGuardar { get; set; }
        public DelegateCommand DcGuardarLimpiar { get; set; }
        public DelegateCommand DcEliminar { get; set; }
        public DelegateCommand DcCancelar { get; set; }
        public DelegateCommand DcDeshacer { get; set; }
        public DelegateCommand DcAnterior { get; set; }
        public DelegateCommand DcSiguiente { get; set; }
        public DelegateCommand DcImprimir { get; set; }
        public DelegateCommand DcImprimirTicket { get; set; }
        public Action CloseAction { get; set; }
        private String _FormTitulo;
        //Atributos para el cargado del panel en el formulario bas
        private DocumentPanel _ContentView;
        private System.Collections.ObjectModel.ObservableCollection<DocumentPanel> _LstDocumentPane;
        private BaseView FrmBase;
       

        //Objetos para controlar la preguntar de guardar en el si o no
        public MessageBoxResult guardar_si_no { get; set; }
        private string _StrWebService;
        private string _RutaReporteForm;
        private TModelo _Item;
        private TModelo _ItemBuscar;

        private TabViewModel _TabGridActivo;
    
        private string _ReadOnly;
        private string _Esvisible;
        private string _Opacidad;
        private string _Enabled;
        private string _EnabledTodos;
        private string _OpacidadTodos;
        private bool _IconCancelar;
        private bool _CamposEnabled=true;
        private bool _IconTicket;

        //------------------------------------------------------    
        public DocumentPanel ContentView
        {
            get
            {
                return _ContentView;
            }

            set
            {
                _ContentView = value;
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<DocumentPanel> LstDocumentPane
        {
            get
            {
                return _LstDocumentPane;
            }

            set
            {
                _LstDocumentPane = value;
            }
        }

        public string FormTitulo
        {
            get
            {
                return _FormTitulo;
            }

            set
            {
                SetProperty(ref _FormTitulo, value, () => FormTitulo);
            }
        }

      

        public TabViewModel TabGridActivo
        {
            get
            {
                return _TabGridActivo;
            }

            set
            {
                SetProperty(ref _TabGridActivo, value, () => TabGridActivo);
            }
        }

        
        public string ReadOnly
        {
            get
            {
                return _ReadOnly;
            }

            set
            {
                SetProperty(ref _ReadOnly, value, () => ReadOnly);
            }
        }

        public virtual TModelo Item
        {
            get
            {
                return _Item;
            }

            set
            {
                SetProperty(ref _Item, value, () => Item);
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

        public TModelo ItemBuscar
        {
            get
            {
                return _ItemBuscar;
            }

            set
            {
                SetProperty(ref _ItemBuscar, value, () => ItemBuscar);
            }
        }

        

        public string Esvisible
        {
            get
            {
                return _Esvisible;
            }

            set
            {
                SetProperty(ref _Esvisible, value, () => Esvisible);
            }
        }

        public string Opacidad
        {
            get
            {
                return _Opacidad;
            }

            set
            {
                SetProperty(ref _Opacidad, value, () => Opacidad);
            }
        }

        public string Enabled
        {
            get
            {
                return _Enabled;
            }

            set
            {
                SetProperty(ref _Enabled, value, () => Enabled);
            }
        }

       
        public string EnabledTodos
        {
            get
            {
                return _EnabledTodos;
            }

            set
            {
                
                SetProperty(ref _EnabledTodos, value, () => EnabledTodos);
            }
        }

        public string OpacidadTodos
        {
            get
            {
                return _OpacidadTodos;
            }

            set
            {
                
                SetProperty(ref _OpacidadTodos, value, () => OpacidadTodos);
            }
        }

        public string RutaReporteForm
        {
            get
            {
                return _RutaReporteForm;
            }

            set
            {
                SetProperty(ref _RutaReporteForm, value, () => RutaReporteForm);
            }
        }

        public bool IconCancelar
        {
            get
            {
                return _IconCancelar;
            }

            set
            {
                SetProperty(ref _IconCancelar, value, () => IconCancelar);
            }
        }

        public bool CamposEnabled
        {
            get
            {
                return _CamposEnabled;
            }

            set
            {
                SetProperty(ref _CamposEnabled, value, () => CamposEnabled);
            }
        }

        public bool IconTicket
        {
            get
            {
                return _IconTicket;
            }

            set
            {
                SetProperty(ref _IconTicket, value, () => IconTicket);
            }
        }

        public virtual void Guardar()
        {
            try
            {
                this.OwnerVista.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                GuardarItem();
                if(guardar_si_no == MessageBoxResult.Yes)
                { 
                    TabGridActivo.Refrescar();
                    CloseAction();
                }
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public virtual void GuardarLimpiar()
        {
            try
            {
                this.OwnerVista.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                GuardarItem();
                if (guardar_si_no == MessageBoxResult.Yes)
                {
                    TabGridActivo.Refrescar();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public virtual void GuardarItem()
        {
                guardar_si_no = DXMessageBox.Show(this.OwnerVista, "¿Desea guardar la información registrada?", "Confirmación", MessageBoxButton.YesNo,
                                           MessageBoxImage.Question, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
                if (guardar_si_no == MessageBoxResult.Yes)
                {
                    Item.CanValidate = true;

                    string errores = Item.Errores();
                    if (!string.IsNullOrEmpty(errores))
                        throw new Exception(errores);

                    var metodo = Item.Id == 0 ? "add" : "update";
          
                    ServicioWS Ws = new ServicioWS(StrWebService, metodo, Item , typeof(TModelo), "item");
                    Item = (TModelo)Ws.Peticion();
                   
            }

        }
        public virtual void Eliminar()
        {
            try
            {
                TabGridActivo.Eliminar();
                CloseAction();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None,  DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public virtual void Deshacer()
        {
            try
            {
                MessageBoxResult cancelar = DXMessageBox.Show(this.OwnerVista, "¿Desea deshacer la captura o los cambios realizados?", "Confirmación", MessageBoxButton.YesNo,
                       MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
                if (cancelar == MessageBoxResult.Yes)
                {
                    if (Item.Id == 0)
                    {
                        Limpiar();
                        //CloseAction();
                    }
                    else
                    {
                        /*ServicioWS Ws = new ServicioWS(StrWebService, "get", Item.Id, typeof(TModelo), "id");
                        Item = (TModelo)Ws.Peticion();*/
                        Limpiar();
                        CargarItem();
                    }
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public virtual void Cancelar()
        {
            try
            {
                if (Item.Id == 0)
                    return;
                    MessageBoxResult cancelar = DXMessageBox.Show(this.OwnerVista, "¿Desea cancelar el documento?", "Confirmación", MessageBoxButton.YesNo,
                       MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None,  DevExpress.Xpf.Core.FloatingMode.Popup);
                if (cancelar == MessageBoxResult.Yes)
                {
                    ServicioWS Ws = new ServicioWS(StrWebService, "cancel", Item, typeof(TModelo), "item");
                    Item = (TModelo)Ws.Peticion();
                    TabGridActivo.Refrescar();
                    CloseAction();
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public virtual void CargarItem()
        {
            try
            {
                ServicioWS Ws = new ServicioWS(StrWebService, "get", ItemBuscar.Id, typeof(TModelo), "id");
                Item = (TModelo)Ws.Peticion();
                ItemBuscar = Item;
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }  
        public virtual void Anterior()
        {
            try
            {
                if (Item.Id == 0)
                    return;

                long BuscaId = TabGridActivo.Anterior();

                if (BuscaId > 0)
                {
                   
                    Limpiar();
                    ItemBuscar.Id = BuscaId;
                    CargarItem();
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public virtual void Siguiente()
        {
            try
            {
                if (Item.Id == 0)
                    return;

                long BuscaId = TabGridActivo.Siguiente();

                if (BuscaId > 0)
                {
                   
                    Limpiar();
                    ItemBuscar.Id = BuscaId;
                    CargarItem();
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public virtual void Imprimir()
        {

            try
            {
                reportParameter parametro = new reportParameter();
                parametro.name = "Id";
                parametro.value.Add(Item.Id.ToString());

                VisorReporteView FrmReporte = new VisorReporteView();
                VisorReporteViewModel VmReporte = new VisorReporteViewModel(RutaReporteForm, parametro, "pdf");
                FrmReporte.DataContext = VmReporte;
                FrmReporte.Title = this.FormTitulo;
                FrmReporte.Show();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                   MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public virtual void Limpiar()
        {
            Item = null;
            Item = Activator.CreateInstance<TModelo>();
        }
        public virtual void ImprimirTicket()
        {

          
        }
        //------------------------------------------------------
        public static FormularioViewModel<TModelo> Create()
        {
            return ViewModelSource.Create(() => new FormularioViewModel<TModelo>());
        }
        //Constructores para POCO
        public FormularioViewModel(object FrmITem)
        {
            DcGuardar = new DelegateCommand(Guardar);
            DcGuardarLimpiar = new DelegateCommand(GuardarLimpiar);
            DcEliminar = new DelegateCommand(Eliminar);
            DcDeshacer = new DelegateCommand(Deshacer);
            DcCancelar = new DelegateCommand(Cancelar);
            DcAnterior = new DelegateCommand(Anterior);
            DcSiguiente = new DelegateCommand(Siguiente);
            DcImprimir = new DelegateCommand(Imprimir);
            DcImprimirTicket = new DelegateCommand(ImprimirTicket);

            FrmBase = new BaseView();
            Item = Activator.CreateInstance<TModelo>();

            Show(FrmITem);
        }
        public FormularioViewModel(object FrmITem, TModelo item, string conexion)
        {
            DcGuardar = new DelegateCommand(Guardar);
            DcGuardarLimpiar = new DelegateCommand(GuardarLimpiar);
            DcEliminar = new DelegateCommand(Eliminar);
            DcDeshacer = new DelegateCommand(Deshacer);
            DcCancelar = new DelegateCommand(Cancelar);
            DcAnterior = new DelegateCommand(Anterior);
            DcSiguiente = new DelegateCommand(Siguiente);
            DcImprimir = new DelegateCommand(Imprimir);
            DcImprimirTicket = new DelegateCommand(ImprimirTicket);
            FrmBase = new BaseView();
            Item = Activator.CreateInstance<TModelo>();
            StrWebService = conexion;

            Show(FrmITem);

            ItemBuscar = item;
            CargarItem();
        }
        //Terminan constructores para POCO
        public FormularioViewModel()
        {
            DcGuardar           =   new DelegateCommand(Guardar);
            DcGuardarLimpiar    =   new DelegateCommand(GuardarLimpiar);
            DcEliminar          =   new DelegateCommand(Eliminar);
            DcDeshacer          =   new DelegateCommand(Deshacer);
            DcCancelar          =   new DelegateCommand(Cancelar);
            DcAnterior          =   new DelegateCommand(Anterior);
            DcSiguiente         =   new DelegateCommand(Siguiente);
            DcImprimir          =   new DelegateCommand(Imprimir);
            DcImprimirTicket    =   new DelegateCommand(ImprimirTicket);

            FrmBase = new BaseView();
            Item = Activator.CreateInstance<TModelo>();
        }
        public FormularioViewModel(int tipo)
        {
            DcGuardar = new DelegateCommand(Guardar);
            DcGuardarLimpiar = new DelegateCommand(GuardarLimpiar);
            DcEliminar = new DelegateCommand(Eliminar);
            DcDeshacer = new DelegateCommand(Deshacer);
            DcCancelar = new DelegateCommand(Cancelar);
            DcAnterior = new DelegateCommand(Anterior);
            DcSiguiente = new DelegateCommand(Siguiente);
            DcImprimir = new DelegateCommand(Imprimir);
            DcImprimirTicket = new DelegateCommand(ImprimirTicket);

            FrmBase = new BaseView();
            Item = Activator.CreateInstance<TModelo>();
        }
        public FormularioViewModel(TModelo item,string conexion)
        {
            DcGuardar = new DelegateCommand(Guardar);
            DcGuardarLimpiar = new DelegateCommand(GuardarLimpiar);
            DcEliminar = new DelegateCommand(Eliminar);
            DcDeshacer = new DelegateCommand(Deshacer);
            DcCancelar = new DelegateCommand(Cancelar);
            DcAnterior = new DelegateCommand(Anterior);
            DcSiguiente = new DelegateCommand(Siguiente);
            DcImprimir = new DelegateCommand(Imprimir);
            DcImprimirTicket = new DelegateCommand(ImprimirTicket);

            FrmBase = new BaseView();
            Item = Activator.CreateInstance<TModelo>();
            StrWebService = conexion;

            ItemBuscar = item;
            CargarItem();
        }

        //------------------------------------------------------
        public void Show(object Vista)
        {
            CargarFormulario(Vista);
            // FrmBase.Owner = VariablesGlobales.Main;
            this.OwnerVista = (FrameworkElement)Vista;
            FrmBase.Show();
        }
        public void ShowDialog(object Vista)
        {
            CargarFormulario(Vista);
            
            FrmBase.ShowDialog();
        }
        private void CargarFormulario(object Vista)
        {
            FrmBase.DataContext = this;
            if (this.CloseAction == null)
                this.CloseAction = new Action(FrmBase.Close);
            LstDocumentPane = new System.Collections.ObjectModel.ObservableCollection<DocumentPanel>();

            //Carga panel donde se muestra la informacion
            ContentView = new DocumentPanel();

            //Se asigna la vista al contendor que seria enviado al formulario
            ContentView.Content = Vista;

            LstDocumentPane.Add(ContentView);
        }
       

    }
}

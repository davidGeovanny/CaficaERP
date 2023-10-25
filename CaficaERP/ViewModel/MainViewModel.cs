using CaficaERP.Model;
using CaficaERP.Model.Administracion;
using CaficaERP.ViewModel.Administracion;
using CaficaERP.ViewModel.Inventarios;
using CaficaERP.Views;
using CaficaERP.Views.Administracion;
using CaficaERP.Views.Inventarios;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CaficaERP.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public DelegateCommand<string> _CrearPestana { get; set; }
        public DelegateCommand<int> DCModulos { get; set; }
        public DelegateCommand DCNuevoItem { get; set; }
        public DelegateCommand DCAbrirItem { get; set; }
        public DelegateCommand DCRefrescarItem { get; set; }
        public DelegateCommand DCImprimirItem { get; set; }
        public DelegateCommand DCCambiarEmpresa { get; set; }
        public ICommand DCEliminarItem { get; private set; }
        public DelegateCommand DCHome { get; set; }
        public DelegateCommand DCPruebasfrm { get; set; }
        public DelegateCommand DcActualizarPeriodo { get; set; }
        public DelegateCommand DcVerficarFechas { get; set; }
        IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(); } }


        //private GridViewModel<BaseModel,BaseView,FormularioViewModel> _TabGridActivo;
        private TabViewModel _TabGridActivo;
        private DXTabItem _TabSeleccionado;

        private System.Collections.ObjectModel.ObservableCollection<DXTabItem> _LstTabs;
        private System.Collections.ObjectModel.ObservableCollection<ItemNavBarModel> _LstNavBar;
        //private System.Collections.ObjectModel.ObservableCollection<NavBarItem> _LstNavBar;
        private Modulos _ModuloSeleccionado;
        private string _Usuario;
        private string _NombreCompletoUsuario;
        private string _Empresa;
        private DateTime _FechaInicio;
        private DateTime _FechaFin;

        private bool _Cargando;

        public MainViewModel()
        {

            _CrearPestana = new DelegateCommand<string>(CrearPestana);
            DCModulos = new DelegateCommand<int>(Modulos);
            DCNuevoItem = new DelegateCommand(NuevoItem);
            DCAbrirItem = new DelegateCommand(AbrirItem);
            DCRefrescarItem = new DelegateCommand(RefrescarItem);
            DCEliminarItem = new DelegateCommand(EliminarItem);
            DCImprimirItem = new DelegateCommand(ImprimirItem);
            DCHome = new DelegateCommand(Home);
            DCCambiarEmpresa = new DelegateCommand(CambiarEmpresa);
            DCPruebasfrm = new DelegateCommand(Pruebasfrm);
            DcActualizarPeriodo = new DelegateCommand(ActualizarPeriodo);
            DcVerficarFechas = new DelegateCommand(VerficarFechas);

            LstTabs = new System.Collections.ObjectModel.ObservableCollection<DXTabItem>();
            LstNavBar = new System.Collections.ObjectModel.ObservableCollection<ItemNavBarModel>();
            LstNavBar.Add(new ItemNavBarModel()); //para que aparesca el navbar cuando recien se abre el sistema
            DXTabItem Tab = new DXTabItem();
            Tab.Header = "Home";
            Tab.Name = "Home";
            Tab.AllowHide = DevExpress.Utils.DefaultBoolean.False;
            Tab.Content = new MenuModulosView();
            Tab.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            LstTabs.Add(Tab);

            ModuloSeleccionado = new Modulos();

           

        }

        public void CargarDatosLogin()
        {
            string[] datos = new string[3];
            ServicioWS ws = new ServicioWS("ServiciosERP/WSMenu.svc", "getDatosLogin", null, typeof(string[]), null);
            datos = (string[])ws.Peticion();
            Usuario = datos[0];
            NombreCompletoUsuario = datos[1];
            VariablesGlobales.UsuarioFirmado = Usuario;
            Empresa = datos[2];

            FechaInicio = new DateTime(VariablesGlobales.FechaActual.Value.Year, VariablesGlobales.FechaActual.Value.Month, 1);
            FechaFin = FechaInicio.AddMonths(1).AddDays(-1);

        }


        public System.Collections.ObjectModel.ObservableCollection<DXTabItem> LstTabs
        {
            get
            {
                return _LstTabs;
            }

            set
            {
                SetProperty(ref _LstTabs, value, () => LstTabs);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<ItemNavBarModel> LstNavBar
        {
            get
            {
                return _LstNavBar;
            }

            set
            {
                SetProperty(ref _LstNavBar, value, () => LstNavBar);
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

        public DXTabItem TabSeleccionado
        {
            get
            {
                return _TabSeleccionado;
            }

            set
            {
                SetProperty(ref _TabSeleccionado, value, () => _TabSeleccionado);
                if (TabSeleccionado != null && TabSeleccionado.Name != "Home")
                {
                    TabGridActivo = (TabViewModel)TabSeleccionado.DataContext;
                    TabGridActivo.Titulo = TabSeleccionado.Header.ToString();
                    if (TabGridActivo.FiltradoFechas == true)
                        VerficarFechas();
                }
                else
                    TabGridActivo = null;
                    
            }
        }

        public Modulos ModuloSeleccionado
        {
            get
            {
                return _ModuloSeleccionado;
            }

            set
            {
                SetProperty(ref _ModuloSeleccionado, value, () => ModuloSeleccionado);
            }
        }

        public string Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                SetProperty(ref _Usuario, value, () => Usuario);
            }
        }

        public string NombreCompletoUsuario
        {
            get
            {
                return _NombreCompletoUsuario;
            }

            set
            {
                SetProperty(ref _NombreCompletoUsuario, value, () => NombreCompletoUsuario);
            }
        }

        public string Empresa
        {
            get
            {
                return _Empresa;
            }

            set
            {
                SetProperty(ref _Empresa, value, () => Empresa);
            }
        }

        public bool Cargando
        {
            get
            {
                return _Cargando;
            }

            set
            {
                SetProperty(ref _Cargando, value, () => Cargando);
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return _FechaInicio;
            }

            set
            {
                SetProperty(ref _FechaInicio, value, () => FechaInicio);
                VariablesGlobales.FechaInicio = _FechaInicio;
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return _FechaFin;
            }

            set
            {
                SetProperty(ref _FechaFin, value, () => FechaFin);
                VariablesGlobales.FechaFin = _FechaFin;
            }
        }
        public void ActualizarPeriodo()
        {
            try
            {
                if(TabGridActivo != null)
                {
                    Cargando = true; 
                    TabGridActivo.Refrescar();
                    TabGridActivo.FechaInicioFiltrado = VariablesGlobales.FechaInicio;
                    TabGridActivo.FechaFinFiltrado = VariablesGlobales.FechaFin;
                    Cargando = false;
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void VerficarFechas()
        {
            try
            {
                if(TabGridActivo.FechaInicioFiltrado != VariablesGlobales.FechaInicio || TabGridActivo.FechaFinFiltrado != VariablesGlobales.FechaFin)
                {
                    MessageBoxResult pregunta = DXMessageBox.Show(VariablesGlobales.Main, "El perido de fechas a cambiado ¿Desea recargar la informacion con el nuevo periodo?", "Confirmación", MessageBoxButton.YesNo,
                       MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
                    if (pregunta == MessageBoxResult.Yes)
                    {
                        TabGridActivo.Refrescar();
                        TabGridActivo.FechaInicioFiltrado = VariablesGlobales.FechaInicio;
                        TabGridActivo.FechaFinFiltrado = VariablesGlobales.FechaFin;
                    }
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void CrearPestana(string parameter)
        {
            try
            {
                String[] Objetos = parameter.Split(',');
                //Id Vista,Tipo Vista,GridViewModel , Nombre y Header del tab, Ruta WS, ruta del reporte grid listado jasperserver grid,
                //gridviewespecial, ruta del reporte fromulario jasper server 
                if (Objetos[1] == "FORMULARIO")
                {

                    DXTabItem Tab = new DXTabItem();



                    //Buscar si ya existe un tab abierto con el mismo nombre
                    Tab = LstTabs.Where(n => n.Name == Objetos[3].Replace(" ", "")).FirstOrDefault();

                    if (Tab == null)
                    {
                        Cargando = true;

                        //Posicion 0=ViewModel,Posicion 1=Header del tab,
                        //Posicion 2=Web servicie para carga el grid,Posicion 3=Reporte que se liga con el grid
                        //Posicion 4=GrindView opcional para una funcinalidad especifica
                        Tab = new DXTabItem();
                        Tab.Name = Objetos[3].Replace(" ", "");
                        Tab.Header = Objetos[3];
                        Tab.IsSelected = true;


                        if (Objetos[6] == "null")
                            Tab.Content = new GridBaseView(); // Carga el GridView dinamico
                        else
                            Tab.Content = Activator.CreateInstance(Type.GetType("CaficaERP.Views." + Objetos[6])); //Carga un grid perzonalizado

                        Tab.DataContext = Activator.CreateInstance(Type.GetType("CaficaERP.ViewModel." + Objetos[2]), Objetos[4], Objetos[5], Objetos[7]);
                        LstTabs.Add(Tab);

                        Cargando = false;


                    }
                    else
                    {
                        Tab.IsSelected = true;
                    }
                }
                else if(Objetos[1] == "REPORTE")
                {
                    VisorReporteView FrmReporte = new VisorReporteView();
                    VisorReporteViewModel VmReporte = new VisorReporteViewModel(Convert.ToInt16(Objetos[0].ToString()),Objetos[5], "pdf");
                    FrmReporte.DataContext = VmReporte;
                    FrmReporte.Title = Objetos[3];
                    FrmReporte.Show();
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }

        public void Modulos(int parameter)
        {
            try
            {
                LstNavBar.Clear();
                //ModuloId
                int moduloid = parameter;
                ServicioWS wsmodulo = new ServicioWS("ServiciosERP/Administracion/WSModulos.svc", "get", moduloid, typeof(Modulos), "id");
                ModuloSeleccionado = (Modulos)wsmodulo.Peticion();
                ServicioWS ws = new ServicioWS("ServiciosERP/WSMenu.svc", "getMenuNavBar", moduloid, typeof(System.Collections.ObjectModel.ObservableCollection<ItemNavBarModel>), "moduloid");
                foreach (ItemNavBarModel ItemWs in (System.Collections.ObjectModel.ObservableCollection<ItemNavBarModel>)ws.Peticion())
                {
                    LstNavBar.Add(ItemWs);
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void NuevoItem()
        {

            try
            {
                if(TabGridActivo != null)
                    TabGridActivo.Nuevo();
            }
            catch (Exception)
            {


            }
        }
        public void AbrirItem()
        {
            try
            {
                if (TabGridActivo != null)
                    TabGridActivo.Abrir();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void ImprimirItem()
        {
            try
            {
                if(TabGridActivo != null)
                    TabGridActivo.Imprimir();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void RefrescarItem()
        {
            try
            {
                if(TabGridActivo != null)
                {
                    Cargando = true;
                    TabGridActivo.Refrescar();
                    Cargando = false;
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void EliminarItem()
        {
            try
            {
                if(TabGridActivo != null)
                    TabGridActivo.Eliminar();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void Home()
        {
            try
            {
                TabSeleccionado = LstTabs.ToList()[0];
                TabSeleccionado.IsSelected = true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CambiarEmpresa()
        {
            try
            {
                if (LstTabs.Count == 1)
                {
                    LoginEmpresasView FrmEmpresa = new LoginEmpresasView();
                    LoginEmpresasViewModel ViewModelLogin = new LoginEmpresasViewModel(true);
                    FrmEmpresa.DataContext = ViewModelLogin;
                    FrmEmpresa.ShowDialog();
                    //ViewModelLogin.Refrescar();
                    string[] datos = new string[3];
                    ServicioWS ws = new ServicioWS("ServiciosERP/WSMenu.svc", "getDatosLogin", null, typeof(string[]), null);
                    datos = (string[])ws.Peticion();
                    Empresa = datos[2];
                }
                else
                {
                    DXMessageBox.Show(VariablesGlobales.Main, "Cierre todas las pestañas para  poder \n realizar el cambio de empresa.", "Error", MessageBoxButton.OK,
                                       MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
                }
            }
            catch (Exception ex)
            {
             
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                         MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }


        }
        public void Pruebasfrm()
        {
            try
            {
            



             /*   VistasFormView FrmVistas = new VistasFormView();
                  VistasFormViewModel RolesVM = new VistasFormViewModel();
                   RolesVM.FormTitulo = "Roles";
                RolesVM.Show(FrmVistas);*/

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }

    }
}

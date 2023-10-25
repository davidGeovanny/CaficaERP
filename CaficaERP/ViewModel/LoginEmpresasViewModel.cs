using CaficaERP.Model.Administracion;
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

namespace CaficaERP.ViewModel
{
    public class LoginEmpresasViewModel : ViewModelBase
    {
        private System.Collections.ObjectModel.ObservableCollection<BDEmpresas> _LstEmpresas;
        public DelegateCommand DcEntrar { get; set; }
        public DelegateCommand CloseCommand { get; set; }
        private BDEmpresas _BdEmpresaSeleccionado;
        private bool cambiarEmpresa ;
        public LoginEmpresasViewModel(bool cambioEmpresa)
        {
            DcEntrar = new DelegateCommand(Entrar);
            CloseCommand = new DelegateCommand(Cerrar);
            LstEmpresas = new System.Collections.ObjectModel.ObservableCollection<BDEmpresas>();
            cambiarEmpresa = cambioEmpresa;
            Refrescar();
        }
        private void Cerrar()
        {
            if (cambiarEmpresa == false)
            {
                Application.Current.Shutdown();

            }
            else
            {
                for (int i = 0; i < Application.Current.Windows.Count; i++)
                {
                    if (Application.Current.Windows[i].DataContext == this)
                    {
                        Application.Current.Windows[i].Close();
                    }
                }
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<BDEmpresas> LstEmpresas
        {
            get
            {
                return _LstEmpresas;
            }

            set
            {
                SetProperty(ref _LstEmpresas, value, () => LstEmpresas);
            }
        }

        public BDEmpresas BdEmpresaSeleccionado
        {
            get
            {
                return _BdEmpresaSeleccionado;
            }

            set
            {
                SetProperty(ref _BdEmpresaSeleccionado, value, () => BdEmpresaSeleccionado);
            }
        }

        public void Entrar()
        {
            try
            {
                if (BdEmpresaSeleccionado != null )
                { 
                    ServicioWS ws = new ServicioWS("ServiciosERP/WSEmpresas.svc", "getTokenEmpresas", BdEmpresaSeleccionado, typeof(string), "empresa");
                    VariablesGlobales.TokenEmpresa = (string)ws.Peticion();
                    VariablesGlobales.BdEmpresa = BdEmpresaSeleccionado.RFC;
                    VariablesGlobales.RazoSocialEmpresa = BdEmpresaSeleccionado.RazonSocial;
                    VariablesGlobales.PasswordReportes = BdEmpresaSeleccionado.ContrasenaReportes;
                    VariablesGlobales.MetodoCosteoEmpresa = BdEmpresaSeleccionado.MetodoCosteo;

                    //Carga la ventana principal
                    if (cambiarEmpresa==false)
                    {
                        //  MainWindow FrmMain = new MainWindow();
                        //  FrmMain.Show();
                        MainViewModel mv = (MainViewModel)VariablesGlobales.Main.DataContext;
                        mv.CargarDatosLogin();
                        VariablesGlobales.Main.Show();
                        
                    }

                    //Cierra la venta activar
                    //DXMessageBox.Show(Convert.ToString(Application.Current.Windows.Count));
                    for (int i = 0; i <Application.Current.Windows.Count; i++)
                    {
                        if (Application.Current.Windows[i].DataContext == this)
                        {
                            Application.Current.Windows[i].Close();
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
              
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                        MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void Refrescar()
        {
            try
            {
                ServicioWS ws = new ServicioWS("ServiciosERP/WSEmpresas.svc", "getEmpresas", null, typeof(System.Collections.ObjectModel.ObservableCollection<BDEmpresas>), null);
                LstEmpresas = (System.Collections.ObjectModel.ObservableCollection<BDEmpresas>)ws.Peticion();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
    }
}

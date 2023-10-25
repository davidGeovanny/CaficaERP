using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using CaficaERP.Views;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CaficaERP.Model;
using System.Threading;
using System.Reflection;
using System.Diagnostics;

namespace CaficaERP.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {   
        public DelegateCommand DCEntrar { get; set; }
        public DelegateCommand InitCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }
        public virtual int Delay { get; set; }
     

        protected ISplashScreenService SplashScreenService { get { return this.GetService<ISplashScreenService>(); } }

       

        private void Inicializar()
        {

            VariablesGlobales.Version = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductVersion;
            Delay = 1;
            SplashScreenService.SetSplashScreenState("Versión " + VariablesGlobales.Version);
            SplashScreenService.ShowSplashScreen();
            
            Thread.Sleep(TimeSpan.FromSeconds(Delay));
            SplashScreenService.SetSplashScreenProgress(25, 100);
            //Crear el objeto main
            MainWindow FrmMain = new MainWindow();
            SplashScreenService.SetSplashScreenProgress(50, 100);
            Thread.Sleep(TimeSpan.FromSeconds(Delay));
          //  SplashScreenService.SetSplashScreenState("Listo.");
            SplashScreenService.SetSplashScreenProgress(100, 100);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            SplashScreenService.HideSplashScreen();
        }

        private void Cerrar()
        {
            Application.Current.Shutdown();
        }
        public LoginModel Login
        {
            get
            {
                return _Login;
            }

            set
            {
                _Login = value;
            }
        }

       

        private LoginModel _Login;
       

        public LoginViewModel()
        {
            Login = new LoginModel();
            DCEntrar = new DelegateCommand(IniciarSesion);
            InitCommand = new DelegateCommand(Inicializar);
            CloseCommand = new DelegateCommand(Cerrar);
        }

        public void IniciarSesion()
        {
            try
            {
                if (string.IsNullOrEmpty(Login.Usuario))
                       throw new Exception("Campo usuario vacio.");
                if (string.IsNullOrEmpty(Login.Contrasena))
                    throw new Exception("Campo constraseña vacio.");

                ServicioWS Ws=new ServicioWS("ServiciosERP/WSLogin.svc", "Login", Login, typeof(string), "acceso");
                VariablesGlobales.Token=(string)Ws.Peticion();

                if(VariablesGlobales.Token != null)
                { 
                    LoginEmpresasView FrmEmpresa = new LoginEmpresasView();
                    LoginEmpresasViewModel ViewModelLogin = new LoginEmpresasViewModel(false);
                    FrmEmpresa.DataContext = ViewModelLogin;
                    FrmEmpresa.Show();
                    //ViewModelLogin.Refrescar();
                    
                    Application.Current.MainWindow.Close();


                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error");
            }     
        }
    }
}

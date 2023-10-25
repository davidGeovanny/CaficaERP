using CaficaERP.Model.Administracion;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.WindowsUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Core;

namespace CaficaERP.ViewModel.Administracion
{
    public class UsuariosFormViewModel :FormularioViewModel<Usuarios>
    {
       
        // private List<object> _RolesSeleccionados;
        private Roles _RolesSeleccionados;
        private string _ConfirmacionContrasena;
        public DelegateCommand DcEliminarRol { get; set; }
        

        //Constructor para nuevo Usuario
        public UsuariosFormViewModel()
        {
            
            CargarStatus();
            CargarRoles();

        }
        public UsuariosFormViewModel(Usuarios item, string conexion) : base(item, conexion)
        {
            
        }
        public override void GuardarItem()
        {
            if (ConfirmacionContrasena != Item.Contrasena)
                throw new Exception("Las contraseñas no son iguales");
            Item.UsuariosRoles.Clear();
            Item.UsuariosRoles.Add(new UsuariosRoles { RolId = RolesSeleccionados.Id, UsuarioCreo = "SISTEMAS", UsuarioId = Item.Id });
            base.GuardarItem();
            ConfirmacionContrasena = ""; //para textedit confirmar contraseña
            RolesSeleccionados = null; //para limpiar combo, Rol, ya se quedo cuando era multirol

        }
        //Constructor para abrir Usuario
        /*   public UsuariosFormViewModel(UsuariosModel usuario)
           {
               DcEliminarRol = new DelegateCommand(Eliminar);
               CargarStatus();
               CargarRoles();
               ReadOnly = "True"; //desabilita la escritura del usuario, cuando ya esta creado ya no se puede modificar el usuario
               //Carga el objeto directamente del WS
               ServicioWS Ws = new ServicioWS("ServiciosERP/Administracion/WSUsuarios.svc", "getUsuario", usuario.Id, typeof(UsuariosModel), "ID");
               Usuario = (UsuariosModel)Ws.Peticion();
               //RolesSeleccionados =new List<object>();
               RolesSeleccionados = new RolesModel();
               foreach (UsuariosRolesModel UsuarioRol in Usuario.UsuariosRoles)
               {
                   //RolesModel Rol = LstRoles.Single(r => r.Id == UsuarioRol.RolId);
                   //  RolesSeleccionados.Add(Rol);
                   RolesSeleccionados = LstRoles.Single(r => r.Id == UsuarioRol.RolId);
               }


               Usuario.UsuariosRoles.Clear();
           }*/


        //  public List<object> RolesSeleccionados
        public Roles RolesSeleccionados
        {
            get
            {
                return _RolesSeleccionados;
            }

            set
            {
                SetProperty(ref _RolesSeleccionados, value, () => RolesSeleccionados);
              
            }
        }

        public string ConfirmacionContrasena
        {
            get
            {
                return _ConfirmacionContrasena;
            }

            set
            {
                SetProperty(ref _ConfirmacionContrasena, value, () => ConfirmacionContrasena);

            }
        }
        public override void CargarItem()
        {
            CargarStatus();
            CargarRoles();
            base.CargarItem();
            RolesSeleccionados = new Roles();
            ReadOnly = "True"; //desabilita la escritura del usuario, cuando ya esta creado ya no se puede modificar el usuario
            foreach (UsuariosRoles UsuarioRol in Item.UsuariosRoles)
            {
                //RolesModel Rol = LstRoles.Single(r => r.Id == UsuarioRol.RolId);
                //  RolesSeleccionados.Add(Rol);
                RolesSeleccionados = LstRoles.Single(r => r.Id == UsuarioRol.RolId);
            }


               Item.UsuariosRoles.Clear();
        }



        /*      public override void Guardar()
              {
                  try
                  {
                      Usuario.CanValidate = true;

                      if (ConfirmacionContrasena != Usuario.Contrasena)
                             throw new Exception("Las contraseñas no son iguales");

                       string strMetodo = Usuario.Id == 0 ? "addUsuarios" : "updateUsuarios";

                       //Limpiar los roles para que no se dupliquein
                       Usuario.UsuariosRoles.Clear();
                      Usuario.UsuariosRoles.Add(new UsuariosRolesModel { RolId = RolesSeleccionados.Id,UsuarioCreo="SISTEMAS", UsuarioId = Usuario.Id });
                  //    foreach (RolesModel rol in RolesSeleccionados)
                  //    {
                   //       Usuario.UsuariosRoles.Add(new UsuariosRolesModel { RolId = rol.Id, UsuarioCreo = "SISTEMAS",UsuarioId=Usuario.Id});
                   //  }

                      //Validar campos
                      string errores = Usuario.Errores();
                      if (!string.IsNullOrEmpty(errores))
                          throw new Exception(errores);


                       ServicioWS Ws = new ServicioWS("ServiciosERP/Administracion/WSUsuarios.svc", strMetodo, Usuario, typeof(UsuariosModel), "usuario");

                       Usuario = (UsuariosModel)Ws.Peticion();
                       TabGridActivo.Refrescar();
                       CloseAction();

                  }
                  catch (Exception ex)
                  {

                      RaisePropertyChanged(() => Usuario);
                      DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                                 MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);

                  }    
              }*/


    }
}

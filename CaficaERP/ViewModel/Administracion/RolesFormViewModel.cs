using CaficaERP.Model;
using CaficaERP.Model.Administracion;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Administracion
{
    public class RolesFormViewModel : FormularioViewModel<Roles>
    {
        private System.Collections.ObjectModel.ObservableCollection<PermisosModel> _LstPermisos;
        private System.Collections.ObjectModel.ObservableCollection<PermisosModel> _LstPermisosSeleccionados;
        private PermisosModel _PermisoSeleccionado;
        private bool _Administrador;
        public DelegateCommand DcCell { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<PermisosModel> LstPermisos
        {
            get
            {
                return _LstPermisos;
            }

            set
            {
                SetProperty(ref _LstPermisos, value, () => LstPermisos);
            }
        }

        public PermisosModel PermisoSeleccionado
        {
            get
            {
                return _PermisoSeleccionado;
            }

            set
            {
                _PermisoSeleccionado = value;
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<PermisosModel> LstPermisosSeleccionados
        {
            get
            {
                return _LstPermisosSeleccionados;
            }

            set
            {
                _LstPermisosSeleccionados = value;
            }
        }
        public bool Administrador
        {
            get
            {
                return _Administrador;
            }

            set
            {
                _Administrador = value;
            }
        }
        public RolesFormViewModel()
        {
            DcCell = new DelegateCommand(Cell);

            LstPermisos = new System.Collections.ObjectModel.ObservableCollection<PermisosModel>();
            LstPermisosSeleccionados = new System.Collections.ObjectModel.ObservableCollection<PermisosModel>();
            LstBDEmpresas = new System.Collections.ObjectModel.ObservableCollection<BDEmpresas>();

            LoadPermisos();
            CargarEmpresas();
        }
        public RolesFormViewModel(Roles item, string conexion) : base(item, conexion)
        {

        }
        public void Cell()
        {
            try
            {
                PermisoSeleccionado.IsChecked = !PermisoSeleccionado.IsChecked;
                //Buscar el padre del check seleccionado si es que lo tiene
                var permisopadre = LstPermisos.SingleOrDefault(p => p.Index == PermisoSeleccionado.ParentId);

                var permisohermanos = LstPermisos.Where(p => p.ParentId == PermisoSeleccionado.ParentId).Where(h => h.IsChecked == true).Where(p => p.Index != PermisoSeleccionado.Index);


                if (permisopadre != null)
                {
                    if (permisohermanos.ToList().Count == 0)
                    {
                        permisopadre.IsChecked = PermisoSeleccionado.IsChecked;
                        var permisopadremayor = LstPermisos.SingleOrDefault(p => p.Index == permisopadre.ParentId);
                        if (permisopadremayor != null)
                            permisopadremayor.IsChecked = true;
                    }
                }


                //Selecciono todos los hijos del padre seleccionado
                var Permisos = LstPermisos.Where(p => p.ParentId == PermisoSeleccionado.Index);

                //Recorremos los hijos
                foreach (PermisosModel permiso in Permisos)
                {
                    permiso.IsChecked = PermisoSeleccionado.IsChecked;
                    var PermisosHijos = LstPermisos.Where(p => p.ParentId == permiso.Index);
                    foreach (PermisosModel permisohijo in PermisosHijos)
                    {
                        permisohijo.IsChecked = PermisoSeleccionado.IsChecked;
                    }
                }
                /*System.Collections.ObjectModel.ObservableCollection<PermisosModel> Temp_LstPermisos=new System.Collections.ObjectModel.ObservableCollection<PermisosModel>();
                Temp_LstPermisos = LstPermisos;
                LstPermisos = null;
                LstPermisos = Temp_LstPermisos;*/
                RaisePropertyChanged(() => LstPermisos.ToList()[0].IsChecked);

            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                      MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void LoadRol()
        {
            try
            {
                //Activa la casilla de administrador
                Administrador = Item.Administrador == "Si" ? true : false;

                //Activa las casilla de las empresas con acceso
                foreach (BDEmpresasRoles empresa in Item.BDEmpresasRoles)
                {
                    var BdEmpresa = LstBDEmpresas.Where(e => e.Id == empresa.BDEmpresaId).FirstOrDefault();
                    BdEmpresa.isChecked = true;
                }

                //Activa los permisos con derecho
                foreach (RolesAcciones roles in Item.RolesAcciones)
                {
                    var RolAccion = LstPermisos.Where(t => t.Tipo == "Accion").Where(r => r.Id == roles.AccionId).FirstOrDefault();
                    RolAccion.IsChecked = true;

                    //Buscas a la papa Vista
                    var RolVista = LstPermisos.Where(t => t.Tipo == "Vista").Where(v => v.Index == RolAccion.ParentId).FirstOrDefault();
                    RolVista.IsChecked = true;

                    //Buscas a la papa Modulo
                    var RolModulo = LstPermisos.Where(t => t.Tipo == "Modulo").Where(m => m.Index == RolVista.ParentId).FirstOrDefault();
                    RolModulo.IsChecked = true;
                }
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }
        public void LoadPermisos()
        {
            try
            {
                System.Collections.ObjectModel.ObservableCollection<PermisosModelTemp> LstPermisosTepm = new System.Collections.ObjectModel.ObservableCollection<PermisosModelTemp>();

                ServicioWS ws = new ServicioWS("ServiciosERP/Administracion/WsRoles.svc", "getPermisos", null, typeof(System.Collections.ObjectModel.ObservableCollection<PermisosModelTemp>), null);
                LstPermisosTepm = (System.Collections.ObjectModel.ObservableCollection<PermisosModelTemp>)ws.Peticion();

                foreach (PermisosModelTemp Permiso in LstPermisosTepm)
                {

                    LstPermisos.Add(new PermisosModel
                    {
                        Id = Permiso.Id,
                        Index = Permiso.Index,
                        Nombre = Permiso.Nombre,
                        HasChild = Permiso.HasChild,
                        IsChecked = Permiso.IsChecked,
                        ParentId = Permiso.ParentId,
                        Tipo = Permiso.Tipo
                    });
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void GuardarItem()
        {
            //Verifica si el rol va tener privilegios de administrador
            Item.Administrador = Administrador == true ? "Si" : "No";

            //Agregar la relacion empresa roles
            Item.BDEmpresasRoles.Clear();
            foreach (BDEmpresas empresa in LstBDEmpresas)
            {
                if (empresa.isChecked == true)
                {
                    Item.BDEmpresasRoles.Add(new BDEmpresasRoles { BDEmpresaId = empresa.Id, RolId = Item.Id });
                }
            }

            //Agregar la relacion acciones vista
            Item.RolesAcciones.Clear();
            foreach (PermisosModel permiso in LstPermisos.ToList().Where(a => a.Tipo == "Accion").Where(i => i.IsChecked == true))
            {
                Item.RolesAcciones.Add(new RolesAcciones { AccionId = permiso.Id, RolId = Item.Id });
            }

            base.GuardarItem();
        }
        public override void CargarItem()
        {
            try
            {
                base.CargarItem();
                DcCell = new DelegateCommand(Cell);

                LstPermisos = new System.Collections.ObjectModel.ObservableCollection<PermisosModel>();
                LstPermisosSeleccionados = new System.Collections.ObjectModel.ObservableCollection<PermisosModel>();
                LstBDEmpresas = new System.Collections.ObjectModel.ObservableCollection<BDEmpresas>();
                ReadOnly = "True";
                LoadPermisos();
                CargarEmpresas();

                LoadRol();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public override void Limpiar()
        {
            try
            {
                base.Limpiar();
                LstPermisos.ToList().ForEach(c => c.IsChecked = false);
                //LstBDEmpresas.ToList().ForEach(c => c.isChecked = false);
                CargarEmpresas();
                Administrador = false;
                RaisePropertyChanged(() => LstBDEmpresas);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
    }
}

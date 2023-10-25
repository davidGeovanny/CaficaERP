using CaficaERP.Model;
using CaficaERP.Model.Administracion;
using CaficaERP.Views.Administracion;
using System;
using System.Collections.Generic;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.WindowsUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Xpf.Core;
using DevExpress.Mvvm;

namespace CaficaERP.ViewModel.Administracion
{
    public class VistasFormViewModel : FormularioViewModel<Vistas>
    {
        
        private Sistemas _Sistemasm;
        private GruposVistas _GVistas;
        private System.Collections.ObjectModel.ObservableCollection<Tablas> _LstTablas;
        private System.Collections.ObjectModel.ObservableCollection<PermisosModel> _LstGruposVistas;
        private System.Collections.ObjectModel.ObservableCollection<VistasFiltrosReportes> _LstFiltrosReportes;
        private PermisosModel _GrupoSeleccionado;
        private PermisosModel _PermisoSeleccionado;
        private System.Collections.ObjectModel.ObservableCollection<PermisosModel> _LstGrupoSeleccionados;
        private VistasFiltrosReportes _FiltroReporteSeleccionado;
       
        public DelegateCommand DcCell { get; set; }
        private string _FiltrosVisibility;
        private string _TablasVisibility;

        private object _TipoVistaSeleccionado;
        public DelegateCommand DcEliminaFila { get; set; }
        


        public VistasFormViewModel()
        {
            DcCell = new DelegateCommand(Cell);
            DcEliminaFila = new DelegateCommand(EliminaFila);
            GVistas = new GruposVistas();
            Sistemasm = new Sistemas();
            LstTablas= new System.Collections.ObjectModel.ObservableCollection<Tablas>();
            LstGruposVistas = new System.Collections.ObjectModel.ObservableCollection<PermisosModel>();
            LstFiltrosReportes = new System.Collections.ObjectModel.ObservableCollection<VistasFiltrosReportes>();
            LoadTablas();
            LoadPermisos();
            CargarTipoVista();
            CargarTipoFiltro();
            TablasVisibility = "Collapsed";
            FiltrosVisibility = "Collapsed";

        }


        public void EliminaFila()
        {
            //Metodo para eliminar registros del grid
           try
            {
                              LstFiltrosReportes.Remove(FiltroReporteSeleccionado);
                              FiltroReporteSeleccionado = null;
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
               MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None,FloatingMode.Popup);
            }
        }

        public VistasFormViewModel(Vistas item, string conexion) : base(item, conexion)
        {
        }

        public override void CargarItem()
        {

            DcCell = new DelegateCommand(Cell);

            DcEliminaFila = new DelegateCommand(EliminaFila);
            GVistas = new GruposVistas();
            Sistemasm = new Sistemas();
            LstTablas = new System.Collections.ObjectModel.ObservableCollection<Tablas>();
            LstGruposVistas = new System.Collections.ObjectModel.ObservableCollection<PermisosModel>();
            LstFiltrosReportes = new System.Collections.ObjectModel.ObservableCollection<VistasFiltrosReportes>();
            CargarTipoVista();
            CargarTipoFiltro();
            
            LoadTablas();
            LoadPermisos();
            base.CargarItem();
            LoadVista();
            TipoVistaSeleccionado = new { nombre = Item.Tipo };
       
      }

    public  System.Collections.ObjectModel.ObservableCollection<Tablas> LstTablas
        {
            get
            {
                return _LstTablas;
            }

            set
            {
                SetProperty(ref _LstTablas, value, () => LstTablas);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<PermisosModel> LstGruposVistas
        {
            get
            {
                return _LstGruposVistas;
            }

            set
            {
                SetProperty(ref _LstGruposVistas, value, () => LstGruposVistas);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<PermisosModel> LstGrupoSeleccionados
        {
            get
            {
                return _LstGrupoSeleccionados;
            }

            set
            {
                SetProperty(ref _LstGrupoSeleccionados, value, () => LstGrupoSeleccionados);
            }
        }

        public PermisosModel GrupoSeleccionado
        {
            get
            {
                return _GrupoSeleccionado;
            }

            set
            {
                SetProperty(ref _GrupoSeleccionado, value, () => GrupoSeleccionado);
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

        public GruposVistas GVistas
        {
            get
            {
                return _GVistas;
            }

            set
            {
                SetProperty(ref _GVistas, value, () => GVistas);
            }
        }

        public Sistemas Sistemasm
        {
            get
            {
                return _Sistemasm;
            }

            set
            {
                SetProperty(ref _Sistemasm, value, () => Sistemasm);
            }
        }

       

        public System.Collections.ObjectModel.ObservableCollection<VistasFiltrosReportes> LstFiltrosReportes
        {
            get
            {
                return _LstFiltrosReportes;
            }

            set
            {
             
                SetProperty(ref _LstFiltrosReportes, value, () => LstFiltrosReportes);
            }
        }

        public string FiltrosVisibility
        {
            get
            {
                return _FiltrosVisibility;
            }

            set
            {
              
                SetProperty(ref _FiltrosVisibility, value, () => FiltrosVisibility);
            }
        }

        public string TablasVisibility
        {
            get
            {
                return _TablasVisibility;
            }

            set
            {
                SetProperty(ref _TablasVisibility, value, () => TablasVisibility);
            }
        }

        public object TipoVistaSeleccionado
        {
            get
            {
                return _TipoVistaSeleccionado;
            }

            set
            {
                SetProperty(ref _TipoVistaSeleccionado, value, () => TipoVistaSeleccionado);
                if(TipoVistaSeleccionado!=null)
                {
                    if (TipoVistaSeleccionado.GetType().GetProperty("nombre").GetValue(TipoVistaSeleccionado).ToString() == "FORMULARIO")
                    {
                        FiltrosVisibility = "Collapsed";
                        TablasVisibility = "Visible";
                    }
                    else if (TipoVistaSeleccionado.GetType().GetProperty("nombre").GetValue(TipoVistaSeleccionado).ToString() == "REPORTE")
                    {
                        FiltrosVisibility = "Visible";
                        TablasVisibility = "Collapsed";
                    }
                    else
                    {
                        FiltrosVisibility = "Collapsed";
                        TablasVisibility = "Collapsed";
                    }
                }
                else
                {
                    FiltrosVisibility = "Collapsed";
                    TablasVisibility = "Collapsed";
                }
              

            }
        }

       

        public VistasFiltrosReportes FiltroReporteSeleccionado
        {
            get
            {
                return _FiltroReporteSeleccionado;
            }

            set
            {
                SetProperty(ref _FiltroReporteSeleccionado, value, () => FiltroReporteSeleccionado);
            }
        }

       
        public void LoadTablas()
        {
            try
            {
                ServicioWS ws = new ServicioWS("ServiciosERP/Administracion/WSTablas.svc", "getall", null, typeof(System.Collections.ObjectModel.ObservableCollection<Tablas>), null);
                LstTablas = (System.Collections.ObjectModel.ObservableCollection<Tablas>)ws.Peticion();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public override void GuardarItem()
        {
            /*Rol.CanValidate = true;

 string errores = Rol.Errores();
 if (!string.IsNullOrEmpty(errores))
     throw new Exception(errores);*/

            string strMetodo = Item.Id == 0 ? "addVista" : "updateVista";


            //Agregar la relacion tablas vistas                
            Item.VistasFiltrosReportes.Clear();
            foreach (VistasFiltrosReportes filtro in LstFiltrosReportes)
            {
                filtro.VistaId = Item.Id;
                    Item.VistasFiltrosReportes.Add(filtro);
            }

            //Agregar la relacion tablas vistas                
            Item.VistasTablas.Clear();
            foreach (Tablas tabla in LstTablas)
            {
                if (tabla.isChecked == true)
                {
                    Item.VistasTablas.Add(new VistasTablas { TablaId = tabla.Id, VistaId = Item.Id });

                }
            }

            //Agregar la relacion Gruposvista -->Sistemas->Modulo
            Item.VistasGruposVistas.Clear();
            foreach (PermisosModel grupo in LstGruposVistas.ToList().Where(a => a.Tipo == "Vista").Where(i => i.IsChecked == true))
            {

                var grupomodulo = LstGruposVistas.ToList().Where(a => a.Tipo == "Modulo").Where(b => b.Index == grupo.ParentId).First();
                var gruposistema = LstGruposVistas.ToList().Where(a => a.Tipo == "Sistema").Where(i => i.Index == grupomodulo.ParentId).First();

                Item.VistasGruposVistas.Add(new VistasGruposVistas { GrupoVistaId = grupo.Id, ModuloId = grupomodulo.Id, SistemaId = gruposistema.Id, VistaId = Item.Id });

            }
            base.GuardarItem();
        }
        public void LoadVista()
        {
            try
            {
               
                //Activa las casilla de las empresas con acceso
                foreach (VistasTablas tabla in Item.VistasTablas)
                {
                    var Tablas = LstTablas.Where(e => e.Id == tabla.TablaId).FirstOrDefault();
                    Tablas.isChecked = true;
                }


                //Activa los permisos con derecho
                foreach (VistasGruposVistas vistasgvistas in Item.VistasGruposVistas)
                {
                    var vistagrupo = LstGruposVistas.Where(t => t.Tipo == "Vista").Where(r => r.Id == vistasgvistas.GrupoVistaId).FirstOrDefault();
                    vistagrupo.IsChecked = true;

                    //Buscas a la papa Vista
                    var vistamodulo = LstGruposVistas.Where(t => t.Tipo == "Modulo").Where(v => v.Index == vistagrupo.ParentId).FirstOrDefault();
                    vistamodulo.IsChecked = true;

                    //Buscas a la papa Modulo
                    var vistasistema = LstGruposVistas.Where(t => t.Tipo == "Sistema").Where(m => m.Index == vistamodulo.ParentId).FirstOrDefault();
                    vistasistema.IsChecked = true;


                }

                //Carga los filtros de reportes
                foreach (VistasFiltrosReportes filtro in Item.VistasFiltrosReportes)
                {
                    LstFiltrosReportes.Add(filtro);
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

                ServicioWS ws = new ServicioWS("ServiciosERP/Administracion/WSVistas.svc", "getPermisos", null, typeof(System.Collections.ObjectModel.ObservableCollection<PermisosModelTemp>), null);
                LstPermisosTepm = (System.Collections.ObjectModel.ObservableCollection<PermisosModelTemp>)ws.Peticion();

                foreach (PermisosModelTemp Permiso in LstPermisosTepm)
                {

                    LstGruposVistas.Add(new PermisosModel
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
        public void Cell()
        {
            try
            {
                PermisoSeleccionado.IsChecked = !PermisoSeleccionado.IsChecked;
                //Buscar el padre del check seleccionado si es que lo tiene
                var permisopadre = LstGruposVistas.SingleOrDefault(p => p.Index == PermisoSeleccionado.ParentId);

                var permisohermanos = LstGruposVistas.Where(p => p.ParentId == PermisoSeleccionado.ParentId).Where(h => h.IsChecked == true).Where(p => p.Index != PermisoSeleccionado.Index);


                if (permisopadre != null)
                {
                    if (permisohermanos.ToList().Count == 0)
                    {
                        permisopadre.IsChecked = PermisoSeleccionado.IsChecked;
                        var permisopadremayor = LstGruposVistas.SingleOrDefault(p => p.Index == permisopadre.ParentId);
                        if (permisopadremayor != null)
                            permisopadremayor.IsChecked = true;
                    }
                }


                //Selecciono todos los hijos del padre seleccionado
                var Permisos = LstGruposVistas.Where(p => p.ParentId == PermisoSeleccionado.Index);

                //Recorremos los hijos
                foreach (PermisosModel permiso in Permisos)
                {
                    permiso.IsChecked = PermisoSeleccionado.IsChecked;
                    var PermisosHijos = LstGruposVistas.Where(p => p.ParentId == permiso.Index);
                    foreach (PermisosModel permisohijo in PermisosHijos)
                    {
                        permisohijo.IsChecked = PermisoSeleccionado.IsChecked;
                    }
                }
                /*System.Collections.ObjectModel.ObservableCollection<PermisosModel> Temp_LstPermisos=new System.Collections.ObjectModel.ObservableCollection<PermisosModel>();
                Temp_LstPermisos = LstPermisos;
                LstPermisos = null;
                LstPermisos = Temp_LstPermisos;*/
                RaisePropertyChanged(() => LstGruposVistas.ToList()[0].IsChecked);

            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                       MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void Limpiar()
        {
            try
            {
                base.Limpiar();
                LstGruposVistas.ToList().ForEach(c => c.IsChecked = false);
                //LstBDEmpresas.ToList().ForEach(c => c.isChecked = false);
                LoadTablas();
                //Administrador = false;
                RaisePropertyChanged(() => LstTablas);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
    }
}

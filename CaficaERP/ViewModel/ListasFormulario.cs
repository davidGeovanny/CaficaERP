using CaficaERP.Model.Administracion;
using CaficaERP.Model.Compras;
using CaficaERP.Model.Generales;
using CaficaERP.Model.Inventarios;
using CaficaERP.Model.Ventas.Monedero;
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
    public class ListasFormulario : ViewModelBase
    {

        private System.Collections.ObjectModel.ObservableCollection<string> _LstStatus;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstSiNo;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstNaturaleza;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstTiposSeguimiento;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstTipoAlmacen;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstMetodosCosteo;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstValuacionInventario;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstDesgloseKardex;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstTiposVista;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstTiposFiltro;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstNivelesExistencia;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstEstadosExistencias;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstFormatosReportes;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstEstadosDevolucion;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstNaturalezaImpuestos;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstTiposCalculo;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstTiposImpuesto;
        private System.Collections.ObjectModel.ObservableCollection<object> _LstGruposSocios;
        private System.Collections.ObjectModel.ObservableCollection<Vistas> _LstVistas;
        private System.Collections.ObjectModel.ObservableCollection<Roles> _LstRoles;
        private System.Collections.ObjectModel.ObservableCollection<Unidades> _LstUnidades;
        private System.Collections.ObjectModel.ObservableCollection<TiposComponentes> _LstTiposComponentes;
        private System.Collections.ObjectModel.ObservableCollection<GruposComponentes> _LstGruposComponentes;
        private System.Collections.ObjectModel.ObservableCollection<SubgruposComponentes> _LstSubgruposComponentes;
        private System.Collections.ObjectModel.ObservableCollection<GruposUnidades> _LstGruposUnidades;
        private System.Collections.ObjectModel.ObservableCollection<Colonias> _LstDirecciones;
        private System.Collections.ObjectModel.ObservableCollection<Paises> _LstPaises;
        private System.Collections.ObjectModel.ObservableCollection<Estados> _LstEstados;
        private System.Collections.ObjectModel.ObservableCollection<Municipios> _LstMunicipios;
        private System.Collections.ObjectModel.ObservableCollection<Ciudades> _LstCiudades;
        private System.Collections.ObjectModel.ObservableCollection<CodigosPostales> _LstCodigosPostales;
        private System.Collections.ObjectModel.ObservableCollection<BDEmpresas> _LstBDEmpresas;
        private System.Collections.ObjectModel.ObservableCollection<Almacenes> _LstAlmacenes;
        private System.Collections.ObjectModel.ObservableCollection<Componentes> _LstComponentes;
        private System.Collections.ObjectModel.ObservableCollection<MarcasComponentes> _LstMarcasComponentes;
        private System.Collections.ObjectModel.ObservableCollection<LotesSeries> _LstNumerosSeries;
        private System.Collections.ObjectModel.ObservableCollection<LotesSeries> _LstLotes;
        private System.Collections.ObjectModel.ObservableCollection<Responsables> _LstResponsables;
        private System.Collections.ObjectModel.ObservableCollection<Almacenes> _LstAlmacenesResguardo;
        private System.Collections.ObjectModel.ObservableCollection<ResguardosLotesSeries> _LstDevolucionesComponentes;
        private System.Collections.ObjectModel.ObservableCollection<Departamentos> _LstDepartamentos;
        private System.Collections.ObjectModel.ObservableCollection<Areas> _LstAreas;
        private System.Collections.ObjectModel.ObservableCollection<Impuestos> _LstImpuestos;
        private System.Collections.ObjectModel.ObservableCollection<Monedas> _LstMonedas;
        private System.Collections.ObjectModel.ObservableCollection<Giros> _LstGiros;
        private System.Collections.ObjectModel.ObservableCollection<GrupoProveedores> _LstGruposProveedores;
        private System.Collections.ObjectModel.ObservableCollection<CondicionesPago> _LstCondicionesPago;
        private System.Collections.ObjectModel.ObservableCollection<Proveedores> _LstProveedoresActivos;
        private System.Collections.ObjectModel.ObservableCollection<CentrosCanjeMonedero> _LstCentrosCanjeMonedero;
        private FrameworkElement _OwnerVista;

        public FrameworkElement OwnerVista
        {
            get
            {
                return _OwnerVista;
            }

            set
            {
                SetProperty(ref _OwnerVista, value, () => _OwnerVista);
            }
        }


        public System.Collections.ObjectModel.ObservableCollection<string> LstStatus
        {
            get
            {
                return _LstStatus;
            }

            set
            {
                SetProperty(ref _LstStatus, value, () => LstStatus);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Roles> LstRoles
        {
            get
            {
                return _LstRoles;
            }

            set
            {

                SetProperty(ref _LstRoles, value, () => LstRoles);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Unidades> LstUnidades
        {
            get
            {
                return _LstUnidades;
            }

            set
            {
                SetProperty(ref _LstUnidades, value, () => LstUnidades);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<TiposComponentes> LstTiposComponentes
        {
            get
            {
                return _LstTiposComponentes;
            }

            set
            {
                SetProperty(ref _LstTiposComponentes, value, () => LstTiposComponentes);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<GruposComponentes> LstGruposComponentes
        {
            get
            {
                return _LstGruposComponentes;
            }

            set
            {
                SetProperty(ref _LstGruposComponentes, value, () => LstGruposComponentes);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<SubgruposComponentes> LstSubgruposComponentes
        {
            get
            {
                return _LstSubgruposComponentes;
            }

            set
            {
                SetProperty(ref _LstSubgruposComponentes, value, () => LstSubgruposComponentes);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<GruposUnidades> LstGruposUnidades
        {
            get
            {
                return _LstGruposUnidades;
            }

            set
            {
                SetProperty(ref _LstGruposUnidades, value, () => LstGruposUnidades);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstSiNo
        {
            get
            {
                return _LstSiNo;
            }

            set
            {
                SetProperty(ref _LstSiNo, value, () => LstSiNo);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstTiposSeguimiento
        {
            get
            {
                return _LstTiposSeguimiento;
            }

            set
            {
                SetProperty(ref _LstTiposSeguimiento, value, () => LstTiposSeguimiento);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Colonias> LstDirecciones
        {
            get
            {
                return _LstDirecciones;
            }

            set
            {
                SetProperty(ref _LstDirecciones, value, () => LstDirecciones);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstTipoAlmacen
        {
            get
            {
                return _LstTipoAlmacen;
            }

            set
            {
                SetProperty(ref _LstTipoAlmacen, value, () => LstTipoAlmacen);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstNaturaleza
        {
            get
            {
                return _LstNaturaleza;
            }

            set
            {
                SetProperty(ref _LstNaturaleza, value, () => LstNaturaleza);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Paises> LstPaises
        {
            get
            {
                return _LstPaises;
            }

            set
            {
                SetProperty(ref _LstPaises, value, () => LstPaises);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Estados> LstEstados
        {
            get
            {
                return _LstEstados;
            }

            set
            {
                SetProperty(ref _LstEstados, value, () => LstEstados);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Municipios> LstMunicipios
        {
            get
            {
                return _LstMunicipios;
            }

            set
            {
                SetProperty(ref _LstMunicipios, value, () => LstMunicipios);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Ciudades> LstCiudades
        {
            get
            {
                return _LstCiudades;
            }

            set
            {
                SetProperty(ref _LstCiudades, value, () => LstCiudades);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<CodigosPostales> LstCodigosPostales
        {
            get
            {
                return _LstCodigosPostales;
            }

            set
            {
                SetProperty(ref _LstCodigosPostales, value, () => LstCodigosPostales);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Vistas> LstVistas
        {
            get
            {
                return _LstVistas;
            }

            set
            {
                SetProperty(ref _LstVistas, value, () => LstVistas);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<BDEmpresas> LstBDEmpresas
        {
            get
            {
                return _LstBDEmpresas;
            }

            set
            {
                SetProperty(ref _LstBDEmpresas, value, () => LstBDEmpresas);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Almacenes> LstAlmacenes
        {
            get
            {
                return _LstAlmacenes;
            }

            set
            {
                SetProperty(ref _LstAlmacenes, value, () => LstAlmacenes);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Componentes> LstComponentes
        {
            get
            {
                return _LstComponentes;
            }

            set
            {
                SetProperty(ref _LstComponentes, value, () => LstComponentes);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstMetodosCosteo
        {
            get
            {
                return _LstMetodosCosteo;
            }

            set
            {
                SetProperty(ref _LstMetodosCosteo, value, () => LstMetodosCosteo);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<MarcasComponentes> LstMarcasComponentes
        {
            get
            {
                return _LstMarcasComponentes;
            }

            set
            {
                SetProperty(ref _LstMarcasComponentes, value, () => LstMarcasComponentes);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstValuacionInventario
        {
            get
            {
                return _LstValuacionInventario;
            }

            set
            {
                SetProperty(ref _LstValuacionInventario, value, () => LstValuacionInventario);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstDesgloseKardex
        {
            get
            {
                return _LstDesgloseKardex;
            }

            set
            {
                SetProperty(ref _LstDesgloseKardex, value, () => _LstDesgloseKardex);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<LotesSeries> LstNumerosSeries
        {
            get
            {
                return _LstNumerosSeries;
            }

            set
            {
               
                SetProperty(ref _LstNumerosSeries, value, () => _LstNumerosSeries);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<object> LstTiposVista
        {
            get
            {
                return _LstTiposVista;
            }

            set
            {
                SetProperty(ref _LstTiposVista, value, () => LstTiposVista);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<object> LstTiposFiltro
        {
            get
            {
                return _LstTiposFiltro;
            }
            set
            {
                SetProperty(ref _LstTiposFiltro, value, () => LstTiposFiltro);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<LotesSeries> LstLotes
        {
            get
            {
                return _LstLotes;
            }

            set
            {
                SetProperty(ref _LstLotes, value, () => LstLotes);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstNivelesExistencia
        {
            get
            {
                return _LstNivelesExistencia;
            }

            set
            {
                SetProperty(ref _LstNivelesExistencia, value, () => LstNivelesExistencia);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstEstadosExistencias
        {
            get
            {
                return _LstEstadosExistencias;
            }

            set
            {
                SetProperty(ref _LstEstadosExistencias, value, () => LstEstadosExistencias);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Responsables> LstResponsables
        {
            get
            {
                return _LstResponsables;
            }

            set
            {
                SetProperty(ref _LstResponsables, value, () => LstResponsables);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Almacenes> LstAlmacenesResguardo
        {
            get
            {
                return _LstAlmacenesResguardo;
            }

            set
            {
                SetProperty(ref _LstAlmacenesResguardo, value, () => LstAlmacenesResguardo);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<ResguardosLotesSeries> LstDevolucionesComponentes
        {
            get
            {
                return _LstDevolucionesComponentes;
            }

            set
            {
                SetProperty(ref _LstDevolucionesComponentes, value, () => LstDevolucionesComponentes);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<object> LstFormatosReportes
        {
            get
            {
                return _LstFormatosReportes;
            }

            set
            {
                SetProperty(ref _LstFormatosReportes, value, () => LstFormatosReportes);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstEstadosDevolucion
        {
            get
            {
                return _LstEstadosDevolucion;
            }

            set
            {
                SetProperty(ref _LstEstadosDevolucion, value, () => LstEstadosDevolucion);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Departamentos> LstDepartamentos
        {
            get
            {
                return _LstDepartamentos;
            }

            set
            {
                SetProperty(ref _LstDepartamentos, value, () => LstDepartamentos);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Areas> LstAreas
        {
            get
            {
                return _LstAreas;
            }

            set
            {
                SetProperty(ref _LstAreas, value, () => LstAreas);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstNaturalezaImpuestos
        {
            get
            {
                return _LstNaturalezaImpuestos;
            }
            set
            {
                SetProperty(ref _LstNaturalezaImpuestos, value, () => LstNaturalezaImpuestos);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstTiposCalculo
        {
            get
            {
                return _LstTiposCalculo;
            }

            set
            {
                SetProperty(ref _LstTiposCalculo, value, () => LstTiposCalculo);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<object> LstTiposImpuesto
        {
            get
            {
                return _LstTiposImpuesto;
            }

            set
            {
                SetProperty(ref _LstTiposImpuesto, value, () => LstTiposImpuesto);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Impuestos> LstImpuestos
        {
            get
            {
                return _LstImpuestos;
            }

            set
            {
                SetProperty(ref _LstImpuestos, value, () => LstImpuestos);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Monedas> LstMonedas

        {
            get
            {
                return _LstMonedas;
            }

            set
            {
                SetProperty(ref _LstMonedas, value, () => LstMonedas);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Giros> LstGiros
        {
            get
            {
                return _LstGiros;
            }

            set
            {
                SetProperty(ref _LstGiros, value, () => LstGiros);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<GrupoProveedores> LstGruposProveedores
        {
            get
            {
                return _LstGruposProveedores;
            }

            set
            {
                SetProperty(ref _LstGruposProveedores, value, () => LstGruposProveedores);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<CondicionesPago> LstCondicionesPago
        {
            get
            {
                return _LstCondicionesPago;
            }

            set
            {
                SetProperty(ref _LstCondicionesPago, value, () => LstCondicionesPago);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Proveedores> LstProveedoresActivos
        {
            get
            {
                return _LstProveedoresActivos;
            }

            set
            {
                SetProperty(ref _LstProveedoresActivos, value, () => LstProveedoresActivos);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<CentrosCanjeMonedero> LstCentrosCanjeMonedero
        {
            get
            {
                return _LstCentrosCanjeMonedero;
            }

            set
            {
                SetProperty(ref _LstCentrosCanjeMonedero, value, () => LstCentrosCanjeMonedero);
            }
        }

        public ObservableCollection<object> LstGruposSocios
        {
            get
            {
                return _LstGruposSocios;
            }

            set
            {
                SetProperty(ref _LstGruposSocios, value, () => LstGruposSocios);
            }
        }

        public void CargarStatus()
        {
            try
            {
                LstStatus = new System.Collections.ObjectModel.ObservableCollection<string>();
                LstStatus.Add("Inactivo");
                LstStatus.Add("Activo");
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarTipoAlmacen()
        {
            try
            {
                LstTipoAlmacen = new System.Collections.ObjectModel.ObservableCollection<object>();
                LstTipoAlmacen.Add(new { nombre = "AUXILIAR" });
                LstTipoAlmacen.Add(new { nombre = "PRINCIPAL" });
                //RaisePropertyChanged(() => UnidadBaseId);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarSiNo()
        {
            try
            {
                LstSiNo = new System.Collections.ObjectModel.ObservableCollection<object>();
                LstSiNo.Add(new { nombre = "SI" });
                LstSiNo.Add(new { nombre = "NO" });
                // LstSiNo.Add("NO");
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarNaturaleza()
        {
            try
            {
                LstNaturaleza = new System.Collections.ObjectModel.ObservableCollection<object>();
                LstNaturaleza.Add(new { nombre = "ENTRADA" });
                LstNaturaleza.Add(new { nombre = "SALIDA" });
                // LstSiNo.Add("NO");
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarVistas()
        {
            try
            {
                //Metodo para cargar el combo de GruposVistas...
                LstVistas = CargarLista<Vistas>("ServiciosERP/Administracion/WSVistas.svc", LstVistas);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);

            }
        }
        public void CargarTiposSeguimiento()
        {
            try
            {
                LstTiposSeguimiento = new System.Collections.ObjectModel.ObservableCollection<object>();
                LstTiposSeguimiento.Add(new { nombre = "NORMAL" });
                LstTiposSeguimiento.Add(new { nombre = "LOTES" });
                LstTiposSeguimiento.Add(new { nombre = "NÚMERO DE SERIE" });
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarMetodosCosteo()
        {
            try
            {
                LstMetodosCosteo = new System.Collections.ObjectModel.ObservableCollection<object>();
                LstMetodosCosteo.Add(new { nombre = "PEPS" });
                LstMetodosCosteo.Add(new { nombre = "UEPS" });
                LstMetodosCosteo.Add(new { nombre = "PROMEDIO PONDERADO" });
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarEstadosDevoluciones()
        {
            try
            {
                LstEstadosDevolucion = new System.Collections.ObjectModel.ObservableCollection<object>();
                LstEstadosDevolucion.Add(new { nombre = "BUEN ESTADO" });
                LstEstadosDevolucion.Add(new { nombre = "EXTRAVIADO" });
                LstEstadosDevolucion.Add(new { nombre = "DAÑO POR MAL USO" });
                LstEstadosDevolucion.Add(new { nombre = "DAÑO NATURAL" });
                LstEstadosDevolucion.Add(new { nombre = "FIN DE VIDA UTIL" });
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Modelo> CargarLista<Modelo>(string conexion, System.Collections.ObjectModel.ObservableCollection<Modelo> Lst)
        {
            try
            {
                Lst = new System.Collections.ObjectModel.ObservableCollection<Modelo>();
                ServicioWS Ws = new ServicioWS(conexion, "getall", null, typeof(System.Collections.ObjectModel.ObservableCollection<Modelo>), null);
                Lst = (System.Collections.ObjectModel.ObservableCollection<Modelo>)Ws.Peticion();

                return Lst;
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
                return null;
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Modelo> CargarLista<Modelo>(string conexion, string metodo, System.Collections.ObjectModel.ObservableCollection<Modelo> Lst, long id)
        {
            try
            {
                Lst = new System.Collections.ObjectModel.ObservableCollection<Modelo>();
                ServicioWS Ws = new ServicioWS(conexion, metodo, id, typeof(System.Collections.ObjectModel.ObservableCollection<Modelo>), "id");
                Lst = (System.Collections.ObjectModel.ObservableCollection<Modelo>)Ws.Peticion();

                return Lst;
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
                return null;
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Modelo> CargarLista<Modelo>(string conexion, string metodo, System.Collections.ObjectModel.ObservableCollection<Modelo> Lst)
        {
            try
            {
                Lst = new System.Collections.ObjectModel.ObservableCollection<Modelo>();
                ServicioWS Ws = new ServicioWS(conexion, metodo, null, typeof(System.Collections.ObjectModel.ObservableCollection<Modelo>), "id");
                Lst = (System.Collections.ObjectModel.ObservableCollection<Modelo>)Ws.Peticion();

                return Lst;
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
                return null;
            }
        }
        public void CargarRoles()
        {
            try
            {
                LstRoles = CargarLista<Roles>("ServiciosERP/Administracion/WsRoles.svc", LstRoles);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarUnidades()
        {
            try
            {
                LstUnidades = CargarLista<Unidades>("ServiciosERP/Generales/WSUnidades.svc", LstUnidades);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarDepartamentos()
        {
            try
            {
                LstDepartamentos = CargarLista<Departamentos>("ServiciosERP/Generales/WSDepartamentos.svc", LstDepartamentos);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarAreas()
        {
            try
            {
                LstAreas = CargarLista<Areas>("ServiciosERP/Generales/WSAreas.svc", LstAreas);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarAlmacenes()
        {
            try
            {
                LstAlmacenes = CargarLista<Almacenes>("ServiciosERP/Inventarios/WSAlmacenes.svc", LstAlmacenes);
                LstAlmacenes = new System.Collections.ObjectModel.ObservableCollection<Almacenes>(LstAlmacenes.Where(a => a.Activo == "SI"));
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarTiposComponentes()
        {
            try
            {
                LstTiposComponentes = CargarLista<TiposComponentes>("ServiciosERP/Inventarios/WSTiposComponentes.svc", LstTiposComponentes);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarGruposComponentesXTipo(long tipo)
        {
            try
            {
                LstGruposComponentes = CargarLista<GruposComponentes>("ServiciosERP/Inventarios/WSGrupoComponentes.svc", "getGruposComponentesXTipo", LstGruposComponentes, tipo);
                LstGruposComponentes = new System.Collections.ObjectModel.ObservableCollection<GruposComponentes>(LstGruposComponentes.OrderBy(x => x.Nombre).ToList());
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarGruposComponentesXAlmacen(long almacenid)
        {
            try
            {
                if(almacenid>0)
                {
                        LstGruposComponentes = CargarLista<GruposComponentes>("ServiciosERP/Inventarios/WSAlmacenes.svc", "getGruposComponentesXAlmacen", LstGruposComponentes, almacenid);
                }

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarGruposComponentes()
        {
            try
            {

                LstGruposComponentes.Clear();
                LstGruposComponentes = CargarLista<GruposComponentes>("ServiciosERP/Inventarios/WSGrupoComponentes.svc", LstGruposComponentes);
               
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarSubgruposComponentesXGrupo(long grupoid)
        {
            try
            {
                LstSubgruposComponentes = CargarLista<SubgruposComponentes>("ServiciosERP/Inventarios/WSSubGrupoComponentes.svc", "getSubGruposComponentesXGrupo", LstSubgruposComponentes, grupoid);
                LstSubgruposComponentes = new System.Collections.ObjectModel.ObservableCollection<SubgruposComponentes>(LstSubgruposComponentes.OrderBy(x => x.Nombre).ToList());
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarGruposUnidades()
        {
            try
            {
                LstGruposUnidades = CargarLista<GruposUnidades>("ServiciosERP/Inventarios/WSGrupoUnidades.svc", LstGruposUnidades);
                LstGruposUnidades = new System.Collections.ObjectModel.ObservableCollection<GruposUnidades>(LstGruposUnidades.OrderBy(x => x.Nombre).ToList());
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarUnidadesxGrupo(GruposUnidades grupo)
        {
            try
            {
                LstUnidades = CargarLista<Unidades>("ServiciosERP/Generales/WSUnidades.svc", "getUnidadesXGrupo", LstUnidades, grupo.Id);
                LstUnidades = new System.Collections.ObjectModel.ObservableCollection<Unidades>(LstUnidades.OrderBy(x => x.Nombre).ToList());
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public void CargarDirecciones()
        {
            try
            {
                LstDirecciones = CargarLista<Colonias>("ServiciosERP/Generales/WSColonias.svc", LstDirecciones);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarEmpresas()
        {
            try
            {
                LstBDEmpresas = CargarLista<BDEmpresas>("ServiciosERP/Administracion/WSBDEmpresas.svc", LstBDEmpresas);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarPaises()
        {
            try
            {

                LstPaises = CargarLista<Paises>("ServiciosERP/Generales/WSPaises.svc", LstPaises);

            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarEstados(Paises pais)
        {
            try
            {
                if (pais != null)
                    LstEstados = CargarLista<Estados>("ServiciosERP/Generales/WSEstados.svc", "getEstadosPais", LstEstados, pais.Id);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public void CargarMunicipios(Estados estado)
        {
            try
            {
                if (estado != null)
                    LstMunicipios = CargarLista<Municipios>("ServiciosERP/Generales/WSMunicipios.svc", "getMunicipiosEstado", LstMunicipios, estado.Id);
            }

            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public void CargarCiudades(Municipios municipio)
        {
            try
            {
                if (municipio != null)
                    LstCiudades = CargarLista<Ciudades>("ServiciosERP/Generales/WSCiudades.svc", "getCiudadesMunicipio", LstCiudades, municipio.Id);
            }

            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

      
        public void CargarCodigosPostales(Ciudades ciudad)
        {
            try
            {
                if (ciudad != null)
                   LstCodigosPostales = CargarLista<CodigosPostales>("ServiciosERP/Generales/WSCodigosPostales.svc", "getCodigosPostalesCiudad", LstCodigosPostales, ciudad.Id);
            }

            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

       
        public void CargarAlmacenesXGrupoComponentes(long tipo)
        {
            try
            {
                LstAlmacenes = CargarLista<Almacenes>("ServiciosERP/Inventarios/WSAlmacenes.svc", "getAlmacenesXGrupoComponentes", LstAlmacenes, tipo);

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public void CargarComponentesFormula(Componentes componente)
        {
            try
            {
                LstComponentes = new System.Collections.ObjectModel.ObservableCollection<Componentes>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSComponentes.svc", "getComponentesFormula", componente, typeof(System.Collections.ObjectModel.ObservableCollection<Componentes>), "componente");

                LstComponentes = (System.Collections.ObjectModel.ObservableCollection<Componentes>)Ws.Peticion();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }
        public void CargarComponentesAlmacen(long almacenid)
        {
            try
            {
                LstComponentes = CargarLista<Componentes>("ServiciosERP/Inventarios/WSComponentes.svc", "getComponentesAlmacen", LstComponentes, almacenid);

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }


        }
        public void CargarComponentesAlmacenConImagen(long almacenid)
        {
            try
            {
                LstComponentes = CargarLista<Componentes>("ServiciosERP/Inventarios/WSComponentes.svc", "getComponentesAlmacenConImagen", LstComponentes, almacenid);

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }
        public void CargarComponentesAlmacenConImagenImpuestos(long almacenid)
        {
            try
            {
                LstComponentes = CargarLista<Componentes>("ServiciosERP/Inventarios/WSComponentes.svc", "getComponentesAlmacenConImagenImpuestos", LstComponentes, almacenid);

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }
        public void CargarComponentesAlmacenConImagenImpuestosbusqueda(string palabra)
        {
            try
            {
            //    LstComponentes = CargarLista<Componentes>("ServiciosERP/Inventarios/WSComponentes.svc", "getComponentesAlmacenConImagenImpuestos", LstComponentes, palabra);
                LstComponentes = new System.Collections.ObjectModel.ObservableCollection<Componentes>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSComponentes.svc","buscar", palabra, typeof(System.Collections.ObjectModel.ObservableCollection<Componentes>), "item");
                LstComponentes = (System.Collections.ObjectModel.ObservableCollection<Componentes>)Ws.Peticion();

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }
        public void CargarComponentesXTipoConImagen(long tipo)
        {
            try
            {
                LstComponentes = CargarLista<Componentes>("ServiciosERP/Inventarios/WSComponentes.svc", "getComponentesXTipoConImagen", LstComponentes, tipo);

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }
        public void CargarMarcasComponentes()
        {
            try
            {
                LstMarcasComponentes = CargarLista<MarcasComponentes>("ServiciosERP/Inventarios/WSMarcasComponentes.svc", LstMarcasComponentes);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }

        public void CargarNumerosSerie(long componenteid)
        {
            try
            {
                
                     LstNumerosSeries = new System.Collections.ObjectModel.ObservableCollection<LotesSeries>();
                        ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSComponentes.svc", "getNumerosSeries", componenteid, typeof(System.Collections.ObjectModel.ObservableCollection<LotesSeries>), "id");
                LstNumerosSeries =  (System.Collections.ObjectModel.ObservableCollection<LotesSeries>)Ws.Peticion();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }
        public void CargarCentrosCanjeMonedero()
        {
            try
            {
                LstCentrosCanjeMonedero = CargarLista<CentrosCanjeMonedero>("ServiciosERP/Ventas/WSCentrosCanjeMonedero.svc", LstCentrosCanjeMonedero);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarValuacionInventario()
        {
            try
            {
                LstValuacionInventario = new System.Collections.ObjectModel.ObservableCollection<object>();
                LstValuacionInventario.Add(new {nombre = VariablesGlobales.MetodoCosteoEmpresa});
                LstValuacionInventario.Add(new {nombre = "ULTIMO COSTO" });
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public void CargarDesgloseKardex()
        {
            try
            {
                LstDesgloseKardex = new System.Collections.ObjectModel.ObservableCollection<object>();
                LstDesgloseKardex.Add(new { nombre = "MOVIMIENTOS" });
                LstDesgloseKardex.Add(new { nombre = "CONCEPTOS" });
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarTipoVista()
        {
            LstTiposVista = new System.Collections.ObjectModel.ObservableCollection<object>();
            LstTiposVista.Add(new { nombre = "FORMULARIO" });
            LstTiposVista.Add(new { nombre = "REPORTE" });
        }
        public void CargarTipoFiltro()
        {
            LstTiposFiltro = new System.Collections.ObjectModel.ObservableCollection<object>();
            LstTiposFiltro.Add(new { nombre = "DATE" });
            LstTiposFiltro.Add(new { nombre = "COMBO" });
            LstTiposFiltro.Add(new { nombre = "LOOKUP" });
        }
        public void CargarLotes(long componenteid)
        {
            try
            {

                LstLotes = new System.Collections.ObjectModel.ObservableCollection<LotesSeries>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSComponentes.svc", "getLotes", componenteid, typeof(System.Collections.ObjectModel.ObservableCollection<LotesSeries>), "id");
                LstLotes = (System.Collections.ObjectModel.ObservableCollection<LotesSeries>)Ws.Peticion();
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }
        public void CargarAlmacenesResguardos()
        {
            try
            {
                LstAlmacenesResguardo = CargarLista<Almacenes>("ServiciosERP/Inventarios/WSAlmacenes.svc","getAlmacenesResguardo", LstAlmacenesResguardo);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarNivelesExistencias()
        {
            LstNivelesExistencia = new System.Collections.ObjectModel.ObservableCollection<object>();
            LstNivelesExistencia.Add(new { nombre = "REORDEN" });
            LstNivelesExistencia.Add(new { nombre = "MAXIMO" });
        }
        public void CargarEstadosExistencias()
        {
            LstEstadosExistencias = new System.Collections.ObjectModel.ObservableCollection<object>();
            LstEstadosExistencias.Add(new { nombre = "RESERVA" });
            LstEstadosExistencias.Add(new { nombre = "RESURTIR" });
            LstEstadosExistencias.Add(new { nombre = "NORMAL" });
            LstEstadosExistencias.Add(new { nombre = "EXCEDIDO" });
        }

        public void CargarResponsables()
        {
            try
            {
                LstResponsables = CargarLista<Responsables>("ServiciosERP/Generales/WSResponsables.svc", LstResponsables);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarComponentesAlmacenConExistencia(long almacenId)
        {
            try
            {
                LstComponentes = CargarLista<Componentes>("ServiciosERP/Inventarios/WSComponentes.svc", "getComponentesAlmacenConExistencia", LstComponentes, almacenId);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarComponentesAlmacenConExistenciaeImagen(long almacenId)
        {
            try
            {
                LstComponentes = CargarLista<Componentes>("ServiciosERP/Inventarios/WSComponentes.svc", "getComponentesAlmacenConExistenciaeImagen", LstComponentes, almacenId);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarComponentesDevoluciones(long ResponsableId)
        {
            try
            {
                LstDevolucionesComponentes = CargarLista<ResguardosLotesSeries>("ServiciosERP/Inventarios/WSDevoluciones.svc", "getDevolucionesPendientes", LstDevolucionesComponentes, ResponsableId);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public void CargarFormatosReportes()
        {
            LstFormatosReportes = new System.Collections.ObjectModel.ObservableCollection<object>();
            LstFormatosReportes.Add(new { nombre = "Vista Previa(PDF)", extension = "pdf" });
            LstFormatosReportes.Add(new { nombre = "Excel(XLS)", extension = "xls" });
            LstFormatosReportes.Add(new { nombre = "Excel(XLSX)", extension = "xlsx" });
            LstFormatosReportes.Add(new { nombre = "Archivo CSV", extension = "csv" });
            LstFormatosReportes.Add(new { nombre = "Word(DOCX)", extension = "docx" });


        }

        public void CargarComponentesParaResguardo()
        {
            try
            {
                LstComponentes = CargarLista<Componentes>("ServiciosERP/Inventarios/WSComponentes.svc", "getComponentesResguardo", LstComponentes);

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }

        public void CargarNaturalezaImpuestos()
        {
            LstNaturalezaImpuestos = new System.Collections.ObjectModel.ObservableCollection<object>();
            LstNaturalezaImpuestos.Add(new { nombre = "IMPUESTO" });
            LstNaturalezaImpuestos.Add(new { nombre = "RETENCION DE IMPUESTO" });
        }

        public void CargarTipoCalculo()
        {
            LstTiposCalculo = new System.Collections.ObjectModel.ObservableCollection<object>();
            LstTiposCalculo.Add(new { nombre = "PORCENTAJE" });
            LstTiposCalculo.Add(new { nombre = "UNIDAD" });
        }
        public void CargarTiposImpuestos()
        {
            LstTiposImpuesto = new System.Collections.ObjectModel.ObservableCollection<object>();
            LstTiposImpuesto.Add(new { nombre = "GENERAL" });
            LstTiposImpuesto.Add(new { nombre = "TASA 0%" });
            LstTiposImpuesto.Add(new { nombre = "EXENTO" });
        }
        public void CargarGruposSocios()
        {
            LstGruposSocios = new System.Collections.ObjectModel.ObservableCollection<object>();
            LstGruposSocios.Add(new { nombre = "OGA" });
            LstGruposSocios.Add(new { nombre = "BRISSA" });
            LstGruposSocios.Add(new { nombre = "VIA RAPIDA" });
        }
        public void CargarImpuestos()
        {
            try
            {
                LstImpuestos = CargarLista<Impuestos>("ServiciosERP/Generales/WSImpuestos.svc", LstImpuestos);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }


        public void CargarMonedas()
        {
            try
            {
                LstMonedas = new System.Collections.ObjectModel.ObservableCollection<Monedas>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Generales/WSMonedas.svc", "getall", null, typeof(System.Collections.ObjectModel.ObservableCollection<Monedas>), null);
                LstMonedas = (System.Collections.ObjectModel.ObservableCollection<Monedas>)Ws.Peticion();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void CargarGiros()
        {
            try
            {
                LstGiros = CargarLista<Giros>("ServiciosERP/Generales/WSGiros.svc", LstGiros);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarGruposProveedores()
        {
            try
            {
                LstGruposProveedores = CargarLista<GrupoProveedores>("ServiciosERP/Compras/WSGrupoProveedores.svc", LstGruposProveedores);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarCondicionesPago()
        {
            try
            {
                LstCondicionesPago = CargarLista<CondicionesPago>("ServiciosERP/Generales/WSCondicionesPago.svc", LstCondicionesPago);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void CargarProveedoresActivos()
        {
            try
            {
                LstProveedoresActivos = CargarLista<Proveedores>("ServiciosERP/Compras/WSProveedores.svc", LstProveedoresActivos);
                LstProveedoresActivos = new System.Collections.ObjectModel.ObservableCollection<Proveedores>(LstProveedoresActivos.Where(a => a.Activo =="SI"));
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
    }

}

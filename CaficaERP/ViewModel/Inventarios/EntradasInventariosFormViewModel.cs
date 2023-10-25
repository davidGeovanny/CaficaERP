using CaficaERP.Model.Administracion;
using CaficaERP.Model.Inventarios;
using CaficaERP.Model.Temporales;
using CaficaERP.Views;
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

namespace CaficaERP.ViewModel.Inventarios
{
    public class EntradasInventariosFormViewModel : FormularioViewModel<InventariosES>
    {
        //combos coleccion de datos
        private System.Collections.ObjectModel.ObservableCollection<ConceptosES> _LstConceptosEntrada; //coleccion de datos para la Lista de conceptos con naturaleza entrada, para llenar el combo Concepto
        private System.Collections.ObjectModel.ObservableCollection<Almacenes> _LstAlmacenesDestino;
        private System.Collections.ObjectModel.ObservableCollection<InventariosES> _LstTranspasosPendientes;

        //item seleccionado de cada combo
        private ConceptosES _ConceptoSeleccionado; //para saber que concepto tengo seleccionado, en el caso de abrir un registro y para poder asignar Item.Naturaleza = ConceptoSeleccionado.Naturaleza
        private Almacenes _AlmacenSeleccionado;
        private Almacenes _AlmacenSeleccionadoDestino; 
        private InventariosES _SalidaSeleccionado;


        //grid coleccion de datos
        private System.Collections.ObjectModel.ObservableCollection<InventariosESDetallesModelTemp> _LstInventariosESDetallesTemp;//temporal para avisar por cada item del objeto si hubo cambios
        

        //grid item seleccionado
        private InventariosESDetallesModelTemp _DetalleActual;
        private InventariosESDetallesModelTemp _DetalleSeleccionado;

        //grid subitem seleccionado
        private DetallesLotes_Series_ESTemp _SubDetalleActual;
        private DetallesLotes_Series_ESTemp _SubDetalleSeleccinado;

        //delegate comands
        public DelegateCommand DcTriggerActualizadorCambioCelda { get; set; } // se ejecuta cada vez que se mueven entre las celda del grid detalle, lo ocupo para sacar la relacion del almacen con su grupos componentes y el metodo de costeo de cada producto que van dando de alta en el grid
        public DelegateCommand<CellValue> DcTriggerActualizadorCambioCelda1{ get; set; }
        public DelegateCommand<object> DcExpandirGrupo { get; set; }
        public DelegateCommand DcEliminaFila { get; set; }
        public DelegateCommand DcCodigodeBarras { get; set; }
        public DelegateCommand<CellValue> DcAnalizaDetalles { get; set; }
        public DelegateCommand<CellValue> DcDesactivarCeldas { get; set; }
        public DelegateCommand<CellValue> DcLotesSeries { get; set; }

        public string NaturalezaDocumento;
        private string _EsvisibleEntrada;
        private string _EsvisibleSalida;
        private string _OpacidadTodos;
        private string _ReadOnlyCosto;
        private string _Visibleentrada;
        private string _Visiblesalida;
        private string _VisibleTraspasopdt;
        private string _VisibleAlmacendst;
        private string _EnabledConcepto;
        private string _OpacidadConcepto;
        private string _Readonlyserielote = "false";
        private string _Teclaborrar = "F12";
        private string _EnabledFolio;
        private string _OpacidadFolio;
        private string _EnabledFecha="false";
        private string _CodigodeBarra;
        private string _VisibleCampoComponenteEditar;
        private string _VisibleCampoComponenteNuevo;

        //variables
        //Variable para controlar el id de los registros del grid y idetificar a los hijos del registro
        private int IdDetalle;
        private bool _SoloLectura;



        public IMasterDetailService MasterDetailService { get { return GetService<IMasterDetailService>(); } }

        public System.Collections.ObjectModel.ObservableCollection<ConceptosES> LstConceptosEntrada
        {
            get
            {
                return _LstConceptosEntrada;
            }

            set
            {
                SetProperty(ref _LstConceptosEntrada, value, () => LstConceptosEntrada);

            }
        }

        public ConceptosES ConceptoSeleccionado
        {
            get
            {
                return _ConceptoSeleccionado;
            }

            set
            {
                SetProperty(ref _ConceptoSeleccionado, value, () => ConceptoSeleccionado);
                if (Item == null) return;
                if (ConceptoSeleccionado != null) { 
                Teclaborrar = ConceptoSeleccionado.Id == 2 || ConceptoSeleccionado.Id == 12 ? "" : "F12";
                Item.Naturaleza = ConceptoSeleccionado.Naturaleza; //Obtengo la plabra "ENTRADA"  de ConceptosModel.cs  del concepto seleccionado ya que ocupo la palabra, ya que no lo traigo en ESInventariosModel.cs   inventarios.naturaleza= ENTRADA
                }
                if (Item.Id == 0)
                { 
                        Enabled = ConceptoSeleccionado.Id == 2 || ConceptoSeleccionado.Id == 12 ? "True" : "False"; //si el concepto selecionado en el combo tiene el ID=2 "Entrada por transpaso" o 12 salida por transpaso  habilitalo si no desabilitalo
                        Opacidad = ConceptoSeleccionado.Id == 2 || ConceptoSeleccionado.Id == 12 ? "100" : "0.6"; //si el concepto selecionado en el combo tiene el ID=2 "Entrada por transpaso" o 12 salida por transpaso  no le pongas opacidad si no opacalo en 60%
                        EnabledFolio = ConceptoSeleccionado.FolioAutomatico == "SI"  ? "False" : "True"; //si el concepto selecionado en el combo tiene el ID=2 "Entrada por transpaso" o 12 salida por transpaso  habilitalo si no desabilitalo
                        OpacidadFolio = ConceptoSeleccionado.FolioAutomatico == "SI" ? "0.6" : "100"; //si el concepto selecionado en el combo tiene 
                        EnabledConcepto = ConceptoSeleccionado.Id == 2 || ConceptoSeleccionado.Id == 12 ? "False" : "True"; //si el concepto selecionado en el combo tiene el ID=2 "Entrada por transpaso" o 12 salida por transpaso  habilitalo si no desabilitalo
                        OpacidadConcepto = ConceptoSeleccionado.Id == 2 || ConceptoSeleccionado.Id == 12 ? "0.6" : "100"; //si el concepto selecionado en el combo tiene el ID=2 "Entrada por transpaso" o 12 salida por transpaso  no le pongas opacidad si no opacalo en 60%
                      /*  Readonlyserielote = ConceptoSeleccionado.Id == 2  ? "True" : "False";
                        Readonlyserielote = ConceptoSeleccionado.Id == 12 ? "False" : "True";
                        ReadOnly = ConceptoSeleccionado.Id == 2 ? "True" : "False";
                        ReadOnly = ConceptoSeleccionado.Id == 12 ? "False" : "True";*/
                        ReadOnlyCosto = ConceptoSeleccionado.CostoAutomatico == "SI" ?"True" : "False"; //si es costo automatico pon en readonly el campo costo
                        Visibleentrada = ConceptoSeleccionado.Naturaleza == "ENTRADA" ? "Visible" : "Hidden";
                        Visiblesalida = ConceptoSeleccionado.Naturaleza == "SALIDA" ? "Visible" : "Hidden";
                        if (ConceptoSeleccionado.Id == 2)
                           {
                            ReadOnly = "True";
                            Readonlyserielote = "True";
                           }
                        else if (ConceptoSeleccionado.Id == 12)
                        ReadOnly = "False";
                        Readonlyserielote = "False";
                    if (ConceptoSeleccionado.Id == 2)
                           {
                            LstInventariosESDetallesTemp.Clear();
                            SalidaSeleccionado =null;
                            AlmacenSeleccionado = null;
                            
                           }
               }

            }
        }

        public System.Collections.ObjectModel.ObservableCollection<InventariosESDetallesModelTemp> LstInventariosESDetallesTemp
        {
            get
            {
                return _LstInventariosESDetallesTemp;
            }

            set
            {
              
                SetProperty(ref _LstInventariosESDetallesTemp, value, () => LstInventariosESDetallesTemp);
               
            }
        }

        public Almacenes AlmacenSeleccionado
        {
            get
            {
                return _AlmacenSeleccionado;
            }

            set
            {
                SetProperty(ref _AlmacenSeleccionado, value, () => AlmacenSeleccionado);
                if (LstInventariosESDetallesTemp.Any() && AlmacenSeleccionado!=null)
                   {
                   /* guardar_si_no = DXMessageBox.Show(this.OwnerVista, "¿Se borraran los detalles, desea continuar?", "Confirmación", MessageBoxButton.YesNo,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);*/
                    guardar_si_no = DXMessageBox.Show(this.OwnerVista, "¿Se borraran los detalles, desea continuar?", "Error",MessageBoxButton.YesNo);
                    if (guardar_si_no==MessageBoxResult.Yes)
                         LstInventariosESDetallesTemp.Clear();
                  }
                //requiero el tipo componente Id
                // LstInventariosESDetallesTemp.Clear();
                if (AlmacenSeleccionado == null) return;
                if (Item.Id == 0)
                    CargarComponentesAlmacenConImagen(AlmacenSeleccionado.Id);
                else
                    CargarComponentesAlmacen(AlmacenSeleccionado.Id);
                //     DetalleActual.AlmacenId = AlmacenSeleccionado.Id;
                if (ConceptoSeleccionado == null) return;
                if (ConceptoSeleccionado.Id == 12)
                    { 
                    CargarAlmacenesTranspaso(AlmacenSeleccionado.TipoComponenteId);

                    }
                else if(ConceptoSeleccionado.Id == 2)
                     {
                        if (LstInventariosESDetallesTemp.Any())
                        {
                         /*   guardar_si_no = DXMessageBox.Show(this.OwnerVista, "¿Se borraran los detalles, desea continuar?", "Confirmación", MessageBoxButton.YesNo,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);*/
                        guardar_si_no = DXMessageBox.Show(this.OwnerVista, "¿Se borraran los detalles, desea continuar?", "Error", MessageBoxButton.YesNo);
                        if (guardar_si_no == MessageBoxResult.Yes)
                                LstInventariosESDetallesTemp.Clear();
                                SalidaSeleccionado = null;
                                CargarTranspasosPendientes(AlmacenSeleccionado.Id);
                         }
                               CargarTranspasosPendientes(AlmacenSeleccionado.Id);
                }
            }
        }

        public InventariosESDetallesModelTemp DetalleActual
        {
            get
            {
                return _DetalleActual;
            }

            set
            {
                SetProperty(ref _DetalleActual, value, () => DetalleActual);
            }
        }

        public InventariosESDetallesModelTemp DetalleSeleccionado
        {
            get
            {
                return _DetalleSeleccionado;
            }

            set
            {
                SetProperty(ref _DetalleSeleccionado, value, () => DetalleSeleccionado);
            }
        }
        public bool SoloLectura
        {
            get
            {
                return _SoloLectura;
            }

            set
            {
                SetProperty(ref _SoloLectura, value, () => SoloLectura);
            }
        }

        public DetallesLotes_Series_ESTemp SubDetalleActual
        {
            get
            {
                return _SubDetalleActual;
            }

            set
            {
                SetProperty(ref _SubDetalleActual, value, () => SubDetalleActual);
            }
        }

        public DetallesLotes_Series_ESTemp SubDetalleSeleccinado
        {
            get
            {
                return _SubDetalleSeleccinado;
            }

            set
            {
                SetProperty(ref _SubDetalleSeleccinado, value, () => SubDetalleSeleccinado);
            }
        }

        public string EsvisibleEntrada
        {
            get
            {
                return _EsvisibleEntrada;
            }

            set
            {
                SetProperty(ref _EsvisibleEntrada, value, () => EsvisibleEntrada);
            }
        }

        public string EsvisibleSalida
        {
            get
            {
                return _EsvisibleSalida;
            }

            set
            {
                SetProperty(ref _EsvisibleSalida, value, () => EsvisibleSalida);
            }
        }

        public string ReadOnlyCosto
        {
            get
            {
                return _ReadOnlyCosto;
            }

            set
            {
                SetProperty(ref _ReadOnlyCosto, value, () => ReadOnlyCosto);
            }
        }

        public string Visibleentrada
        {
            get
            {
                return _Visibleentrada;
            }

            set
            {
                SetProperty(ref _Visibleentrada, value, () => Visibleentrada);
            }
        }

        public string Visiblesalida
        {
            get
            {
                return _Visiblesalida;
            }

            set
            {
                SetProperty(ref _Visiblesalida, value, () => Visiblesalida);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Almacenes> LstAlmacenesDestino
        {
            get
            {
                return _LstAlmacenesDestino;
            }

            set
            {
                SetProperty(ref _LstAlmacenesDestino, value, () => LstAlmacenesDestino);
            }
        }

        public Almacenes AlmacenSeleccionadoDestino
        {
            get
            {
                return _AlmacenSeleccionadoDestino;
            }

            set
            {
                SetProperty(ref _AlmacenSeleccionadoDestino, value, () => AlmacenSeleccionadoDestino);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<InventariosES> LstTranspasosPendientes
        {
            get
            {
                return _LstTranspasosPendientes;
            }

            set
            {
                SetProperty(ref _LstTranspasosPendientes, value, () => LstTranspasosPendientes);
            }
        }

        public InventariosES SalidaSeleccionado
        {
            get
            {
                return _SalidaSeleccionado;
            }

            set
            {
                SetProperty(ref _SalidaSeleccionado, value, () => SalidaSeleccionado);
                LstInventariosESDetallesTemp.Clear();
                cargarDetallesTranspasoEntrada(SalidaSeleccionado);
            }
        }

        public string Readonlyserielote
        {
            get
            {
                return _Readonlyserielote;
            }

            set
            {
                SetProperty(ref _Readonlyserielote, value, () => Readonlyserielote);
            }
        }

        public string Teclaborrar
        {
            get
            {
                return _Teclaborrar;
            }

            set
            {
                SetProperty(ref _Teclaborrar, value, () => Teclaborrar);
            }
        }

        public string EnabledConcepto
        {
            get
            {
                return _EnabledConcepto;
            }

            set
            {
                SetProperty(ref _EnabledConcepto, value, () => EnabledConcepto);
            }
        }

        public string OpacidadConcepto
        {
            get
            {
                return _OpacidadConcepto;
            }

            set
            {
                SetProperty(ref _OpacidadConcepto, value, () => OpacidadConcepto);
            }
        }

        public string EnabledFolio
        {
            get
            {
                return _EnabledFolio;
            }

            set
            {
                SetProperty(ref _EnabledFolio, value, () => EnabledFolio);
            }
        }

        public string OpacidadFolio
        {
            get
            {
                return _OpacidadFolio;
            }

            set
            {
                SetProperty(ref _OpacidadFolio, value, () => OpacidadFolio);
            }
        }

        public string EnabledFecha
        {
            get
            {
                return _EnabledFecha;
            }

            set
            {
                SetProperty(ref _EnabledFecha, value, () => EnabledFecha);
            }
        }

        public string VisibleTraspasopdt
        {
            get
            {
                return _VisibleTraspasopdt;
            }

            set
            {
                SetProperty(ref _VisibleTraspasopdt, value, () => VisibleTraspasopdt);
            }
        }

        public string VisibleAlmacendst
        {
            get
            {
                return _VisibleAlmacendst;
            }

            set
            {
                SetProperty(ref _VisibleAlmacendst, value, () => VisibleAlmacendst);
            }
        }

        public string CodigodeBarra
        {
            get
            {
                return _CodigodeBarra;
            }

            set
            {
                SetProperty(ref _CodigodeBarra, value, () => CodigodeBarra);
            }
        }

        public string VisibleCampoComponenteEditar
        {
            get
            {
                return _VisibleCampoComponenteEditar;
            }

            set
            {
                SetProperty(ref _VisibleCampoComponenteEditar, value, () => VisibleCampoComponenteEditar);
            }
        }

        public string VisibleCampoComponenteNuevo
        {
            get
            {
                return _VisibleCampoComponenteNuevo;
            }

            set
            {
                SetProperty(ref _VisibleCampoComponenteNuevo, value, () => VisibleCampoComponenteNuevo);
            }
        }

        public EntradasInventariosFormViewModel(InventariosES item, string conexion) : base(item, conexion)
        {
            
        }
        //Entrada =0 y Salida =1
        public EntradasInventariosFormViewModel(int tipo)
        {

            NaturalezaDocumento = tipo == 0 ? "Entrada" : "Salida";
            Enabled = "False";//al dar nueva entrada desabilita el combo salidas pendientes por asigar a una entrada por transpaso
            Opacidad = "0.6"; //al dar nueva entrada opaca en 60% el combo salidas pendientes por asigar a una entrada por transpaso
            EnabledFecha = NaturalezaDocumento == "Salida" ? "True" : "False";
            CargarConceptosEntrada(NaturalezaDocumento); //carga Los conceptos de naturaleza entrada directo del WEb service WSConceptosES.svc al dar nueva entrada  //LENA COMBO
            CargarAlmacenes();   //Lista de almacenes, para llenar el combo almacenes, el metodo esta en el formulariobase  //LLENACOMBO
            CargarUnidades();
            LstInventariosESDetallesTemp = new System.Collections.ObjectModel.ObservableCollection<InventariosESDetallesModelTemp>();
            DcTriggerActualizadorCambioCelda = new DelegateCommand(ObtenerAlmacenGrupoComponete);
            DcTriggerActualizadorCambioCelda1 = new DelegateCommand<CellValue>(ValidarYcalcularvarioacionempresa, false);//Obtengo El Id de AlmacenGrupoCompOnente  cada vez que se mueven de celda del griD detalles
            DetalleActual = new InventariosESDetallesModelTemp();
            DetalleSeleccionado = new InventariosESDetallesModelTemp();
            DcEliminaFila = new DelegateCommand(EliminaFila);
            DcCodigodeBarras= new DelegateCommand(CodigodeBarras);

            DcAnalizaDetalles = new DelegateCommand<CellValue>(AnalizaDetalles);
            DcExpandirGrupo = new DelegateCommand<object>(ExpandirGrupo);
      //    DcDesactivarCeldas = new DelegateCommand<CellValue>(DesactivarCeldas);
            Item.Fecha = DateTime.Now;
            IdDetalle = 1; //Variable para controlar el id de los detalles del grid de manera local
            EsvisibleEntrada = tipo == 0 ? "True" : "False";
            EsvisibleSalida = tipo == 1 ? "True" : "False";
            VisibleTraspasopdt = tipo == 0 ? "Visible" : "Hidden";
            VisibleAlmacendst = tipo == 1  ? "Visible" : "Hidden";
            VisibleCampoComponenteEditar ="False";
            VisibleCampoComponenteNuevo = "True";


        }

        public void ExpandirGrupo(object row)
        {
            try
            {
                InventariosESDetallesModelTemp celdaactual = (InventariosESDetallesModelTemp)row;
                //Solo expaden para los tipo Numero de serie y  Lote
                if (celdaactual == null) return;
                if(celdaactual.TipoSeguimiento != "NORMAL")
                { 
                    //Expande la fila seleccionada
                    MasterDetailService.ExpandMasterRow(row);
                }
            }
            catch (Exception ex)
            {

               /* DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);*/
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error");

            }
        }
        public void CargarConceptosEntrada(string Naturaleza)
        {
            try
            {
                //////////////////METODO PARA OBTENER LA COLECCION DE DATOS DE LOS CONCEPTOS DE ENTRADA Y SE LE AÑADE  A LA LISTA CORRESPONDIENTE////////////////
                LstConceptosEntrada = new System.Collections.ObjectModel.ObservableCollection<ConceptosES>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSConceptosES.svc", "getConceptosEntradaSalida", Naturaleza, typeof(System.Collections.ObjectModel.ObservableCollection<ConceptosES>), "Naturaleza");
                LstConceptosEntrada = (System.Collections.ObjectModel.ObservableCollection<ConceptosES>)Ws.Peticion();
                
            }
            catch (Exception ex)
            {
                /* DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                           MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);*/
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error");

            }
        }
        public void CargarAlmacenesTranspaso(long tipo)
        {
            try
            {
                LstAlmacenesDestino = new System.Collections.ObjectModel.ObservableCollection<Almacenes>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSAlmacenes.svc", "getAlmacenesxTipo", tipo, typeof(System.Collections.ObjectModel.ObservableCollection<Almacenes>), "id");
                LstAlmacenesDestino = (System.Collections.ObjectModel.ObservableCollection<Almacenes>)Ws.Peticion();



            }
            catch (Exception ex)
            {
                /*  DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                              MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);*/
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error");

            }
        }
        public void CargarTranspasosPendientes(long almacenid)
        {
            try
            {
                LstTranspasosPendientes = new System.Collections.ObjectModel.ObservableCollection<InventariosES>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSESInventarios.svc", "getTranspasosPendientes", almacenid, typeof(System.Collections.ObjectModel.ObservableCollection<InventariosES>), "almacenid");
                LstTranspasosPendientes = (System.Collections.ObjectModel.ObservableCollection<InventariosES>)Ws.Peticion();

            }
            catch (Exception ex)
            {
                /* DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                             MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);*/
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error");

            }
        }
        public void PonerFolioSalidaenLookupEdit(long id)
        {
            try
            {
                LstTranspasosPendientes = new System.Collections.ObjectModel.ObservableCollection<InventariosES>();
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSESInventarios.svc", "getAbrirTranspasoPendiente", id, typeof(System.Collections.ObjectModel.ObservableCollection<InventariosES>), "id");
                LstTranspasosPendientes = (System.Collections.ObjectModel.ObservableCollection<InventariosES>)Ws.Peticion();

            }
            catch (Exception ex)
            {
                /* DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                             MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);*/
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error");

            }
        }
        public override void GuardarItem()
        {
            if (Item.Cancelado == "SI") throw new Exception("No se puede modificar un documento cancelado");
            if (Item.ConceptoId == 13 || Item.ConceptoId==14) throw new Exception("No se puede modificar un documento generado por el sistema");
            Item.Cancelado = "NO";
            Item.SalidaTraspasoId = null;
            Item.ModuloOrigen = "IN";
            if (Item.ConceptoId == 2)
                Item.SalidaTraspasoId = SalidaSeleccionado.Id;
            //PASA LOS DATOS DEL DETALLE POR CADA CAMPO DE LA ENTRADA DEL MODELO TEMPORAL AL MODELO REAL
            Item.InventariosESDetalles.Clear();
            foreach (InventariosESDetallesModelTemp cf in LstInventariosESDetallesTemp)
            {
                InventariosESDetalles documento = new InventariosESDetalles();
                documento.Id = cf.Id;
                documento.InventariosESId = Item.Id;
                documento.ConceptoId = Item.ConceptoId;
                documento.ComponenteId = cf.Componente.Id;
                documento.AlmacenId = Item.AlmacenId;
                documento.ComponentesAlmacenesId = cf.ComponentesAlmacenesId;
                documento.Cantidad = cf.Cantidad;
                documento.CostoUnitario = cf.CostoUnitario;
                documento.CostoTotal = cf.CostoTotal;
                documento.Naturaleza = ConceptoSeleccionado.Naturaleza;
                documento.Fecha = Item.Fecha;
                documento.TipoSeguimiento = cf.TipoSeguimiento;
                documento.Componentes = cf.Componente;

                if (cf.TipoSeguimiento != "NORMAL")
                    foreach (DetallesLotes_Series_ESTemp DetalleSerieLote in cf.LstDetallesLotesSeries)
                    {
                        documento.InventariosESLotesSeries.Add(new InventariosESLotesSeries{
                            Id=DetalleSerieLote.Id,
                            InventariosESDetalleId = cf.Id,
                            Cantidad = DetalleSerieLote.Cantidad,
                            LotesSeriesId=DetalleSerieLote.LoteSerieId,
                            LotesSeries = new LotesSeries
                            {
                                ComponenteId = cf.Componente.Id,
                                Lote = cf.TipoSeguimiento == "LOTES" ? DetalleSerieLote.SerieLote : null,
                                FechaCaducidad = cf.TipoSeguimiento == "LOTES" ? DetalleSerieLote.FechaCaducidad : null,
                                NumeroSerie = cf.TipoSeguimiento == "NÚMERO DE SERIE" ? DetalleSerieLote.SerieLote : null
                            }
                        });
                    }

                Item.InventariosESDetalles.Add(documento);
            }
            base.GuardarItem();

        }

        public override void CargarItem()
        {
            base.CargarItem();
            string serielote;
            
            IconCancelar = true;
            NaturalezaDocumento = Item.Naturaleza;
            EnabledTodos = "False";//al dar nueva entrada desabilita el combo salidas pendientes por asigar a una entrada por transpaso
            OpacidadTodos = "0.98"; //al dar nueva entrada opaca en 60% el combo salidas pendientes por asigar a una entrada por transpaso
            EnabledConcepto = "False";
            Opacidad = "0.98";
            EnabledFolio = "False";
            OpacidadFolio = "0.98";
            EnabledFecha = "False";
            VisibleTraspasopdt = Item.Naturaleza == "ENTRADA" ? "Visible" : "Hidden";
            VisibleAlmacendst = Item.Naturaleza == "SALIDA" ? "Visible" : "Hidden";
            VisibleCampoComponenteEditar = "True";
            VisibleCampoComponenteNuevo = "False";
            CargarConceptosEntrada(NaturalezaDocumento); //carga Los conceptos de naturaleza entrada directo del WEb service WSConceptosES.svc al dar nueva entrada  //LENA COMBO
            CargarAlmacenes();   //Lista de almacenes, para llenar el combo almacenes, el metodo esta en el formulariobase  //LLENACOMBO
            CargarUnidades();                        
            LstInventariosESDetallesTemp = new System.Collections.ObjectModel.ObservableCollection<InventariosESDetallesModelTemp>();
            DcTriggerActualizadorCambioCelda = new DelegateCommand(ObtenerAlmacenGrupoComponete);
            DcTriggerActualizadorCambioCelda1 = new DelegateCommand<CellValue>(ValidarYcalcularvarioacionempresa, false);//Obtengo El Id de AlmacenGrupoCompOnente  cada vez que se mueven de celda del griD detalles
            DetalleActual = new InventariosESDetallesModelTemp();
            DetalleSeleccionado = new InventariosESDetallesModelTemp();
            

            //     DcEliminaFila = new DelegateCommand(EliminaFila);
            DcAnalizaDetalles = new DelegateCommand<CellValue>(AnalizaDetalles);
            DcExpandirGrupo = new DelegateCommand<object>(ExpandirGrupo);
       //     DcDesactivarCeldas = new DelegateCommand<CellValue>(DesactivarCeldas);
            //DESACTIVAR CAMPOS QUE NO SE PUEDEN MODIFICAR

            IdDetalle = 1; //Variable para controlar el id de los detalles del grid de manera local

            AlmacenSeleccionado = LstAlmacenes.Where(id => id.Id == Item.AlmacenId).Single();
            if (Item.AlmacenDestinoId != null)
            { 
            CargarAlmacenesTranspaso(AlmacenSeleccionado.TipoComponenteId);
            AlmacenSeleccionadoDestino = LstAlmacenesDestino.Where(id => id.Id == Item.AlmacenDestinoId).Single();
            }
            if (Item.ConceptoId == 2)
            {
              PonerFolioSalidaenLookupEdit((long)Item.SalidaTraspasoId);
                SalidaSeleccionado = LstTranspasosPendientes.Single();
            }
            if (Item.ConceptoId == 13 || Item.ConceptoId == 14)
            {
                if(Item.ConceptoId==13)
                LstConceptosEntrada.Add(new ConceptosES {Id=Item.ConceptoId,Nombre= "Entrada por cancelacion",Clave="EXCC",Predefinido="SI",Naturaleza="ENTRADA",FolioAutomatico="SI",CostoAutomatico="SI" });
                else
                LstConceptosEntrada.Add(new ConceptosES { Id = Item.ConceptoId, Nombre = "Salida por cancelacion", Clave = "SXCC", Predefinido = "SI", Naturaleza = "SALIDA", FolioAutomatico = "SI", CostoAutomatico = "SI" });

            }
         
            ConceptoSeleccionado = LstConceptosEntrada.Where(id => id.Id == Item.ConceptoId).Single();
            ReadOnly = "True";
            ReadOnlyCosto = "True";
            Enabled = "False";
            Opacidad = "0.98"; 
            EsvisibleEntrada = NaturalezaDocumento == "ENTRADA" ? "True" : "False";
            EsvisibleSalida = NaturalezaDocumento == "SALIDA" ? "True" : "False";
            Visibleentrada = Item.Naturaleza == "ENTRADA" ? "Visible" : "Hidden";
            Visiblesalida = Item.Naturaleza == "SALIDA" ? "Visible" : "Hidden";
            //Llena las listas de objetos temporales de los grids con los datos de la bd
            //

           foreach (InventariosESDetalles cf in Item.InventariosESDetalles)
            {
                
                InventariosESDetallesModelTemp documento = new InventariosESDetallesModelTemp();
                documento.Id = cf.Id;
                documento.IdDetalle = (int)cf.Id;
                documento.Clave = cf.Componentes.Clave;
                documento.InventariosESId = Item.Id;
                documento.ConceptoId = cf.ConceptoId;
                documento.UnidadBaseId = cf.Componentes.Unidades.Id;
                documento.Componente = cf.Componentes;
                documento.Naturaleza = cf.Naturaleza;
                documento.AlmacenId = cf.AlmacenId;
                documento.ComponenteId = cf.ComponenteId;
                documento.Cantidad = cf.Cantidad;
                documento.CostoUnitario = cf.CostoUnitario;
                documento.CostoTotal = cf.CostoTotal;
                documento.TipoSeguimiento = cf.Componentes.TipoSeguimiento;
                documento.MetodoCosteo = cf.MetodoCosteo;
                documento.ComponentesAlmacenesId = cf.ComponentesAlmacenesId;
            /*    ServicioWS Ws1 = new ServicioWS("ServiciosERP/Inventarios/WSESInventarios.svc", "getSerielotexcomponente", cf, typeof(System.Collections.ObjectModel.ObservableCollection<LotesSeriesModel>), "inventarioentradaosalida");
                documento.LstLotesSeries = (System.Collections.ObjectModel.ObservableCollection<LotesSeriesModel>)Ws1.Peticion();*/


                if (documento.TipoSeguimiento != "NORMAL")
                    foreach (InventariosESLotesSeries DetalleSerieLote in cf.InventariosESLotesSeries)
                    {
                        


                        System.Collections.ObjectModel.ObservableCollection<LotesSeries> lts = new System.Collections.ObjectModel.ObservableCollection<LotesSeries>();
                        if (DetalleSerieLote.LotesSeries.NumeroSerie != null)
                        { 
                            serielote = DetalleSerieLote.LotesSeries.NumeroSerie;

                            if (serielote == "SIN SERIE" && cf.Naturaleza == "SALIDA") {
                                if (documento.LstLotesSeries == null)
                                { 
                                   ServicioWS Ws1 = new ServicioWS("ServiciosERP/Inventarios/WSESInventarios.svc", "getSerielotexcomponente", cf, typeof(System.Collections.ObjectModel.ObservableCollection<LotesSeries>), "inventarioentradaosalida");
                                   documento.LstLotesSeries = (System.Collections.ObjectModel.ObservableCollection<LotesSeries>)Ws1.Peticion();
                                } 
                                lts = documento.LstLotesSeries;

                            }
                            else
                                lts.Add(new LotesSeries {NumeroSerie = serielote});
                        }
                        else if (DetalleSerieLote.LotesSeries.Lote != null)
                        {
                            serielote = DetalleSerieLote.LotesSeries.Lote;
                            if (serielote == "SIN LOTE" && cf.Naturaleza=="SALIDA") {
                                if (documento.LstLotesSeries == null)
                                {
                                    ServicioWS Ws1 = new ServicioWS("ServiciosERP/Inventarios/WSESInventarios.svc", "getSerielotexcomponente", cf, typeof(System.Collections.ObjectModel.ObservableCollection<LotesSeries>), "inventarioentradaosalida");
                                documento.LstLotesSeries = (System.Collections.ObjectModel.ObservableCollection<LotesSeries>)Ws1.Peticion();
                                }
                                lts = documento.LstLotesSeries;
                                
                            }
                            else
                                lts.Add(new LotesSeries{Lote = serielote});
                        }
                        else
                            serielote = null;
                        documento.LstDetallesLotesSeries.Add(new DetallesLotes_Series_ESTemp {
                                  Id = DetalleSerieLote.Id,
                                  ParentId = documento.IdDetalle,
                                  InventariosESDetalleId = documento.Id,
                                  TipoSeguimiento = documento.TipoSeguimiento,
                                  LoteSerieId = (long)DetalleSerieLote.LotesSeriesId,
                                  ComponenteId = DetalleSerieLote.LotesSeries.ComponenteId,
                                  Cantidad = DetalleSerieLote.Cantidad,
                                  Naturaleza = Item.Naturaleza,
                                  LstLotesSeries=lts,
                                  SerieLote= serielote,
                                  SerieLotebd=serielote,
                                  FechaCaducidad=DetalleSerieLote.LotesSeries.FechaCaducidad,
                                 
                        });
                    }
                LstInventariosESDetallesTemp.Add(documento);
               
            }
          //    CargarTemporales();
        }

        public void cargarDetallesTranspasoEntrada(InventariosES dm)
        {
    
            if (dm != null)
            {
                VisibleCampoComponenteEditar = "True";
                VisibleCampoComponenteNuevo = "False";
                foreach (InventariosESDetalles cf in dm.InventariosESDetalles)
              {

                InventariosESDetallesModelTemp documento = new InventariosESDetallesModelTemp();
                documento.Id = cf.Id;
                documento.IdDetalle = (int)cf.Id;
                documento.Clave = cf.Componentes.Clave;
                         documento.InventariosESId = Item.Id;
                    //     documento.ConceptoId = cf.ConceptoId;
                    //        documento.UnidadBaseId = cf.Componentes.Unidades.Nombre;
                    //        documento.Naturaleza = cf.Naturaleza;
                    //        documento.AlmacenId = cf.AlmacenId;
                    documento.Componente = cf.Componentes;
                    documento.ComponenteId = cf.ComponenteId;
                    
                documento.Cantidad = cf.Cantidad;
                documento.CostoUnitario = cf.CostoUnitario;
                documento.CostoTotal = cf.CostoTotal;
                documento.TipoSeguimiento = cf.Componentes.TipoSeguimiento;
                documento.MetodoCosteo = cf.MetodoCosteo;
                    //documento.ComponentesAlmacenesId = cf.ComponentesAlmacenesId;


                    if (documento.TipoSeguimiento != "NORMAL")
                    foreach (InventariosESLotesSeries DetalleSerieLote in cf.InventariosESLotesSeries)
                    {
                        string serielote;

                        System.Collections.ObjectModel.ObservableCollection<LotesSeries> lts = new System.Collections.ObjectModel.ObservableCollection<LotesSeries>();
                        if (DetalleSerieLote.LotesSeries.NumeroSerie != null)
                        {
                            serielote = DetalleSerieLote.LotesSeries.NumeroSerie;
                            if (serielote == "SIN SERIE")
                                lts = documento.LstLotesSeries;
                            else
                                lts.Add(new LotesSeries { NumeroSerie = serielote });
                        }
                        else if (DetalleSerieLote.LotesSeries.Lote != null)
                        {
                            serielote = DetalleSerieLote.LotesSeries.Lote;
                            if (serielote == "SIN LOTE")
                                lts = documento.LstLotesSeries;
                            else
                                lts.Add(new LotesSeries { Lote = serielote });
                        }
                        else
                            serielote = null;
                        documento.LstDetallesLotesSeries.Add(new DetallesLotes_Series_ESTemp
                        {
                            Id = DetalleSerieLote.Id,
                            ParentId = documento.IdDetalle,
                            InventariosESDetalleId = documento.Id,
                            TipoSeguimiento = documento.TipoSeguimiento,
                            LoteSerieId = (long)DetalleSerieLote.LotesSeriesId,
                            ComponenteId = DetalleSerieLote.LotesSeries.ComponenteId,
                            Cantidad = DetalleSerieLote.Cantidad,
                            Naturaleza=documento.Naturaleza,
                            LstLotesSeries = lts,
                            SerieLote = serielote,
                            SerieLotebd = serielote,
                            FechaCaducidad = DetalleSerieLote.LotesSeries.FechaCaducidad,

                        });
                    }


                LstInventariosESDetallesTemp.Add(documento);

            }
        }
    }
        public void ObtenerAlmacenGrupoComponete()
        {
            try
            {
                ////////////////////////////////OBTIENE EL GRUPOCOMPONENTE ALMACEN/////////////////////////////////////////////////
                if (DetalleActual == null) throw new Exception("Debes seleccionar un componente de la lista");
                if(DetalleActual.Componente.Id!=0)
                { 
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSComponentes.svc", "get", DetalleActual.Componente.Id, typeof(Componentes), "id"); //obtiene todos los componentes dado el id del componente Actual ejectutado por  DcTriggerActualizadorCambioCelda
                var Componente = (Componentes)Ws.Peticion();

                var componentesalmacenes = Componente.ComponentesAlmacenes.Where(s => s.AlmacenId == AlmacenSeleccionado.Id).FirstOrDefault();  // todos lo componente obtenidos anteriormente, los filtra por el AlmacenSeleccionado y obetenmos un registro
                InventariosESDetallesModelTemp ab = new InventariosESDetallesModelTemp();
                   

                }

            }
            catch (Exception ex)
            {

                /*DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
               MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);*/
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error");

            }
        }
        public void AnalizaDetalles(CellValue celda)
        {
            try
            {
                DetallesLotes_Series_ESTemp celdaactual = (DetallesLotes_Series_ESTemp)celda.Row;

                /*if ((Item.Id != 0 && celda.Property == "SerieLote" ) && (Item.InventariosESDetalles.))
                        throw new Exception("No se puede modificar un lote/serie de un documento ya guardado ");*/

                if (celdaactual.TipoSeguimiento == "NÚMERO DE SERIE")
                {
                    if (celda.Property == "Cantidad")
                    {
                        if (celdaactual.Cantidad != 1)
                        {
                            
                            celdaactual.Cantidad = 1;
                            throw new Exception("Tipo se de seguimiento NÚMERO DE SERIE no permite capturar mas de un valor en cantidad");
                        }
                    }
                    if(celda.Property == "FechaCaducidad")
                    {
                        celdaactual.FechaCaducidad = null;
                        throw new Exception("Tipo se de seguimiento NÚMERO DE SERIE no permite capturar Fecha de caducidad");
                    }
                }
          
                if (celdaactual.TipoSeguimiento == "LOTES")
                {
                    if (celda.Property == "Cantidad")
                    {
                        //Busca el padre del detalle para ser utlilizado en diferentes lados
                        InventariosESDetallesModelTemp lotepadre = LstInventariosESDetallesTemp.Where(padre => padre.IdDetalle == celdaactual.ParentId).Single();

                        //Suma la existencia de los hijos para ver si coincide con la existencia del padre
                        double totalexistenciaHijos = lotepadre.LstDetallesLotesSeries.Sum(ex => ex.Cantidad);

                        if (totalexistenciaHijos > lotepadre.Cantidad)
                        {
                            //Si la celda modificada es el padre pone la sumatoria de los hijos
                            celdaactual.Cantidad = 0;
                            throw new Exception("La existencia de los lotes no puede ser mayor a la de la existencia principal.");
                        }

                        //Busca si existe algun detalle en 0 para capturar para evitar agregar una fila nueva
                        int detallecero = lotepadre.LstDetallesLotesSeries.Where(ex => ex.Cantidad == 0).ToList().Count;

                        //Si la existencia de los hijos es menor a la padre se inserta otra fila
                        if (totalexistenciaHijos < lotepadre.Cantidad)
                        {
                            if (detallecero == 0)
                            {
                                lotepadre.LstDetallesLotesSeries.Add(new DetallesLotes_Series_ESTemp
                                {
                                    Cantidad = 0,
                                    TipoSeguimiento = celdaactual.TipoSeguimiento,
                                    ComponenteId = celdaactual.ComponenteId,
                                    ParentId = celdaactual.ParentId,
                                    Naturaleza=celdaactual.Naturaleza,
                                    LstLotesSeries = celdaactual.LstLotesSeries,
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                /* DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                  MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);*/
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error");

            }
        }
        public void ValidarYcalcularvarioacionempresa(CellValue celda)
        {
            try
            {
                InventariosESDetallesModelTemp celdaactual = (InventariosESDetallesModelTemp)celda.Row;



                if (celda.Property == "Componente")
                {
                    if (NaturalezaDocumento == "Salida")
                        {
                        InventariosESDetalles inv = (new InventariosESDetalles { ComponenteId = celdaactual.Componente.Id, AlmacenId = AlmacenSeleccionado.Id});
                       
                        ServicioWS Ws1 = new ServicioWS("ServiciosERP/Inventarios/WSESInventarios.svc", "getSerielotexcomponente", inv, typeof(System.Collections.ObjectModel.ObservableCollection<LotesSeries>), "inventarioentradaosalida");
                            celdaactual.LstLotesSeries = (System.Collections.ObjectModel.ObservableCollection<LotesSeries>)Ws1.Peticion();

                         
                        /* celdaactual.LstDetallesLotesSeries.Add(new DetallesLotes_Series_ESTemp
                         {
                             Naturaleza=NaturalezaDocumento,

                         });*/

                        //   celdaactual.LstDetallesLotesSeries.Add(new DetallesLotes_Series_ESTemp{Naturaleza=NaturalezaDocumento});
                        //    RaisePropertyChanged(() => celdaactual.Lote);
                    }
                    if (celdaactual == null) return;
                    if (celdaactual.LstDetallesLotesSeries.Count == 0)
                        return;

                    //Obtengo el primer detalle de los objetos hijos
                    DetallesLotes_Series_ESTemp ComponenteIdHijo = celdaactual.LstDetallesLotesSeries.First();
                    
                    if (celdaactual.TipoSeguimiento == ComponenteIdHijo.TipoSeguimiento)
                        return;

                  /*  guardar_si_no = DXMessageBox.Show(this.OwnerVista, "Se perderan los numeros de Series/Lotes ¿Desea continuar?", "Confirmación", MessageBoxButton.YesNo,
                        MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);*/
                    guardar_si_no = DXMessageBox.Show(this.OwnerVista, "Se perderan los numeros de Series/Lotes ¿Desea continuar?", "Advertencia", MessageBoxButton.YesNo);

                    if (guardar_si_no == MessageBoxResult.Yes) 
                    {
                        celdaactual.LstDetallesLotesSeries.Clear();
                    }
                    else
                        celdaactual.Componente.Id = ComponenteIdHijo.ComponenteId;

                }
                if (celda.Property == "CostoUnitario")
                {
                    try
                    {
                        InventariosESDetalles inv = (new InventariosESDetalles { ComponenteId = DetalleActual.Componente.Id, CostoUnitario = DetalleActual.CostoUnitario, });
                    ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSESInventarios.svc", "CalcularVariacionCosto", inv, null, "inventarioentradaosalida"); //obtiene todos los componentes dado el id del componente Actual ejectutado por  DcTriggerActualizadorCambioCelda
                    var Componente = Ws.Peticion();
                    }
                    catch (Exception ex)
                    {

                        DXMessageBox.Show(this.OwnerVista, ex.Message, "Advertencia");

                    }
                }
                if (celda.Property == "Cantidad")
                {
                    try
                    {
                        if (NaturalezaDocumento == "Entrada") { 
                        InventariosESDetalles inv = (new InventariosESDetalles { ComponenteId = DetalleActual.Componente.Id, Cantidad = DetalleActual.Cantidad, AlmacenId = AlmacenSeleccionado.Id });
                        ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSESInventarios.svc", "ValidarMaximo", inv, null, "inventarioentradaosalida"); //obtiene todos los componentes dado el id del componente Actual ejectutado por  DcTriggerActualizadorCambioCelda
                        Ws.Peticion();
                        }

                    }
                    catch (Exception ex)
                    {

                        DXMessageBox.Show(this.OwnerVista,ex.Message,"Advertencia");

                    }

                    //Le agrego el IdDetalle al registro hasta que le escribe una cantidad al componente
                   celdaactual.IdDetalle = celdaactual.IdDetalle == 0 ? IdDetalle++ : celdaactual.IdDetalle;

                    if (celdaactual.TipoSeguimiento == "NÚMERO DE SERIE")
                    {
                        //Numero de serie solo permite valores numericos
                        if (celdaactual.Cantidad.ToString().Contains("."))
                        {
                            celdaactual.Cantidad = 0;
                            throw new Exception("Los componetes con tipo de seguimiento NUMERO DE SERIE solo permiten cantidades enteras");
                        }

                        //Calculo el numero de hijos acutales
                        int totalHijos = celdaactual.LstDetallesLotesSeries.ToList().Count;
                        if (celdaactual.Cantidad < totalHijos)
                        {
                            celdaactual.Cantidad = totalHijos;
                            throw new Exception("No puede escribir un valor menor a la existencia, elimine manualmente los componentes que no necesite.");
                        }

                        for (int total = 1; total <= celdaactual.Cantidad - totalHijos; total++)
                        {
                            celdaactual.LstDetallesLotesSeries.Add(new DetallesLotes_Series_ESTemp
                            {
                                Cantidad = 1,
                                ComponenteId = celdaactual.Componente.Id,
                                TipoSeguimiento = celdaactual.TipoSeguimiento,
                                ParentId = celdaactual.IdDetalle,
                                LstLotesSeries = celdaactual.LstLotesSeries,
                                Naturaleza=NaturalezaDocumento
                              
                        });
                        }


                    }
                    else if (celdaactual.TipoSeguimiento == "LOTES")
                    {
                        //Suma la existencia de los hijos para ver si conciden con la existencia del padre
                        double totalexistenciaHijos = celdaactual.LstDetallesLotesSeries.Sum(ex => ex.Cantidad);

                        if (totalexistenciaHijos > celdaactual.Cantidad)
                        {
                            //Si la celda modificada es el padre pone la sumatoria de los hijos
                            //celdaactual.Cantidad = celdaactual.ParentId != "0" && celdaactual.ParentId != "" ? 0 : totalexistenciaHijos;
                            celdaactual.Cantidad = totalexistenciaHijos;
                            throw new Exception("La existencia de los lotes no puede ser mayor a la de la existencia principal.");
                        }

                        //Busca si existe algun detalle en 0 para capturar para evitar agregar una fila nueva
                        int detallecero = celdaactual.LstDetallesLotesSeries.Where(ex => ex.Cantidad == 0).ToList().Count;

                        //        if(detallecero > 1)


                        //Si la existencia de los hijos es menor a la padre se inserta otra fila
                        if (totalexistenciaHijos < celdaactual.Cantidad)
                        {
                            if (detallecero == 0)
                            {
                                celdaactual.LstDetallesLotesSeries.Add(new DetallesLotes_Series_ESTemp
                                {
                                    Cantidad = 0,
                                    TipoSeguimiento = celdaactual.TipoSeguimiento,
                                    ComponenteId = celdaactual.Componente.Id,
                                    ParentId = celdaactual.IdDetalle,
                                    LstLotesSeries = celdaactual.LstLotesSeries,
                                    Naturaleza=NaturalezaDocumento
                                });
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
              
                      DXMessageBox.Show(this.OwnerVista, ex.Message, "Advertencia");

            }

        }
        public override void Limpiar()
        {
            DateTime fechadocumento = Item.Fecha;
            Item = null;
            Item = new InventariosES();
            LstComponentes.Clear();
            LstInventariosESDetallesTemp.Clear();
            Item.Fecha = fechadocumento;
            RaisePropertyChanged(() => Item);
            EnabledTodos = "true";
            OpacidadTodos = "1";
            EnabledConcepto = "true";
            Opacidad = "1";
            SalidaSeleccionado = null;
   
        }

        public void CargarTemporales()
        {
            //Pasar del objeto real a los objetos temporales

            //detalles
       //     Item.InventariosESDetalles.Clear();

            foreach (InventariosESDetalles cf in Item.InventariosESDetalles)
            {
                InventariosESDetallesModelTemp documento = new InventariosESDetallesModelTemp();
                documento.Id = cf.Id;
                documento.InventariosESId = Item.Id;
                documento.ConceptoId = Item.ConceptoId;
                documento.ComponenteId = cf.ComponenteId;
                documento.AlmacenId = Item.AlmacenId;
                documento.ComponentesAlmacenesId = cf.ComponentesAlmacenesId;
                documento.Cantidad = cf.Cantidad;
                documento.CostoUnitario = cf.CostoUnitario;
                documento.CostoTotal = cf.CostoTotal;
                documento.Naturaleza = ConceptoSeleccionado.Naturaleza;
                Item.InventariosESDetalles.Add(cf);
            }

        }
    
        public void CodigodeBarras()
        {
            try
            {
                if (CodigodeBarra == "" || CodigodeBarra == null || LstComponentes==null || LstComponentes.Count==0)
                    return;

                ServicioWS Ws1 = new ServicioWS("ServiciosERP/Inventarios/WSComponentes.svc", "getComponenteCodigodeBarra",CodigodeBarra, typeof(ComponentesCodigosBarras), "codigo");
                ComponentesCodigosBarras Cmp_Barra = (ComponentesCodigosBarras)Ws1.Peticion();

                if (Cmp_Barra == null)
                    throw new Exception("El componente no se encuentra registrado");

                Componentes Cmp = LstComponentes.Where(c => c.Id == Cmp_Barra.ComponenteId && c.UnidadInventarioId==Cmp_Barra.UnidadId).SingleOrDefault();

                if (Cmp == null)
                    throw new Exception("El componente no se encuentra registrado");

                InventariosESDetallesModelTemp detalle= new InventariosESDetallesModelTemp();
                detalle = LstInventariosESDetallesTemp.Where(c => c.Componente.Id == Cmp_Barra.ComponenteId).SingleOrDefault();

                if (detalle == null)
                {
                    InventariosESDetallesModelTemp detalle_componente = new InventariosESDetallesModelTemp();
                    detalle_componente.Componente = new Componentes();
                    detalle_componente.Clave = Cmp.Clave;
                    detalle_componente.Componente = Cmp;

                    /*detalle_componente.Componente.Id = Cmp.Id;
                    detalle_componente.TipoSeguimiento = Cmp.TipoSeguimiento;
                    detalle_componente.UnidadBaseId = LstUnidades.Where(c=> c.Id == Cmp.UnidadInventarioId).Single().Nombre;*/

                    LstInventariosESDetallesTemp.Add(detalle_componente);
                    DetalleActual = detalle_componente;

                    CellValue celda = new CellValue(detalle_componente, "Componente", detalle_componente.Componente.Id);
                    ValidarYcalcularvarioacionempresa(celda);

                    CellValue celda2 = new CellValue(detalle_componente, "Cantidad", detalle_componente.Cantidad++);
                    ValidarYcalcularvarioacionempresa(celda2);
                }
                else
                {
                    DetalleActual = detalle;
                    detalle.Cantidad=detalle.Cantidad+1;

                    CellValue celda = new CellValue(detalle, "Cantidad", detalle.Cantidad);
                    ValidarYcalcularvarioacionempresa(celda);
                }

                CodigodeBarra = "";
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error");
            }
        }

public void EliminaFila()
        {
            try
            {
                //Si subdetalle es nulo quiere decir que tiene seleccionado un padre
                if(SubDetalleSeleccinado ==null)
                {   
                    LstInventariosESDetallesTemp.Remove(DetalleActual);
                    DetalleActual = null;
                }
                else
                {
                    //Busca el padre del detalle para ser utlilizado en diferentes lados
                    InventariosESDetallesModelTemp lotepadre = LstInventariosESDetallesTemp.Where(padre => padre.IdDetalle == SubDetalleSeleccinado.ParentId).Single();
                    if (SubDetalleSeleccinado.TipoSeguimiento== "NÚMERO DE SERIE")
                    {
                        lotepadre.Cantidad--;
                    }
                    if (SubDetalleSeleccinado.TipoSeguimiento == "LOTES")
                    {
                        //Siempre tiene que haber por lo menos un hijo
                        if (lotepadre.LstDetallesLotesSeries.Count == 1)
                            return;

                        //Busca si existe algun detalle en 0 para capturar para evitar agregar una fila nueva
                        int detallecero = lotepadre.LstDetallesLotesSeries.Where(ex => ex.Cantidad == 0).ToList().Count;
                        if (detallecero == 0)
                        {
                            lotepadre.LstDetallesLotesSeries.Add(new DetallesLotes_Series_ESTemp
                            {
                                Cantidad = 0,
                                TipoSeguimiento = SubDetalleSeleccinado.TipoSeguimiento,
                                ComponenteId = SubDetalleSeleccinado.ComponenteId,
                                ParentId = SubDetalleSeleccinado.ParentId,
                                Naturaleza=NaturalezaDocumento
                            });
                        }
                    }
                    //Elimina al hijo
                    lotepadre.LstDetallesLotesSeries.Remove(SubDetalleSeleccinado);
                }
            }
            catch (Exception ex)
            {

               /* DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
               MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);*/
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error");
            }
        }
    /*    public void LotesSeries(CellValue celdas)
        {
            try
                {
 
                    DetallesLotes_Series_ESTemp loteserielst = new DetallesLotes_Series_ESTemp(); 

               if (celdas.Property == "ComponenteId")
                {
                    if (NaturalezaDocumento == "Salida")
                    {
                        ServicioWS Ws1 = new ServicioWS("ServiciosERP/Inventarios/WSESInventarios.svc", "getSerielotexcomponente", celdas.Value, typeof(System.Collections.ObjectModel.ObservableCollection<LotesSeriesModel>), "id");
                        loteserielst.LstLotesSeries = (System.Collections.ObjectModel.ObservableCollection<LotesSeriesModel>)Ws1.Peticion();
                   
                    }
                    
                }


            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
               MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        */
        ////////////////////CLASE PARA EL DETALLE DEL GRID, TEMPORAL AVISA CAMBIOS POR CADA CAMPO/////////////////////////
        public class InventariosESDetallesModelTemp :ViewModelBase
        {
            private long _Id;
            private int _IdDetalle;
            private string _Clave;
            private long _InventariosESId;
            private long _ConceptoId;
            private long _UnidadBaseId;
            private string _Naturaleza;
            private long _AlmacenId;
            private long _ComponenteId;
            private double _Cantidad;
            private double _CostoUnitario;
            private double _CostoTotal;
            private string _TipoSeguimiento;
            private string _MetodoCosteo;
            private Componentes _Componente;
            private string _Lote;
            private Nullable<System.DateTime> _FechaCaducidad;
            private string _NumeroSerie;
            private long _ComponentesAlmacenesId;
            private System.Collections.ObjectModel.ObservableCollection<DetallesLotes_Series_ESTemp> _LstDetallesLotesSeries;
            private System.Collections.ObjectModel.ObservableCollection<LotesSeries> _LstLotesSeries;


            public InventariosESDetallesModelTemp()
            {
                LstDetallesLotesSeries = new System.Collections.ObjectModel.ObservableCollection<DetallesLotes_Series_ESTemp>();
            }
            public void CargarDatosComponente(long idComponente)
            {
                try
                {
                    if (idComponente == 0)
                        return;
                    //////////////////OBTIENE EL STRING DE LA UNIDAD Y SU CLAVE DADO EL ID DEL COMPONENTE///////////////////////////
                    /*ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSComponentes.svc", "get", idComponente, typeof(ComponentesModel), "id");
                    var Componente = (ComponentesModel)Ws.Peticion();*/
                    Clave = this.Componente.Clave;
                    UnidadBaseId = (long)this.Componente.UnidadInventarioId; //Finalidad Obtener el campo Nombre de la tabla Unidades dado el id del componente
                    TipoSeguimiento = this.Componente.TipoSeguimiento;
                    

                }
                catch (Exception ex)
                {
                
                    DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error");

                }
            }

            public long Id
            {
                get
                {
                    return _Id;
                }

                set
                {
                    _Id = value;
                    RaisePropertyChanged(() => Id);
                }
            }

            public long InventariosESId
            {
                get
                {
                    return _InventariosESId;
                }

                set
                {
                    _InventariosESId = value;
                    RaisePropertyChanged(() => InventariosESId);
                }
            }

            public long ConceptoId
            {
                get
                {
                    return _ConceptoId;
                }

                set
                {
                    _ConceptoId = value;
                    RaisePropertyChanged(() => ConceptoId);
                }
            }

            public string Naturaleza
            {
                get
                {
                    return _Naturaleza;
                }

                set
                {
                    _Naturaleza = value;
                    RaisePropertyChanged(() => Naturaleza);
                }
            }

            public long AlmacenId
            {
                get
                {
                    return _AlmacenId;
                }

                set
                {
                    _AlmacenId = value;
                    RaisePropertyChanged(() => AlmacenId);
               
                }
            }

            public long ComponenteId
            {
                get
                {
                    return _ComponenteId;
                }

                set
                {
                    _ComponenteId = value;
                    RaisePropertyChanged(() => ComponenteId);
      
                }
            }

            public double Cantidad
            {
                get
                {
                    return _Cantidad;
                }

                set
                {
                    _Cantidad = value;
                    RaisePropertyChanged(() => Cantidad);
                    //////////////////CALCULA EL COSTO TOTAL TENIENDO EL COSTO UNITARIO Y LA CANTIDAD DE COMPONENTES/////
                    CostoTotal = CostoUnitario * Cantidad;
                }
            }

            public double CostoUnitario
            {
                get
                {
                    return _CostoUnitario;
                }

                set
                {

               _CostoUnitario = value;
               RaisePropertyChanged(() => CostoUnitario);
               CostoTotal = CostoUnitario * Cantidad;
                }
            }

            public double CostoTotal
            {
                get
                {
                    return _CostoTotal;
                }

                set
                {
                    _CostoTotal = value;
                    RaisePropertyChanged(() => CostoTotal);
                    
                }
            }

            public string MetodoCosteo
            {
                get
                {
                    return _MetodoCosteo;
                }

                set
                {
                    _MetodoCosteo = value;
                    RaisePropertyChanged(() => MetodoCosteo);
                }
            }

            public string Lote
            {
                get
                {
                    return _Lote;
                }

                set
                {
                    _Lote = value;
                    RaisePropertyChanged(() => Lote);
                }
            }

            public DateTime? FechaCaducidad
            {
                get
                {
                    return _FechaCaducidad;
                }

                set
                {
                    _FechaCaducidad = value;
                    RaisePropertyChanged(() => FechaCaducidad);
                }
            }

            public string NumeroSerie
            {
                get
                {
                    return _NumeroSerie;
                }

                set
                {
                    _NumeroSerie = value;
                    RaisePropertyChanged(() => NumeroSerie);
                }
            }

            public long ComponentesAlmacenesId
            {
                get
                {
                    return _ComponentesAlmacenesId;
                }

                set
                {
                    _ComponentesAlmacenesId = value;
                    RaisePropertyChanged(() => ComponentesAlmacenesId);
                }
            }

            public string Clave
            {
                get
                {
                    return _Clave;
                }

                set
                {
                    _Clave = value;
                    RaisePropertyChanged(() => Clave);
                }
            }

            public long UnidadBaseId
            {
                get
                {
                    return _UnidadBaseId;
                }

                set
                {
                    _UnidadBaseId = value;
                    RaisePropertyChanged(() => UnidadBaseId);
                }
            }
            public string TipoSeguimiento
            {
                get
                {
                    return _TipoSeguimiento;
                }

                set
                {
                    _TipoSeguimiento = value;
                    RaisePropertyChanged(() => TipoSeguimiento);
                }
            }

            public System.Collections.ObjectModel.ObservableCollection<DetallesLotes_Series_ESTemp> LstDetallesLotesSeries
            {
                get
                {
                    return _LstDetallesLotesSeries;
                }

                set
                {
                        _LstDetallesLotesSeries = value;
                    DetallesLotes_Series_ESTemp inv = (new DetallesLotes_Series_ESTemp { Naturaleza = Naturaleza });
                    RaisePropertyChanged(() => LstDetallesLotesSeries);
                }
            }

            public int IdDetalle
            {
                get
                {
                    return _IdDetalle;
                }

                set
                {
                    _IdDetalle = value;
                    RaisePropertyChanged(() => IdDetalle);
                }
            }

            public System.Collections.ObjectModel.ObservableCollection<LotesSeries> LstLotesSeries
            {
                get
                {
                    return _LstLotesSeries;
                }

                set
                {
                    _LstLotesSeries = value;
                    RaisePropertyChanged(() => LstLotesSeries);
                }
            }

            public Componentes Componente
            {
                get
                {
                    return _Componente;
                }

                set
                {
                    _Componente = value;
                    RaisePropertyChanged(() => Componente);
                    //////////////////OBTIENE EL STRING DE LA UNIDAD Y SU CLAVE DADO EL ID DEL COMPONENTE///////////////////////////
                    CargarDatosComponente(Componente.Id);
                    //  Cantidad = 0;
                }
            }
        }

    }
}

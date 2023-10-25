using CaficaERP.Model.Compras;
using CaficaERP.Model.Generales;
using CaficaERP.Model.Inventarios;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CaficaERP.ViewModel.Inventarios
{
    public class ComponentesFormViewModel : FormularioViewModel<Componentes>
    { 
        //COMBOS
        private GruposComponentes _GrupoComponentesSeleccionado;
        private SubgruposComponentes _SubgrupoComponentesSeleccionado;
        private GruposUnidades _GrupoUnidadesSeleccionado;
        private Unidades _UnidadInventarioSeleccionada;
        private Unidades _UnidadVentaSeleccionada;
        private Unidades _UnidadCompraSeleccionada;
        private object _InventariableSeleccionado;
        //GRIDS
        private CodigosBarraTemp _CodigoSeleccionado;
        private System.Collections.ObjectModel.ObservableCollection<CodigosBarraTemp> _lstCodigosBarraTemp;
        private System.Collections.ObjectModel.ObservableCollection<AlmacenesConfigTemp> _lstAlmacenesConfig;
        private System.Collections.ObjectModel.ObservableCollection<FormulaTemp> _lstComponentesFormula;
        private System.Collections.ObjectModel.ObservableCollection<ComponentesFormula> _lstHistorialFormula;
        private System.Collections.ObjectModel.ObservableCollection<FormulaTemp> _lstHistorialFormulaDetalle;
        private System.Collections.ObjectModel.ObservableCollection<ComponentesFormulaDetalles> _lstHistorialFormulaDetalleTodos;
        private System.Collections.ObjectModel.ObservableCollection<EquivalenciasPartesTemp> _lstEquivalenciasPartes;
        private System.Collections.ObjectModel.ObservableCollection<ImpuestosTemp> _lstComponentesImpuestos;
        private AlmacenesConfigTemp _AlmacenSeleccionado;
        private FormulaTemp _ComponenteFormulaSeleccionado;
        private ComponentesFormula _HistorialFormulaSeleccionado;
        private EquivalenciasPartesTemp _EquivalenciaSeleccionada;
        private MarcasComponentes _MarcaSeleccionada;
        private ImpuestosTemp _ImpuestoSeleccionado;

        private double _CostoFormula;
        private double _CostoUnidad;
        private byte[] _Imagen;
        private string _ImagenB64;
        //COMMANDS
        public DelegateCommand<int> DcEliminaFila { get; set; }
        public DelegateCommand DcCargarHistorial { get; set; }
        public DelegateCommand DcActualizarCostoFormula { get; set; }



        public ComponentesFormViewModel(int tipo) : base(tipo)
        {
           
            Item.TipoComponenteId = tipo;

            //Para los grids
            CodigoSeleccionado = new CodigosBarraTemp();
            lstCodigosBarraTemp = new System.Collections.ObjectModel.ObservableCollection<CodigosBarraTemp>();
            AlmacenSeleccionado = new AlmacenesConfigTemp();
            LstAlmacenes = new System.Collections.ObjectModel.ObservableCollection<Almacenes>();
            LstAlmacenesConfig = new System.Collections.ObjectModel.ObservableCollection<AlmacenesConfigTemp>();
            LstComponentesFormula = new System.Collections.ObjectModel.ObservableCollection<FormulaTemp>();
            ComponenteFormulaSeleccionado = new FormulaTemp();
            LstEquivalenciasPartes = new System.Collections.ObjectModel.ObservableCollection<EquivalenciasPartesTemp>();
            LstComponentesImpuestos = new System.Collections.ObjectModel.ObservableCollection<ImpuestosTemp>();

            // 
            //Metodos para cargar combos
            CargarGruposComponentesXTipo(Item.TipoComponenteId);
           // CargarTiposComponentes();
            CargarGruposUnidades();
            CargarSiNo();
            CargarImpuestos();

            CargarTiposSeguimiento();
            CargarDirecciones();
            CargarComponentesFormula(Item);
            CargarMarcasComponentes();

            //Commands

            DcEliminaFila = new DelegateCommand<int>(EliminaFilaCodigo);
            DcCargarHistorial = new DelegateCommand(CargarHistorialFormula);
            DcActualizarCostoFormula = new DelegateCommand(ActualizarCostoFormula);


            LstHistorialFormula = new System.Collections.ObjectModel.ObservableCollection<ComponentesFormula>();
            LstHistorialFormulaDetalle = new System.Collections.ObjectModel.ObservableCollection<FormulaTemp>();
            LstHistorialFormulaDetalleTodos = new System.Collections.ObjectModel.ObservableCollection<ComponentesFormulaDetalles>();

            //Agregar los impuestos predeterminados
            foreach (Impuestos i in LstImpuestos.Where(x => x.Predeterminado == "SI").ToList())
            {
                LstComponentesImpuestos.Add(new ImpuestosTemp {
                            ComponenteId=Item.Id,
                             ImpuestoId= i.Id,
                    });
            }
           
        }

        public ComponentesFormViewModel(Componentes item, string conexion) : base(item, conexion)
        {

        }
     
        public byte[] Imagen
        {
            get
            {
                return _Imagen;
            }

            set
            {
                SetProperty(ref _Imagen, value, () => Imagen);
                //Convierte el arreglo de bytes de la imagen a una cadena base 64
                if (Imagen != null)
                    ImagenB64 = Convert.ToBase64String(Imagen);
                else
                    ImagenB64 = null;
            }
        }

        public string ImagenB64
        {
            get
            {
                return _ImagenB64;
            }

            set
            {
                SetProperty(ref _ImagenB64, value, () => ImagenB64);
            }
        }

        public GruposComponentes GrupoComponentesSeleccionado
        {
            get
            {
                return _GrupoComponentesSeleccionado;
            }

            set
            {
                SetProperty(ref _GrupoComponentesSeleccionado, value, () => GrupoComponentesSeleccionado);
                if (GrupoComponentesSeleccionado != null)
                {
                    CargarSubgruposComponentesXGrupo(GrupoComponentesSeleccionado.Id);

                    CargarAlmacenes(GrupoComponentesSeleccionado.Id);
                }
                   
            }
        }

        public GruposUnidades GrupoUnidadesSeleccionado
        {
            get
            {
                return _GrupoUnidadesSeleccionado;
            }

            set
            {
                SetProperty(ref _GrupoUnidadesSeleccionado, value, () => GrupoUnidadesSeleccionado);
                if (GrupoUnidadesSeleccionado != null)
                    CargarUnidadesxGrupo(GrupoUnidadesSeleccionado);
            }
        }

        public CodigosBarraTemp CodigoSeleccionado
        {
            get
            {
                return _CodigoSeleccionado;
            }

            set
            {
                SetProperty(ref _CodigoSeleccionado, value, () => CodigoSeleccionado);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<CodigosBarraTemp> lstCodigosBarraTemp
        {
            get
            {
                return _lstCodigosBarraTemp;
            }

            set
            {
                SetProperty(ref _lstCodigosBarraTemp, value, () => lstCodigosBarraTemp);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<AlmacenesConfigTemp> LstAlmacenesConfig
        {
            get
            {
                return _lstAlmacenesConfig;
            }

            set
            {
                SetProperty(ref _lstAlmacenesConfig, value, () => LstAlmacenesConfig);
            }
        }

        public AlmacenesConfigTemp AlmacenSeleccionado
        {
            get
            {
                return _AlmacenSeleccionado;
            }

            set
            {
                SetProperty(ref _AlmacenSeleccionado, value, () => AlmacenSeleccionado);
            }
        }

        public FormulaTemp ComponenteFormulaSeleccionado
        {
            get
            {
                return _ComponenteFormulaSeleccionado;
            }

            set
            {
                SetProperty(ref _ComponenteFormulaSeleccionado, value, () => ComponenteFormulaSeleccionado);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<FormulaTemp> LstComponentesFormula
        {
            get
            {
                return _lstComponentesFormula;
            }

            set
            {
                SetProperty(ref _lstComponentesFormula, value, () => LstComponentesFormula);
            }
        }
       
        public SubgruposComponentes SubgrupoComponentesSeleccionado
        {
            get
            {
                return _SubgrupoComponentesSeleccionado;
            }

            set
            {
                SetProperty(ref _SubgrupoComponentesSeleccionado, value, () => SubgrupoComponentesSeleccionado);
              
            }
        }

        public Unidades UnidadInventarioSeleccionada
        {
            get
            {
                return _UnidadInventarioSeleccionada;
            }

            set
            {
                SetProperty(ref _UnidadInventarioSeleccionada, value, () => UnidadInventarioSeleccionada);
            }
        }

        public Unidades UnidadVentaSeleccionada
        {
            get
            {
                return _UnidadVentaSeleccionada;
            }

            set
            {
                SetProperty(ref _UnidadVentaSeleccionada, value, () => UnidadVentaSeleccionada);
            }
        }

        public object InventariableSeleccionado
        {
            get
            {
                return _InventariableSeleccionado;
            }

            set
            {
                SetProperty(ref _InventariableSeleccionado, value, () => InventariableSeleccionado);
                if (InventariableSeleccionado != null)
                    if (GrupoComponentesSeleccionado != null)
                        CargarAlmacenes(GrupoComponentesSeleccionado.Id);

                //if(InventariableSeleccionado!=null)
                    //if(InventariableSeleccionado.GetType().GetProperty("nombre").GetValue(InventariableSeleccionado) != null)
                       //if (InventariableSeleccionado.GetType().GetProperty("nombre").GetValue(InventariableSeleccionado).ToString() == "NO"  )
                            //UnidadInventarioSeleccionada = null;
            }
        }

        public double CostoFormula
        {
            get
            {
                return _CostoFormula;
            }

            set
            {
                SetProperty(ref _CostoFormula, value, () => CostoFormula);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<ComponentesFormula> LstHistorialFormula
        {
            get
            {
                return _lstHistorialFormula;
            }

            set
            {
                SetProperty(ref _lstHistorialFormula, value, () => LstHistorialFormula);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<FormulaTemp> LstHistorialFormulaDetalle
        {
            get
            {
                return _lstHistorialFormulaDetalle;
            }

            set
            {
                SetProperty(ref _lstHistorialFormulaDetalle, value, () => LstHistorialFormulaDetalle);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<ComponentesFormulaDetalles> LstHistorialFormulaDetalleTodos
        {
            get
            {
                return _lstHistorialFormulaDetalleTodos;
            }

            set
            {
                _lstHistorialFormulaDetalleTodos = value;
            }
        }

        public double CostoUnidad
        {
            get
            {
                return _CostoUnidad;
            }

            set
            {
                SetProperty(ref _CostoUnidad, value, () => CostoUnidad);
            }
        }

        public ComponentesFormula HistorialFormulaSeleccionado
        {
            get
            {
                return _HistorialFormulaSeleccionado;
            }

            set
            {
                SetProperty(ref _HistorialFormulaSeleccionado, value, () => HistorialFormulaSeleccionado);
                CargarHistorialFormulaDetalle();
            }
        }

        public Unidades UnidadCompraSeleccionada
        {
            get
            {
                return _UnidadCompraSeleccionada;
            }

            set
            {
                SetProperty(ref _UnidadCompraSeleccionada, value, () => UnidadCompraSeleccionada);
            }
        }

        public EquivalenciasPartesTemp EquivalenciaSeleccionada
        {
            get
            {
                return _EquivalenciaSeleccionada;
            }

            set
            {
                SetProperty(ref _EquivalenciaSeleccionada, value, () => EquivalenciaSeleccionada);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<EquivalenciasPartesTemp> LstEquivalenciasPartes
        {
            get
            {
                return _lstEquivalenciasPartes;
            }

            set
            {
                SetProperty(ref _lstEquivalenciasPartes, value, () => LstEquivalenciasPartes);
               
            }
        }

        public MarcasComponentes MarcaSeleccionada
        {
            get
            {
                return _MarcaSeleccionada;
            }

            set
            {
                SetProperty(ref _MarcaSeleccionada, value, () => MarcaSeleccionada);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<ImpuestosTemp> LstComponentesImpuestos
        {
            get
            {
                return _lstComponentesImpuestos;
            }

            set
            {
                SetProperty(ref _lstComponentesImpuestos, value, () => LstComponentesImpuestos);
            }
        }

        public ImpuestosTemp ImpuestoSeleccionado
        {
            get
            {
                return _ImpuestoSeleccionado;
            }

            set
            {
                SetProperty(ref _ImpuestoSeleccionado, value, () => ImpuestoSeleccionado);
           
            }
        }

        public override void CargarItem()
        {
            base.CargarItem();
            //Para los grids
            CodigoSeleccionado = new CodigosBarraTemp();
            lstCodigosBarraTemp = new System.Collections.ObjectModel.ObservableCollection<CodigosBarraTemp>();
            AlmacenSeleccionado = new AlmacenesConfigTemp();
            LstAlmacenesConfig = new System.Collections.ObjectModel.ObservableCollection<AlmacenesConfigTemp>();
            LstAlmacenes = new System.Collections.ObjectModel.ObservableCollection<Almacenes>();
            LstComponentesFormula = new System.Collections.ObjectModel.ObservableCollection<FormulaTemp>();
            ComponenteFormulaSeleccionado = new FormulaTemp();
            LstEquivalenciasPartes = new System.Collections.ObjectModel.ObservableCollection<EquivalenciasPartesTemp>();
            LstComponentesImpuestos=new System.Collections.ObjectModel.ObservableCollection<ImpuestosTemp>();
            // UnidadInventarioSeleccionada = new UnidadesModel();
            // UnidadCompraSeleccionada = new UnidadesModel();
            // UnidadVentaSeleccionada = new UnidadesModel();
            // GrupoUnidadesSeleccionado = new GruposUnidadesModel();

            //Llena las listas de objetos temporales de los grids con los datos de la bd
            CargarTemporales();

            //Metodos para cargar combos
            CargarGruposComponentesXTipo(Item.TipoComponenteId);
           // CargarTiposComponentes();
            CargarGruposUnidades();
            CargarSiNo();
            CargarImpuestos();
            CargarTiposSeguimiento();
            CargarDirecciones();
            CargarComponentesFormula(Item);
            CargarMarcasComponentes();
           
            //Iniciar las propiedades para los objetos seleccionados de los combos
            if(Item.Inventariable!=null)
                InventariableSeleccionado = new { nombre=Item.Inventariable};
           

            GrupoComponentesSeleccionado = LstGruposComponentes.Single(x => x.Id == Item.GrupoComponentesId);
            
            GrupoUnidadesSeleccionado = LstGruposUnidades.SingleOrDefault(x => x.Id == Item.GrupoUnidadesId);
            SubgrupoComponentesSeleccionado = LstSubgruposComponentes.Single(x => x.Id == Item.SubgrupoComponentesId);

            if(Item.UnidadVentaId!=null)
                UnidadVentaSeleccionada = LstUnidades.SingleOrDefault(x => x.Id == Item.UnidadVentaId);
            if(Item.UnidadInventarioId!=null)
                UnidadInventarioSeleccionada = LstUnidades.SingleOrDefault(x => x.Id == Item.UnidadInventarioId);
            if (Item.UnidadCompraId != null)
                UnidadCompraSeleccionada = LstUnidades.SingleOrDefault(x => x.Id == Item.UnidadCompraId);
            if (Item.MarcaId != null)
                MarcaSeleccionada = LstMarcasComponentes.SingleOrDefault(x => x.Id == Item.MarcaId);
            //Commands
            DcEliminaFila = new DelegateCommand<int>(EliminaFilaCodigo);
            DcCargarHistorial = new DelegateCommand(CargarHistorialFormula);
            DcActualizarCostoFormula = new DelegateCommand(ActualizarCostoFormula);

            //Convierte la cadena base 64 a bytes para cargar la imagen
            foreach (ComponentesImagenes ci in Item.ComponentesImagenes)
            {
                Imagen = Convert.FromBase64String(ci.ImagenBase64);
            }
            LstHistorialFormula = new System.Collections.ObjectModel.ObservableCollection<ComponentesFormula>();
            LstHistorialFormulaDetalle = new System.Collections.ObjectModel.ObservableCollection<FormulaTemp>();
            LstHistorialFormulaDetalleTodos = new System.Collections.ObjectModel.ObservableCollection<ComponentesFormulaDetalles>();
        }

        public override void GuardarItem()
        {

            if (Item.TipoComponenteId == 5 && LstComponentesFormula.Count>0) //si es producto terminado y tiene formula
            {
                    if (Item.Rendimiento == 0 || Item.Rendimiento == null)
                    throw new Exception("El campo Rendimiento es Obligatorio");
            }

          

            //Validar que no se repitan codigos de barra
            foreach (FormulaTemp cf in LstComponentesFormula)
            {
               
                if (cf.UnidadId==0)
                    throw new Exception("No se ha especificado la unidad para todos los componentes de la fórmula.");
            }
            //Validar que no se repitan codigos de barra
            foreach (CodigosBarraTemp Gu in lstCodigosBarraTemp)
            {
                var item = lstCodigosBarraTemp.Where(x => x.CodigoBarra == Gu.CodigoBarra).ToList();
                if (item.Count > 1)
                    throw new Exception("No pueden existir dos veces el mismo código de barras");
            }
            //Validar que el tamaño de la cadena base64 de la imagen sea el requerido
            if(ImagenB64!=null)
                if (ImagenB64.Length > 65535)
                    throw new Exception("La imagen seleccionada es demasiado grande");
          
            //Pasar los codigos de barra del objeto temporal al real
            Item.ComponentesCodigosBarras.Clear();
            foreach (CodigosBarraTemp cb in lstCodigosBarraTemp)
            {
                Item.ComponentesCodigosBarras.Add(new ComponentesCodigosBarras
                {
                    Id = cb.Id,
                    ComponenteId = Item.Id,
                    UnidadId = cb.UnidadId,
                    CodigoBarra = cb.CodigoBarra,
                    Activo = cb.Activo,

                });
            }

            //Pasar los almacenes del objeto temporal al real
            Item.ComponentesAlmacenes.Clear();
            foreach (AlmacenesConfigTemp a in LstAlmacenesConfig)
            {
                Item.ComponentesAlmacenes.Add( new ComponentesAlmacenes
                {
                    Id = a.Id,
                    ComponenteId = Item.Id,
                    AlmacenId=a.AlmacenId,
                    Maximo=a.Maximo,
                    Reorden=a.Reorden,
                    Minimo=a.Minimo,
                    Localizacion=a.Localizacion,
                    AlmacenesGruposComponentesId=a.AlmacenesGruposComponentesId
                 });
            }

            //Formula del producto
            //Agregar el objeto padre de la formula
            if (LstComponentesFormula.Count>0)
            {
                Item.ComponentesFormula.Clear();
                ComponentesFormula cfp = new ComponentesFormula
                {
                    ComponenteId = Item.Id,
                    CostoTotal = CostoFormula,
                    Estado = "A",
                    Rendimiento = Item.Rendimiento
                };
                Item.ComponentesFormula.Add(cfp);

                //Pasar los componentes de la formula del objeto temporal al real
                Item.ComponentesFormulaDetalles.Clear();
                foreach (FormulaTemp cf in LstComponentesFormula)
                {
                    Item.ComponentesFormulaDetalles.Add(new ComponentesFormulaDetalles
                    {
                        Id = cf.Id,
                        ComponenteId = Item.Id,
                        ComponenteFormulaId = Item.ComponentesFormula.FirstOrDefault().Id,
                        ComponenteHijoId = cf.ComponenteHijoId,
                        Cantidad = cf.Cantidad,
                        UnidadId = cf.UnidadId,
                        CostoUnitario = cf.CostoUnitario,
                        CostoTotal = cf.CostoTotal,
                        Estado = "A",
                        UsuarioCreo=cf.UsuarioCreo,
                        FechaCreacion=cf.FechaCreacion,
                        UsuarioModifico=cf.UsuarioModifico,
                        FechaUltimaModificacion=cf.FechaUltimaModificacion
                    });
                }

                
            }


            //Pasar las equivalencias de partes al objeto real
            Item.ComponentesEquivalenciasPartes.Clear();
            foreach (EquivalenciasPartesTemp ep in LstEquivalenciasPartes)
            {
                Item.ComponentesEquivalenciasPartes.Add(new ComponentesEquivalenciasPartes
                {
                    Id = ep.Id,
                    ComponenteId = Item.Id,
                    MarcaId = ep.MarcaId,
                    Modelo = ep.Modelo,
                    NoParte = ep.NoParte,
                    UsuarioCreo = ep.UsuarioCreo,
                    FechaCreacion = ep.FechaCreacion,
                    UsuarioModifico = ep.UsuarioModifico,
                    FechaUltimaModificacion = ep.FechaUltimaModificacion
                });
            }

            Item.ComponentesImagenes.Clear();
            //Si se selecciono una imagen , agregarla al objeto
            if (ImagenB64 != null)
            {
                Item.ComponentesImagenes.Add(new ComponentesImagenes
                {
                    ComponenteId = Item.Id,
                    ImagenBase64 = ImagenB64
                }
                );
            }

            //Pasar los impuestos al objeto real
            Item.ComponentesImpuestos.Clear();
            foreach (ImpuestosTemp ic in LstComponentesImpuestos)
            {
                Item.ComponentesImpuestos.Add(new ComponentesImpuestos
                {
                    Id = ic.Id,
                    ComponenteId = Item.Id,
                    ImpuestoId=ic.ImpuestoId,
                    UsuarioCreo = ic.UsuarioCreo,
                    FechaCreacion = ic.FechaCreacion,
                    UsuarioModifico = ic.UsuarioModifico,
                    FechaUltimaModificacion = ic.FechaUltimaModificacion
                });
            }


            base.GuardarItem();

        }

        public override void Limpiar()
        {
            var tipo = Item.TipoComponenteId;
            base.Limpiar();
            Item.TipoComponenteId = tipo;
            Imagen = null;
            LstAlmacenes.Clear();
            LstAlmacenesConfig.Clear();
            LstComponentesFormula.Clear();
            LstHistorialFormula.Clear();
            LstHistorialFormulaDetalle.Clear();
            LstHistorialFormulaDetalleTodos.Clear();
            lstCodigosBarraTemp.Clear();
        }


        public void CargarTemporales()
        {
            //Pasar del objeto real a los objetos temporales

            //Codigos de Barra
            lstCodigosBarraTemp.Clear();
            foreach (ComponentesCodigosBarras cb in Item.ComponentesCodigosBarras)
            {
                lstCodigosBarraTemp.Add(new CodigosBarraTemp
                {
                    Id = cb.Id,
                    ComponenteId = cb.ComponenteId,
                    UnidadId = cb.UnidadId,
                    CodigoBarra = cb.CodigoBarra,
                    Activo = cb.Activo,
                    UsuarioCreo = cb.UsuarioCreo,
                    FechaCreacion = cb.FechaCreacion,
                    UsuarioModifico = cb.UsuarioModifico,
                    FechaUltimaModificacion = cb.FechaUltimaModificacion
                });
            }

            //Almacenes
            LstAlmacenesConfig.Clear();
            foreach (ComponentesAlmacenes  a in Item.ComponentesAlmacenes)
            {
                LstAlmacenesConfig.Add(new AlmacenesConfigTemp
                {
                    Id = a.Id,
                    ComponenteId = Item.Id,
                    AlmacenId = a.AlmacenId,
                    Almacen=a.Almacenes.Clave,
                    Maximo = a.Maximo,
                    Reorden = a.Reorden,
                    Minimo = a.Minimo,
                    Localizacion = a.Localizacion,
                    AlmacenesGruposComponentesId=a.AlmacenesGruposComponentesId,
                    UsuarioCreo = a.UsuarioCreo,
                    FechaCreacion = a.FechaCreacion,
                    UsuarioModifico = a.UsuarioModifico,
                    FechaUltimaModificacion = a.FechaUltimaModificacion
                });

            }

            //Formula
            LstComponentesFormula.Clear();
            foreach (ComponentesFormulaDetalles cf in Item.ComponentesFormulaDetalles)
            {
                LstComponentesFormula.Add(new  FormulaTemp
                {
                    Id = cf.Id,
                    ComponenteId = Item.Id,                  
                    ComponenteFormulaId = cf.ComponenteFormulaId,
                    ComponenteHijoId=cf.ComponenteHijoId,
                    Cantidad = cf.Cantidad,
                    UnidadId = cf.UnidadId,                
                    CostoUnitario = cf.CostoUnitario,
                    CostoTotal = cf.CostoTotal,
                    UsuarioCreo = cf.UsuarioCreo,
                    FechaCreacion = cf.FechaCreacion,
                    UsuarioModifico = cf.UsuarioModifico,
                    FechaUltimaModificacion = cf.FechaUltimaModificacion

                });

            }

            //Pasar las equivalencias del objeto temporal al real
            LstEquivalenciasPartes.Clear();
            foreach (ComponentesEquivalenciasPartes ep in Item.ComponentesEquivalenciasPartes)
            {
                LstEquivalenciasPartes.Add(new EquivalenciasPartesTemp
                {
                    Id = ep.Id,
                    ComponenteId = ep.ComponenteId,
                    MarcaId = ep.MarcaId,
                    Modelo = ep.Modelo,
                    NoParte = ep.NoParte,
                    UsuarioCreo = ep.UsuarioCreo,
                    FechaCreacion = ep.FechaCreacion,
                    UsuarioModifico = ep.UsuarioModifico,
                    FechaUltimaModificacion = ep.FechaUltimaModificacion
                });
            }
            //Pasar los impuestos del objeto temporal al real
            LstComponentesImpuestos.Clear();
            foreach (ComponentesImpuestos ci in Item.ComponentesImpuestos)
            {
                LstComponentesImpuestos.Add(new ImpuestosTemp
                {
                    Id = ci.Id,
                    ComponenteId = ci.ComponenteId,
                     ImpuestoId=ci.ImpuestoId,
                    UsuarioCreo = ci.UsuarioCreo,
                    FechaCreacion = ci.FechaCreacion,
                    UsuarioModifico = ci.UsuarioModifico,
                    FechaUltimaModificacion = ci.FechaUltimaModificacion
                });
            }
        }

        public void EliminaFilaCodigo(int tipo)
        {
            //Metodo para eliminar registros del grid
            try
            {
                switch (tipo)
                {
                    case 1: //Grid de codigo de barras
                        lstCodigosBarraTemp.Remove(CodigoSeleccionado);
                        CodigoSeleccionado = null;
                        break;
                    case 2:// grid de formula
                        LstComponentesFormula.Remove(ComponenteFormulaSeleccionado);
                        ComponenteFormulaSeleccionado = null;
                        break;
                    case 3:// grid de formula
                        LstEquivalenciasPartes.Remove(EquivalenciaSeleccionada);
                        EquivalenciaSeleccionada = null;
                        break;
                    case 4:// grid de impuestos
                        LstComponentesImpuestos.Remove(ImpuestoSeleccionado);
                        EquivalenciaSeleccionada = null;
                        break;
                    default:

                        break;
                }


            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
               MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public void CargarAlmacenes(long grupoid)
        {
            //Metodo que carga los almacenes que corresponden al producto terminado
            try
            {
               if(InventariableSeleccionado!=null)
               { 
                    if (InventariableSeleccionado.GetType().GetProperty("nombre").GetValue(InventariableSeleccionado).ToString() == "SI")//Si es inventariable muestra almacenes
                    {
                        CargarAlmacenesXGrupoComponentes(grupoid);
                        if (Item.Id == 0) //Si es nuevo producto terminado carga todos los almacenes al temporal
                        {
                            LstAlmacenesConfig.Clear();
                            foreach (Almacenes a in LstAlmacenes)
                            {
                                var ag = a.AlmacenesGruposComponentes.Where(x => x.GrupoComponentesId == grupoid).FirstOrDefault();
                                LstAlmacenesConfig.Add(new AlmacenesConfigTemp { AlmacenId = a.Id, Almacen = a.Clave, AlmacenesGruposComponentesId = ag.Id });
                            }
                        }
                        else
                        {
                            //Eliminar los que no aplican para el grupo seleccionado

                            foreach (AlmacenesConfigTemp al in LstAlmacenesConfig)
                            {
                                var existe = LstAlmacenes.Where(x => x.Id == al.AlmacenId).FirstOrDefault();

                                if (existe == null)//Si no existe en almacenes se elimina
                                    LstAlmacenesConfig.Remove(al);

                                if (LstAlmacenesConfig.Count == 0)//Si ya esta vacia la lista se sale del ciclo ya que si continua marca una excepcion
                                    break;
                                
                            }
                            //Se agregan los nuevos almacenes que aplican para el producto
                            foreach (Almacenes al in LstAlmacenes)
                            {
                                var ag = al.AlmacenesGruposComponentes.Where(x => x.GrupoComponentesId == grupoid).FirstOrDefault();
                                var existe = LstAlmacenesConfig.Where(x => x.AlmacenId == al.Id).Count();
                                if (existe == 0)//Si no existe en almacenes se agrega
                                    LstAlmacenesConfig.Add(new AlmacenesConfigTemp { AlmacenId = al.Id, Almacen = al.Clave, AlmacenesGruposComponentesId = ag.Id });
                            }

                        }

                    }
                    else
                    {
                        LstAlmacenesConfig.Clear();
                    }
                }
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }


        }

        private void ActualizarCostoFormula()
        {
            try
            {

                //Calcular el costo
                CostoFormula = 0;
                CostoUnidad = 0;
                foreach (FormulaTemp c in LstComponentesFormula)
                {
                    if (c.CostoTotal != null)
                        CostoFormula = CostoFormula + (double)c.CostoTotal;
                }

                if (Item == null) // Si el item es null se termina el metodo
                    return;

                if (Item.Rendimiento == 0 || Item.Rendimiento == null) // Si el rendimiento es 0 o null el metdodo se interrumpe
                    return;

                CostoUnidad = CostoFormula / (double)Item.Rendimiento;
                Item.Costo = CostoUnidad;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CargarHistorialFormula()
        {
            if(Item.Id!=0)
            {
                //Se carga la lista de las formulas anteriores
                LstHistorialFormula.Clear();
                LstHistorialFormula = CargarLista<ComponentesFormula>("ServiciosERP/Inventarios/WSComponentes.svc", "getHistorialFormula", LstHistorialFormula, Item.Id);
                //Se carga la lista con todos los detalles historicos
                LstHistorialFormulaDetalleTodos.Clear();
                LstHistorialFormulaDetalleTodos = CargarLista<ComponentesFormulaDetalles>("ServiciosERP/Inventarios/WSComponentes.svc", "getHistorialFormulaDetalles", LstHistorialFormulaDetalleTodos, Item.Id);

            }

        }

        public void CargarHistorialFormulaDetalle()
        {
            if (HistorialFormulaSeleccionado != null)
            {
                if (HistorialFormulaSeleccionado.Id != 0)
                {
                    //Detalles de la formual seleccionada
                    LstHistorialFormulaDetalle.Clear();
                    foreach (ComponentesFormulaDetalles cf in LstHistorialFormulaDetalleTodos.Where(x => x.ComponenteFormulaId == HistorialFormulaSeleccionado.Id))
                    {
                        LstHistorialFormulaDetalle.Add(new FormulaTemp
                        {
                            Id = cf.Id,
                            ComponenteId = Item.Id,
                            ComponenteFormulaId = cf.ComponenteFormulaId,
                            ComponenteHijoId = cf.ComponenteHijoId,
                            Cantidad = cf.Cantidad,
                            UnidadId = cf.UnidadId,
                            CostoUnitario = cf.CostoUnitario,
                            CostoTotal = cf.CostoTotal,
                            UsuarioCreo = cf.UsuarioCreo,
                            FechaCreacion = cf.FechaCreacion,
                            UsuarioModifico = cf.UsuarioModifico,
                            FechaUltimaModificacion = cf.FechaUltimaModificacion

                        });

                    }

                }
            }
                

        }



    }

    public class CodigosBarraTemp : ViewModelBase
    {
        //Clase temporal para el manejo del grid de codigos de barras

        private long _Id;
        private long _ComponenteId;
        private long _UnidadId;
        private string _CodigoBarra;
        private string _Activo;
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

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

        public long UnidadId
        {
            get
            {
                return _UnidadId;
            }

            set
            {
                _UnidadId = value;
                RaisePropertyChanged(() => UnidadId);
            }
        }

        public string CodigoBarra
        {
            get
            {
                return _CodigoBarra;
            }

            set
            {
                _CodigoBarra = value;
                RaisePropertyChanged(() => CodigoBarra);
            }
        }

        public string Activo
        {
            get
            {
                return _Activo;
            }

            set
            {
                _Activo = value;
                RaisePropertyChanged(() => Activo);
            }
        }

    }

    public class AlmacenesConfigTemp : ViewModelBase
    {
        //Clase temporal para el manejo del grid de almacenes
        private long _Id;
        private long _ComponenteId;
        private long _AlmacenId;
        private string _Almacen;
        private Nullable<long> _Maximo;
        private Nullable<long> _Reorden;
        private Nullable<long> _Minimo;
        private string _Localizacion;
        public long AlmacenesGruposComponentesId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

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

        public Nullable<long> Maximo
        {
            get
            {
                return _Maximo;
            }

            set
            {
                _Maximo = value;
                RaisePropertyChanged(() => Maximo);
            }
        }

        public Nullable<long> Minimo
        {
            get
            {
                return _Minimo;
            }

            set
            {
                _Minimo = value;
                RaisePropertyChanged(() => Minimo);
            }
        }
        public Nullable<long> Reorden
        {
            get
            {
                return _Reorden;
            }

            set
            {
                _Reorden = value;
                RaisePropertyChanged(() => Reorden);
            }
        }

        public string Localizacion
        {
            get
            {
                return _Localizacion;
            }

            set
            {
                _Localizacion = value;
                RaisePropertyChanged(() => Localizacion);
            }
        }

        public string Almacen
        {
            get
            {
                return _Almacen;
            }

            set
            {
                _Almacen = value;
                RaisePropertyChanged(() => Almacen);
            }
        }
    }

    public class FormulaTemp : ViewModelBase
    {

        private long _Id;
        private long _ComponenteId;
        private string _Clave;
        private long _ComponenteFormulaId;
        private long _ComponenteHijoId;
        private string _NombreComponente;
        private Nullable<double> _Cantidad;
        private long _UnidadId;
        private string _NombreUnidad;
        private long  _GrupoUnidadesId;
        private Nullable<double> _CostoUnitario;
        private Nullable<double> _CostoTotal;
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        private System.Collections.ObjectModel.ObservableCollection<Unidades> _LstUnidades;

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
        public long ComponenteFormulaId
        {
            get
            {
                return _ComponenteFormulaId;
            }

            set
            {
                _ComponenteFormulaId = value;
                RaisePropertyChanged(() => ComponenteFormulaId);
              
            }
        }
        public Nullable<double> Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
                RaisePropertyChanged(() => Cantidad);
                CostoTotal = CostoUnitario * Cantidad;

            }
        }
        public long UnidadId
        {
            get
            {
                return _UnidadId;
            }

            set
            {
                _UnidadId = value;
                RaisePropertyChanged(() => UnidadId);
                NombreUnidad = LstUnidades.Where(x => x.Id == UnidadId).SingleOrDefault().Abreviatura;
            }
        }
        public Nullable<double> CostoUnitario
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
        public Nullable<double> CostoTotal
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
        public long GrupoUnidadesId
        {
            get
            {
                return _GrupoUnidadesId;
            }

            set
            {
                _GrupoUnidadesId = value;
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
                _LstUnidades = value;
                RaisePropertyChanged(() => LstUnidades);
            }
        }

        public long ComponenteHijoId
        {
            get
            {
                return _ComponenteHijoId;
            }

            set
            {
                _ComponenteHijoId = value;
                RaisePropertyChanged(() => ComponenteHijoId);
                CargarDatosComponente(ComponenteHijoId);
            }
        }

        public string NombreComponente
        {
            get
            {
                return _NombreComponente;
            }

            set
            {
                _NombreComponente = value;
                RaisePropertyChanged(() => NombreComponente);

            }
        }

        public string NombreUnidad
        {
            get
            {
                return _NombreUnidad;
            }

            set
            {
                _NombreUnidad = value;
                RaisePropertyChanged(() => NombreUnidad);
            }
        }

        public void CargarDatosComponente(long idComponente)
        {
            try
            {
                ServicioWS Ws = new ServicioWS("ServiciosERP/Inventarios/WSComponentes.svc", "get", idComponente, typeof(Componentes), "id");
                var Componente = (Componentes)Ws.Peticion();
                Clave = Componente.Clave;
                NombreComponente = Componente.Nombre;
                GrupoUnidadesId = Componente.GrupoUnidadesId ?? 0;
                CostoUnitario = Componente.Costo;
               var LstUnidadesFormula = new System.Collections.ObjectModel.ObservableCollection<Unidades>();  
                ServicioWS Ws2 = new ServicioWS("ServiciosERP/Generales/WSUnidades.svc", "getUnidadesXGrupo", GrupoUnidadesId, typeof(System.Collections.ObjectModel.ObservableCollection<Unidades>), "id");
                LstUnidades = (System.Collections.ObjectModel.ObservableCollection<Unidades>)Ws2.Peticion();
              //  UnidadId = Componente.UnidadInventarioId ?? 0;
                
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

    }

    public class EquivalenciasPartesTemp : ViewModelBase
    {
        //Clase temporal para el manejo del grid de codigos de barras

        private long _Id;
        private long _ComponenteId;
        private long _MarcaId;
        private string _Modelo;
        private string _NoParte;
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

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

        public long MarcaId
        {
            get
            {
                return _MarcaId;
            }

            set
            {
                _MarcaId = value;
                RaisePropertyChanged(() => MarcaId);
            }
        }

        public string Modelo
        {
            get
            {
                return _Modelo;
            }

            set
            {
                _Modelo = value;
                RaisePropertyChanged(() => Modelo);
            }
        }

        public string NoParte
        {
            get
            {
                return _NoParte;
            }

            set
            {
                _NoParte = value;
                RaisePropertyChanged(() => NoParte);
            }
        }

    }
    public class ImpuestosTemp : ViewModelBase
    {
        //Clase temporal para el manejo del grid de almacenes
        private long _Id;
        private long _ComponenteId;
        private long _ImpuestoId;
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

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

        public long ImpuestoId
        {
            get
            {
                return _ImpuestoId;
            }

            set
            {
                _ImpuestoId = value;
                RaisePropertyChanged(() => ImpuestoId);
            }
        }
    }

}

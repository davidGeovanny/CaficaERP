using CaficaERP.Model.Inventarios;
using CaficaERP.Model.Reportes;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Windows;

namespace CaficaERP.ViewModel.Inventarios
{
    [POCOViewModel]
    public class ResguardosFormViewModel : FormularioViewModel<Resguardos>
    {
        public virtual Almacenes AlmacenSeleccionado { get; set; }
        public virtual ResguardosDetalles DetalleComponenteSeleccionado { get; set; }
        public virtual ResguardosDetalles DetalleActual { get; set; }
        public virtual ResguardosLotesSeries SubDetalleSeleccinado { get; set; }
        public virtual ResguardosLotesSeries SubDetalleActual { get; set; }
        public virtual bool CampoComponenteNuevo { get; set; }
        public virtual bool CampoComponenteEditar { get; set; }
        public virtual string AgregarNuevo { get; set; }
        public virtual bool SoloLectura { get; set; }
        public virtual string CodigodeBarra { get; set; }

        public virtual System.Collections.ObjectModel.ObservableCollection<Componentes> LstComponentesSobrantes { get; set; }

        public IMasterDetailService MasterDetailService { get { return GetService<IMasterDetailService>(); } }

        public ResguardosFormViewModel(object view, Resguardos item, string conexion) : base(view, item, conexion)
        {
            //Editar
            IconCancelar = true;
            IconTicket = true;
        }


        public override void ImprimirTicket()
        {
            try
            {
                /*reportParameter parametro = new reportParameter();
                parametro.name = "Id";
                parametro.value.Add(Item.Id.ToString());

               
                VisorReporteViewModel VmReporte = new VisorReporteViewModel("/ERP/Inventarios/Resguardos/ResguardoTicket", parametro, true);
                */
                CrearTicket ticket = new CrearTicket();

                //Datos de la cabecera del Ticket.

                ticket.TextoCentro(VariablesGlobales.RazoSocialEmpresa);
                ticket.TextoCentro("Resguardo");
                ticket.TextoCentro(DateTime.Now.ToString());
                ticket.TextoCentro("CAFICA ERP");
                ticket.TextoIzquierda("");

                ticket.TextoExtremos("Folio: "+ Item.Id, "Fecha: "+ Item.Fecha.ToShortDateString());
                var Responsable = LstResponsables.Where(l => l.Id == Item.ResponsableId).Single();
                ticket.TextoIzquierda("Responsable: " + Responsable.NombreCompleto); 
                ticket.TextoIzquierda("Almacen: "+AlmacenSeleccionado.Nombre);
                ticket.TextoIzquierda("Descripcion:" + Item.Descripcion);             
                if(Item.Cancelado=="SI")
                {
                    ticket.TextoIzquierda("Estado:CANCELADO");
                }
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("");

                ///Detalle del ticket
                ticket.lineasIgual();
                ticket.Encabezado("RESGUARDO");
                ticket.lineasIgual();

                foreach (ResguardosDetalles rd in Item.ResguardosDetalles)
                {
                    
                    var unidad = LstUnidades.Where(x => x.Id == rd.Componentes.UnidadInventarioId).Single();
                    ticket.AgregaComponente(rd.Componentes.NombreCorto, unidad.Abreviatura, rd.Cantidad);
                  
                    foreach(ResguardosLotesSeries rs in rd.ResguardosLotesSeries)
                    {
                        ticket.TextoIzquierda("   Serie:" + rs.LotesSeries.SerieLote);
                    }
                }

              
                //Final del ticket
                ticket.TextoIzquierda("");
                ticket.TextoCentro("RESPONSABLE");
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("");
                ticket.TextoCentro("____________________________");
                ticket.TextoCentro(Responsable.NombreCompleto);
                ticket.CortaTicket();


                PrintDocument printDoc = new PrintDocument();
                int i;
                string pkInstalledPrinters;
                String impresora = "";
                for (i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                {
                    pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                  
                    if (printDoc.PrinterSettings.IsDefaultPrinter)
                    {
                       impresora = printDoc.PrinterSettings.PrinterName;
                    }
                }



               ticket.ImprimirTicket(impresora);//Nombre de la impresora ticketera



            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                   MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
            

        }


        public ResguardosFormViewModel(object view) : base(view)
        {
            //Nuevo
            CampoComponenteNuevo = true;
            CampoComponenteEditar = false;
            AgregarNuevo = "Bottom";
            SoloLectura = false;
            CamposEnabled = true;

            //IconCancelar = true;

            CargarAlmacenesResguardos();                        
            CargarUnidades();
            CargarResponsables();

            AlmacenSeleccionado = new Almacenes();
            DetalleComponenteSeleccionado = new ResguardosDetalles();
            DetalleActual = new ResguardosDetalles();
            SubDetalleSeleccinado = new ResguardosLotesSeries();
            SubDetalleActual = new ResguardosLotesSeries();

            Item.TipoDocumento = "RESGUARDO";
            Item.Fecha = DateTime.Now;
            this.RaisePropertyChanged(x => x.Item);         
        }
        public override void CargarItem()
        {
            try
            {
                //Editar
                CampoComponenteNuevo = false;
                CampoComponenteEditar = true;
                AgregarNuevo = "None";
                SoloLectura = true;
                CamposEnabled = false;

                Item.CanValidate = true;

                base.CargarItem();
                Item.Errores();

                CargarAlmacenesResguardos();
                CargarUnidades();
                CargarResponsables();

                AlmacenSeleccionado = new Almacenes();
                DetalleComponenteSeleccionado = new ResguardosDetalles();
                DetalleActual = new ResguardosDetalles();
                SubDetalleSeleccinado = new ResguardosLotesSeries();
                SubDetalleActual = new ResguardosLotesSeries();

                AlmacenSeleccionado = LstAlmacenesResguardo.Where(id => id.Id == Item.AlmacenId).Single();
                CargarComponentesAlmacenConExistencia(AlmacenSeleccionado.Id);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public override void GuardarItem()
        {
            try
            {
                if (Item.Id != 0)
                    return;

                Item.CanValidate = true;
                string errores = Item.Errores();
                if (!string.IsNullOrEmpty(errores))
                    throw new Exception(errores);

                base.GuardarItem();
                if (this.guardar_si_no == MessageBoxResult.Yes)
                {
                    ItemBuscar = Item;
                    CargarItem();
                 //   ImprimirTicket();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void CargarComponentes()
        {
            try
            {
                //Los resguardos no son modificables solo se pueden cancelar
                if (AlmacenSeleccionado != null && Item.Id == 0)
                {
                    Item.ResguardosDetalles.Clear();
                    this.RaisePropertyChanged(x => x.Item);
                    if(Item.Id==0)
                    { 
                        CargarComponentesAlmacenConExistenciaeImagen(AlmacenSeleccionado.Id);
                    }
                    else
                    { 
                        CargarComponentesAlmacenConExistencia(AlmacenSeleccionado.Id);
                    }
                }
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void ValidarComponente(CellValue celda)
        {
            try
            {
                ResguardosDetalles celdaactual = (ResguardosDetalles)celda.Row;
                celdaactual.CanValidate = true;

                ExpandirGrupo(celdaactual);
                if (celda.Property == "Componentes")
                {
                    //Se creo un objeto de tipo invnetario para no tener que hacer otro web servicie
                    InventariosESDetalles cf = new InventariosESDetalles();
                    cf.ComponenteId = celdaactual.Componentes.Id;
                    cf.AlmacenId = Item.AlmacenId;

                    ServicioWS Ws1 = new ServicioWS("ServiciosERP/Inventarios/WSESInventarios.svc", "getSerielotexcomponente",cf, typeof(System.Collections.ObjectModel.ObservableCollection<LotesSeries>), "inventarioentradaosalida");
                    celdaactual.LstLotesSeries = (System.Collections.ObjectModel.ObservableCollection<LotesSeries>)Ws1.Peticion();
                    this.RaisePropertyChanged(x => x.Item);
                }
                if (celda.Property == "Cantidad")
                {
                    /*CmbAlmacenActivo = false;
                    CmbAlmacenOpacity = "0.7";
                    BtnCargarComponentesActivo = false;*/
                    if (celdaactual.Componentes.TipoSeguimiento == "NÚMERO DE SERIE")
                    {
                       if (celdaactual.Errores() != null)
                            return;

                        //Calculo el numero de hijos actuales
                        int totalHijos = celdaactual.ResguardosLotesSeries.Count;
                        for (int total = 1; total <= celdaactual.Cantidad - totalHijos; total++)
                        {
                            celdaactual.ResguardosLotesSeries.Add(new ResguardosLotesSeries
                            {
                                CanValidate = true,
                                Detalle=celdaactual,
                                ResguardosDetalleId = celdaactual.Id,
                                LstLotesSeries=celdaactual.LstLotesSeries,
                                LotesSeries = new LotesSeries { Componentes = celdaactual.Componentes, ComponenteId = celdaactual.ComponenteId, NumeroSerie="" }
                            });
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
               MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void EliminaFila(ResguardosLotesSeries detalle)
        {
            try
            {
               if(DetalleActual != null && Item.Id==0)
               {
                    Item.ResguardosDetalles.Remove(DetalleActual);
               }
               else if (SubDetalleActual != null && Item.Id == 0)
               {
                    detalle.Detalle.Cantidad -= 1;
                    detalle.Detalle.ResguardosLotesSeries.Remove(detalle);
                }
                this.RaisePropertyChanged(x => x.Item);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void ExpandirGrupo(object row)
        {
            try
            {
                if (row == null)
                    return;

                ResguardosDetalles celdaactual = (ResguardosDetalles)row;
                //Solo expaden para los tipo Numero de serie y  Lote
                if (celdaactual.Componentes.TipoSeguimiento != "NORMAL")
                {
                    //Expande la fila seleccionada
                    MasterDetailService.ExpandMasterRow(row);
                }
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
        public void CodigodeBarras()
        {
            try
            {
                if (CodigodeBarra == "" || CodigodeBarra == null || LstComponentes == null || LstComponentes.Count == 0)
                    return;

                ServicioWS Ws1 = new ServicioWS("ServiciosERP/Inventarios/WSComponentes.svc", "getComponenteCodigodeBarra", CodigodeBarra, typeof(ComponentesCodigosBarras), "codigo");
                ComponentesCodigosBarras Cmp_Barra = (ComponentesCodigosBarras)Ws1.Peticion();

                if (Cmp_Barra == null)
                    throw new Exception("El componente no se encuentra registrado");

                Componentes Cmp = LstComponentes.Where(c => c.Id == Cmp_Barra.ComponenteId && c.UnidadInventarioId == Cmp_Barra.UnidadId).SingleOrDefault();

                if (Cmp == null)
                    throw new Exception("El componente no se encuentra registrado");

                ResguardosDetalles detalle = new ResguardosDetalles();
                detalle = Item.ResguardosDetalles.Where(c => c.ComponenteId == Cmp_Barra.ComponenteId).SingleOrDefault();

                if (detalle == null)
                {
                    ResguardosDetalles detalle_componente = new ResguardosDetalles();
                    /*detalle_componente.Componentes.Clave = Cmp.Clave;
                    detalle_componente.Componentes = Cmp;
                    detalle_componente.Componentes.TipoSeguimiento = Cmp.TipoSeguimiento;*/
                    detalle_componente.ComponenteId = Cmp.Id;
                    detalle_componente.Componentes = Cmp;
                     //detalle_componente.UnidadBaseId = LstUnidades.Where(c=> c.Id == Cmp.UnidadInventarioId).Single().Nombre;

                     Item.ResguardosDetalles.Add(detalle_componente);
                    DetalleActual = detalle_componente;

                    CellValue celda = new CellValue(detalle_componente, "Componentes", detalle_componente.ComponenteId);
                    ValidarComponente(celda);

                    CellValue celda2 = new CellValue(detalle_componente, "Cantidad", detalle_componente.Cantidad++);
                    ValidarComponente(celda2);
                }
                else
                {
                    DetalleActual = detalle;
                    detalle.Cantidad = detalle.Cantidad + 1;

                    CellValue celda = new CellValue(detalle, "Cantidad", detalle.Cantidad);
                    ValidarComponente(celda);
                }

                CodigodeBarra = "";
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error");
            }
        }
        public override void Limpiar()
        {
            Item = null;
            base.Limpiar();

            
            AlmacenSeleccionado = null;
            CampoComponenteNuevo = true;
            CampoComponenteEditar = false;
            AgregarNuevo = "Bottom";
            SoloLectura = false;
            CamposEnabled = true;
            CargarAlmacenesResguardos();
            CargarUnidades();
            CargarResponsables();

            AlmacenSeleccionado = new Almacenes();
            DetalleComponenteSeleccionado = new ResguardosDetalles();
            DetalleActual = new ResguardosDetalles();
            SubDetalleSeleccinado = new ResguardosLotesSeries();
            SubDetalleActual = new ResguardosLotesSeries();
           
           
            Item.TipoDocumento = "RESGUARDO";
            Item.Fecha = DateTime.Now;
         //   this.RaisePropertyChanged(x => x.Item);


        }
    }
}

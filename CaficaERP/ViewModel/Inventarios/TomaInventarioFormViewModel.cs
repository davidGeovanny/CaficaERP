using CaficaERP.Model.Inventarios;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Linq;
using System.Windows;

namespace CaficaERP.ViewModel.Inventarios
{
    [POCOViewModel]
    public class TomaInventarioFormViewModel : FormularioViewModel<InventariosFisicos>
    {
        public virtual Almacenes AlmacenSeleccionado { get; set; }
        public virtual Responsables ResponsableSeleccionado { get; set; }
        public virtual InventariosFisicosDetalles DetalleComponenteSeleccionado { get; set; }
        public virtual InventariosFisicosDetalles DetalleActual { get; set; }
        public virtual InventariosFisicosLotesSeries SubDetalleSeleccinado { get; set; }
        public virtual InventariosFisicosLotesSeries SubDetalleActual { get; set; }
        public virtual bool CmbAlmacenActivo { get; set; }
        public virtual string CmbAlmacenOpacity { get; set; }
        public virtual bool BtnCargarComponentesActivo { get; set; }
        public virtual bool SoloLectura { get; set; }

        public IMasterDetailService MasterDetailService { get { return GetService<IMasterDetailService>(); } }
   
        public TomaInventarioFormViewModel(object view, InventariosFisicos item, string conexion) : base(view,item, conexion)
        {
            IconCancelar = true;
           // this.RaisePropertyChanged(x => x.Item);
        }
        public TomaInventarioFormViewModel(object view) : base(view)
        {
            IconCancelar = true;
            Item.CanValidate = true;

            CargarAlmacenes();   //Lista de almacenes, para llenar el combo almacenes, el metodo esta en el formulariobase  //LLENACOMBO                        
            CargarUnidades();

            AlmacenSeleccionado = new Almacenes();
            ResponsableSeleccionado = new Responsables();
            DetalleComponenteSeleccionado = new InventariosFisicosDetalles();
            DetalleActual = new InventariosFisicosDetalles();
            SubDetalleSeleccinado = new InventariosFisicosLotesSeries();
            SubDetalleActual = new InventariosFisicosLotesSeries();

            Item.Fecha = DateTime.Now;
            this.RaisePropertyChanged(x => x.Item);
            SoloLectura = false;

            CmbAlmacenActivo = true;
            CmbAlmacenOpacity = "1";
            BtnCargarComponentesActivo = true;
        }
        public override void GuardarItem()
        {
            try
            {
                string errores = Item.Errores();
                if (!string.IsNullOrEmpty(errores))
                    throw new Exception(errores);

                base.GuardarItem();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public override void CargarItem()
        {
            try
            {
                Item.CanValidate = true;

                base.CargarItem();
                Item.Errores();

                CargarAlmacenes();
                CargarUnidades();

                AlmacenSeleccionado = new Almacenes();
                DetalleComponenteSeleccionado = new InventariosFisicosDetalles();
                DetalleActual = new InventariosFisicosDetalles();
                SubDetalleSeleccinado = new InventariosFisicosLotesSeries();
                SubDetalleActual = new InventariosFisicosLotesSeries();

                SoloLectura = false;
                CmbAlmacenActivo = false;
                BtnCargarComponentesActivo = false;
                CmbAlmacenOpacity = "0.7";

                AlmacenSeleccionado = LstAlmacenes.Where(id => id.Id == Item.AlmacenId).Single();
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void EliminaFila(InventariosFisicosLotesSeries detalle)
        {
            try
            {
                if (detalle == null) return;

                if (detalle.Seguimiento == "Serie:")
                {
                    //Acutalizar la existencia
                    detalle.Detalle.ExistenciaFisica-=1;
                    //SubDetalleSeleccinado.Detalle.ExistenciaFisica -= 1;
                }
                else if (detalle.Seguimiento == "Lote:")
                {
                    //Siempre tiene que haber por lo menos un hijo
                    if(detalle.Detalle.InventariosFisicosLotesSeries.Count() == 1)
                        return;

                    //Buscas alguna fila que tenga valor cero para no agregar otra
                    if (detalle.Detalle.InventariosFisicosLotesSeries.Where(v => v.Cantidad == 0).Count() == 0)
                    {
                        detalle.Detalle.InventariosFisicosLotesSeries.Add(new InventariosFisicosLotesSeries
                        {
                            Cantidad = 0,
                            Detalle = detalle.Detalle,
                            CanValidate = true,
                            InventariosFisicosDetalleId=detalle.InventariosFisicosDetalleId,
                            LotesSeries = new LotesSeries{ Componentes = detalle.Detalle.Componentes,ComponenteId=detalle.Detalle.ComponenteId }
                        });
                    }
                }
                detalle.Detalle.InventariosFisicosLotesSeries.Remove(detalle);
                //RaisePropertyChanged(() => Item);
                this.RaisePropertyChanged(x => x.Item);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
               MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void ValidarComponenteSerieLote(CellValue celda)
        {
            try
            {
                /*MessageBox.Show("acutaliza");
                return;*/

                InventariosFisicosLotesSeries celdaactual = (InventariosFisicosLotesSeries)celda.Row;

                if (celda.Property == "Cantidad" || celda.Property == "LotesSeries.FechaCaducidad")
                {
                    if (celdaactual.Seguimiento == "Lote:")
                    {
                        if (celdaactual.Errores() != null)
                            return;

                        if (celdaactual.Detalle.InventariosFisicosLotesSeries.Sum(v => v.Cantidad) < celdaactual.Detalle.ExistenciaFisica)
                        {
                            //Buscas alguna fila que tenga valor cero para no agregar otra
                            if (celdaactual.Detalle.InventariosFisicosLotesSeries.Where(v => v.Cantidad == 0).Count() == 0)
                            {
                                celdaactual.Detalle.InventariosFisicosLotesSeries.Add(new InventariosFisicosLotesSeries
                                {
                                    Cantidad = 0,
                                    Detalle = celdaactual.Detalle,
                                    InventariosFisicosDetalleId = celdaactual.InventariosFisicosDetalleId,
                                    CanValidate = true,
                                    LotesSeries = new LotesSeries { Componentes = celdaactual.Detalle.Componentes,ComponenteId=celdaactual.Detalle.ComponenteId }
                                    //LotesSeries = new LotesSeriesModel{ FechaCaducidad= DateTime.Now}
                                });
                            }
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
        public void ValidarComponente(CellValue celda)
        {
            try
            {

                InventariosFisicosDetalles celdaactual = (InventariosFisicosDetalles)celda.Row;
                ExpandirGrupo(celdaactual);

                if (celda.Property == "ExistenciaFisica")
                {
                    

                    CmbAlmacenActivo = false;
                    CmbAlmacenOpacity = "0.7";
                    BtnCargarComponentesActivo = false;
                    if (celdaactual.Componentes.TipoSeguimiento == "NÚMERO DE SERIE")
                    {
                        if(celdaactual.Errores() != null)
                            return;

                        //Calculo el numero de hijos actuales
                        int totalHijos = celdaactual.InventariosFisicosLotesSeries.Count;
                        for (int total = 1; total <= celdaactual.ExistenciaFisica - totalHijos; total++)
                        {
                            celdaactual.InventariosFisicosLotesSeries.Add(new InventariosFisicosLotesSeries {
                                Cantidad = 1,
                                //Seguimiento = "Serie:",
                                CanValidate=true,
                                InventariosFisicosDetalleId =celdaactual.Id,
                                Detalle = celdaactual,
                                LotesSeries = new LotesSeries { Componentes = celdaactual.Componentes,ComponenteId=celdaactual.ComponenteId }
                            });
                        }

                    }
                    else if (celdaactual.Componentes.TipoSeguimiento == "LOTES" && celdaactual.ExistenciaFisica != 0)
                    {
                        if (celdaactual.Errores() != null)
                            return;
       
                        if (celdaactual.InventariosFisicosLotesSeries.Sum(v => v.Cantidad) < celdaactual.ExistenciaFisica)
                        {
                            //Buscas alguna fila que tenga valor cero para no agregar otra
                            if (celdaactual.InventariosFisicosLotesSeries.Where(v => v.Cantidad==0).Count()==0)
                            {
                                celdaactual.InventariosFisicosLotesSeries.Add(new InventariosFisicosLotesSeries
                                {
                                    Cantidad = 0,
                                    Detalle=celdaactual,
                                    CanValidate = true,
                                    InventariosFisicosDetalleId=celdaactual.Id,
                                    LotesSeries = new LotesSeries { Componentes = celdaactual.Componentes,ComponenteId=celdaactual.ComponenteId }
                                    //LotesSeries = new LotesSeriesModel{ FechaCaducidad= DateTime.Now}
                                });
                            }
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
        public void CargarComponentes()
        {
            try
            {
                if (AlmacenSeleccionado != null)
                {
                    CargarComponentesAlmacen(AlmacenSeleccionado.Id);
                    Item.InventariosFisicosDetalles.Clear();
                    foreach (Componentes componente in LstComponentes)
                    {
                        //LstDetallesComponentes.Add(new InventariosFisicosDetallesModel
                        Item.InventariosFisicosDetalles.Add(new InventariosFisicosDetalles
                        {
                            ExistenciaFisica = 0,
                            CanValidate=true,
                            ComponenteId=componente.Id,
                            Componentes = new Componentes {
                                Id = componente.Id,
                                Clave = componente.Clave,
                                Nombre = componente.Nombre,
                                TipoSeguimiento = componente.TipoSeguimiento,
                                UnidadInventarioId=componente.UnidadInventarioId
                            }
                        });
                    }
                }
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

                InventariosFisicosDetalles celdaactual = (InventariosFisicosDetalles)row;
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
        public override void Limpiar()
        {
            base.Limpiar();
            Item.Fecha = DateTime.Now;
            this.RaisePropertyChanged(x => x.Item);
            AlmacenSeleccionado = null;
            Item.InventariosFisicosDetalles.Clear();
            CmbAlmacenActivo = true;
            CmbAlmacenOpacity = "1";
            BtnCargarComponentesActivo = true;
        }
    }
}
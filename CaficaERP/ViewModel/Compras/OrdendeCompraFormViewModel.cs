using CaficaERP.Model.Compras;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.POCO;
using System.Windows;
using DevExpress.Xpf.Core;
using DevExpress.Mvvm;
using CaficaERP.Model.Inventarios;
using System.Collections.ObjectModel;
using CaficaERP.Model.Generales;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Editors;
using System.Windows.Input;

namespace CaficaERP.ViewModel.Compras
{
    [POCOViewModel]
    public class OrdendeCompraFormViewModel : FormularioViewModel<ComprasDocs>
    {
        public virtual ComprasDocsDetalles DetalleActual { get; set; }

        public virtual Almacenes AlmacenSeleccionado { get; set; }
        public virtual bool CampoComponenteNuevo { get; set; }
        public virtual bool CampoComponenteEditar { get; set; }

       
        ComprasDocsImpuestos comprasimpuestos = new ComprasDocsImpuestos();
        Impuestos impuestos = new Impuestos();
        public IMasterDetailService MasterDetailService { get { return GetService<IMasterDetailService>(); } }


        public OrdendeCompraFormViewModel(object view, ComprasDocs item, string conexion) : base(view, item, conexion)
        {
            

        }

        public OrdendeCompraFormViewModel(object view) : base(view)
          
        {
            CargarProveedoresActivos();
            CargarAlmacenes();
            CargarMonedas();
            CargarUnidades();
            CampoComponenteNuevo = true;
            CampoComponenteEditar = false;
            Item.TipoDocumento = "ORDEN";
            Item.Estado = "CAPTURADA";
            Item.FechaDocumento = DateTime.Now;
         //   LstMonedas = new ObservableCollection<MonedasModel>(LstMonedas.Where(a => a.Predeterminado == "SI"));
            Item.MonedaId = new ObservableCollection<Monedas>(LstMonedas.Where(a => a.Predeterminado == "SI")).ToList().SingleOrDefault().Id;
            DetalleActual = new ComprasDocsDetalles();
          
            this.RaisePropertyChanged(x => x.Item);
        }
        public override void GuardarItem()
        {
        //    Item.CanValidate = true;
     //       string errores = Item.Errores();
      //      if (!string.IsNullOrEmpty(errores))
       //         throw new Exception(errores);
        //    Item.CanValidate = true;
            base.GuardarItem();
        }
        public void CargarComponentes()
        {
            try
            {
               if (AlmacenSeleccionado != null)
                {
                    /* guardar_si_no = DXMessageBox.Show(this.OwnerVista, "¿Se borraran los detalles, desea continuar?", "Confirmación", MessageBoxButton.YesNo,
                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);*/
             //       guardar_si_no = DXMessageBox.Show(this.OwnerVista, "¿Se borraran los detalles, desea continuar?", "Error", MessageBoxButton.YesNo);
                  //  if (guardar_si_no == MessageBoxResult.Yes)
                      //  LstInventariosESDetallesTemp.Clear();
                }
                //requiero el tipo componente Id
                // LstInventariosESDetallesTemp.Clear();
                //   if (AlmacenSeleccionado == null) return;
                // if (Item.Id == 0)
                CargarComponentesAlmacenConImagenImpuestos(AlmacenSeleccionado.Id);
            //    else
             //       CargarComponentesAlmacen(AlmacenSeleccionado.Id);
                //     DetalleActual.AlmacenId = AlmacenSeleccionado.Id;
              
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


       if (celda != null)
          {


                    ComprasDocsDetalles celdaactual = (ComprasDocsDetalles)celda.Row;
                    
                    if (celda.Property == "Componentes")
                    {
                      
                        celdaactual.Componentes = LstComponentes.Where(x => x.Id == celdaactual.Componentes.Id).SingleOrDefault();
                        celdaactual.UnidadId = celdaactual.Componentes.UnidadCompraId ?? 0;
                        celdaactual.ComponenteId = celdaactual.Componentes.Id;
                        celdaactual.GrupoUnidadesId = celdaactual.Componentes.GrupoUnidadesId;
                        celdaactual.Cantidad = 0;
                        celdaactual.PrecioUnitario = 0.00;
                        celdaactual.Importe = null;
                        celdaactual.LstUnidades = null;
                        celdaactual.DescuentoPorcentaje = null;

                        celdaactual.CanValidate = true;
                        ///////////////Llenas objeto comprasdocsimpuesto///////
                       
                        if(celdaactual.Validar("Componentes") == null)
                            
                        comprasimpuestos.ImpuestoId = celdaactual.Componentes.ComponentesImpuestos.FirstOrDefault().ImpuestoId;
                        comprasimpuestos.Porcentaje = (double)celdaactual.Componentes.ComponentesImpuestos.FirstOrDefault().Impuestos.Porcentaje;
                        
                        ServicioWS Ws2 = new ServicioWS("ServiciosERP/Generales/WSUnidades.svc", "getUnidadesXGrupo", DetalleActual.Componentes.GrupoUnidadesId, typeof(ObservableCollection<Unidades>), "id");
                        celdaactual.LstUnidades = (ObservableCollection<Unidades>)Ws2.Peticion();


                        
                        this.RaisePropertyChanged(x => x.Item);
                       
                            
                    }
                    if (celda.Property == "CantidadCompra")
                    {
                        celdaactual.CanValidate = true;
                    }

                    if (celda.Property == "UnidadCompraId")
                    {
                        celdaactual.CanValidate = true;
                        celdaactual.UnidadId = celdaactual.Componentes.UnidadInventarioId;
                    }
                    if (celda.Property == "PrecioUnitario")
                    {
                        celdaactual.CanValidate = true;
                        celdaactual.Importe = celdaactual.PrecioUnitario * celdaactual.CantidadCompra;

                        ///////////////Llenas objeto comprasdocsimpuesto///////
                      //  impuestos.SubtotalCompra = (double)celdaactual.Importe;

                        this.RaisePropertyChanged(x => x.Item);
                    }
                    if (celda.Property == "DescuentoPorcentaje")
                    {
                       
                        celdaactual.CanValidate = true;
                        celdaactual.Importe = celdaactual.Importe - ((celdaactual.DescuentoPorcentaje/100)*celdaactual.Importe);
                        this.RaisePropertyChanged(x => x.Item);
                    }
                    if (celda.Property == "nombrecomponente")
                    {

                        
                        this.RaisePropertyChanged(x => x.Item);
                    }


                }

         }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
               MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        /*public void BusquedaLike(object sender)
        {

        }*/
        public void BusquedaLike()
        {

        }
        /*public void BusquedaLike(object sender,object evento)
        {

        }*/

       

    }
}

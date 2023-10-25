using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.POCO;
using System.Windows;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Core;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Grid;

namespace CaficaERP.ViewModel.Generales
{
    [POCOViewModel]
    public class ImpuestosFormViewModel : FormularioViewModel<Impuestos>
    {

     
        public virtual ImpuestosGravados DetalleSeleccionado { get; set; }
        public virtual ImpuestosGravados DetalleActual { get; set; }

        public virtual bool PorcentajeEnabled { get; set; }
        public virtual bool CuotaEnabled { get; set; }
        public virtual object TipoCalculoSeleccionado { get; set; }




        public ImpuestosFormViewModel(object view, Impuestos item, string conexion) : base(view, item, conexion)
        {
            //Editar
            
        }

        public ImpuestosFormViewModel(object view) : base(view)
        {
            //Nuevo
            CamposEnabled = true;
            PorcentajeEnabled = false;
            CuotaEnabled = false;
            //IconCancelar = true;

            CargarSiNo();
            CargarUnidades();
            CargarNaturalezaImpuestos();
            CargarTipoCalculo();
            CargarTiposImpuestos();
            CargarImpuestos();

            DetalleSeleccionado = new ImpuestosGravados();
            DetalleActual = new ImpuestosGravados();
         
            this.RaisePropertyChanged(x => x.Item);
        }

        public override void GuardarItem()
        {
            try
            {
                Item.CanValidate = true;
                string errores = Item.Errores();
                if (!string.IsNullOrEmpty(errores))
                    throw new Exception(errores);

                base.GuardarItem();
                if (this.guardar_si_no == MessageBoxResult.Yes)
                {
                    ItemBuscar = Item;
                    CargarItem();
                 
                }
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
                //Editar

                CamposEnabled = true;

                Item.CanValidate = true;

                base.CargarItem();
                Item.Errores();

                CargarSiNo();
                CargarUnidades();
                CargarNaturalezaImpuestos();
                CargarTipoCalculo();
                CargarTiposImpuestos();
                CargarImpuestos();

                DetalleSeleccionado = new ImpuestosGravados();
                DetalleActual = new ImpuestosGravados();
              

               
             
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }

        public void HabilitarCampos()
        {
            if (TipoCalculoSeleccionado != null)
            {
                if (TipoCalculoSeleccionado.GetType().GetProperty("nombre").GetValue(TipoCalculoSeleccionado).ToString() == "PORCENTAJE")
                {
                    PorcentajeEnabled = true;
                    CuotaEnabled = false;
                }
                else if(TipoCalculoSeleccionado.GetType().GetProperty("nombre").GetValue(TipoCalculoSeleccionado).ToString() == "UNIDAD")
                {
                    PorcentajeEnabled = false;
                    CuotaEnabled = true;
                }
                else
                {
                    PorcentajeEnabled = false;
                    CuotaEnabled = false;
                }
            }
        }

        public void ValorCeldaCambio(CellValue celda)
        {
            if(celda!=null)
            {
                ImpuestosGravados celdaactual = (ImpuestosGravados)celda.Row;
                celdaactual.CanValidate = true;
                celdaactual.ImpuestoActual = Item;

                if(Item.Id!=0)
                {
                    foreach(ImpuestosGravados i in Item.ImpuestosGravados1.Where(x=>x.ImpuestoId==0).ToList())
                    {
                        i.ImpuestoId = Item.Id;
                    }
                }

                 if (Item.Errores() != null)
                   return;
            }
        }

        public void EliminaFila(Impuestos detalle)
        {
            try
            {
                if (DetalleActual != null)
                {
                    Item.ImpuestosGravados1.Remove(DetalleActual);
                }
               
                this.RaisePropertyChanged(x => x.Item);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }

    }
}

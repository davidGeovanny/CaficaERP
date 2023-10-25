using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;
using System.Windows;
using DevExpress.Xpf.Core;
using DevExpress.Mvvm;

namespace CaficaERP.ViewModel.Generales
{
    [POCOViewModel]
    public class CondicionesdePagoFormViewModel : FormularioViewModel<CondicionesPago>
    {
        public virtual double NumerodePagos { get; set; }
        public virtual int DiasdePagos { get; set; }
        public virtual double Enganche { get; set; }

        public CondicionesdePagoFormViewModel(object view, CondicionesPago item, string conexion) : base(view, item, conexion)
        {
            //Editar

        }

        public CondicionesdePagoFormViewModel(object view) : base(view)
          
        {
            CargarSiNo();
            this.RaisePropertyChanged(x => x.Item);
        }

        public override void GuardarItem()
        {
            try
            {
             Item.CanValidate = true;
                CondicionesPagoPlazos plazos=new CondicionesPagoPlazos();
                plazos.CanValidate = true;
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
                CargarSiNo();
                base.CargarItem();
                Item.Errores();

            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }



        public void EliminaFila(CondicionesPago detalle)
        {

        }
        public void Contado()
        {
            try
            {
                CondicionesPagoPlazos plazos;

                 if (Item.CondicionesPagoPlazos.Count() >= 1)
                     { 
                        guardar_si_no = DXMessageBox.Show(this.OwnerVista, "¿La condicion de pago ya contiene plazos, ¿desea continuar?", "Alerta", MessageBoxButton.YesNo);
                        if (guardar_si_no == MessageBoxResult.Yes)
                        {
                            Item.CondicionesPagoPlazos.Clear();
                            plazos = new CondicionesPagoPlazos { Dias = 0, Porcentaje = 100 };
                            Item.CondicionesPagoPlazos.Add(plazos);
                        }
                }

                else
                {
                    plazos = new CondicionesPagoPlazos { Dias = 0, Porcentaje = 100 };
                    Item.CondicionesPagoPlazos.Add(plazos);
                }

            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                      MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }
        public void Credito()
        {
            try
            {
                CondicionesPagoPlazos plazos;
                int calculodias =DiasdePagos;
                double numerodepagos=NumerodePagos;
                double porcentaje;
                double sumaporcentaje=0;
                double calculoporcentaje = 0;

                    porcentaje = Math.Round(((100f - Enganche) / (NumerodePagos)), 2);
                if (Math.Round(porcentaje * NumerodePagos + Enganche, 2) > 100)
                    throw new Exception("Con estos datos, los dias de algunos plazos resultarian incorrectos ");
                if (Item.CondicionesPagoPlazos.Count() >= 1)
                {
                    guardar_si_no = DXMessageBox.Show(this.OwnerVista, "La condicion de pago ya contiene plazos, ¿desea continuar?", "Alerta", MessageBoxButton.YesNo);
                    if (guardar_si_no == MessageBoxResult.Yes)
                    {
                        Item.CondicionesPagoPlazos.Clear();
                    }
                    else return;
                }
                if (Enganche != 0)
                   { 
                    plazos = new CondicionesPagoPlazos { Dias = 0, Porcentaje = Enganche };
                    Item.CondicionesPagoPlazos.Add(plazos);
                   }

                for (int i=0; i < NumerodePagos; i++)
                    {
                    if (numerodepagos == i + 1)
                    {
                            if (Math.Round(sumaporcentaje, 2)+Enganche+porcentaje != 100)
                            { 
                                calculoporcentaje = Math.Round(100 - Math.Round(sumaporcentaje, 2) - Enganche,2);
                                plazos = new CondicionesPagoPlazos { Dias = calculodias, Porcentaje = calculoporcentaje };
                                Item.CondicionesPagoPlazos.Add(plazos);
                                calculodias += DiasdePagos;
                                sumaporcentaje += Math.Round(calculoporcentaje, 2);
                            }
                            else
                            {
                                plazos = new CondicionesPagoPlazos { Dias = calculodias, Porcentaje = porcentaje };
                                Item.CondicionesPagoPlazos.Add(plazos);
                                calculodias += DiasdePagos;
                                sumaporcentaje += Math.Round(porcentaje, 2);
                            }
                    }
                    else
                    { 
                                 plazos = new CondicionesPagoPlazos { Dias = calculodias, Porcentaje = porcentaje };
                                 Item.CondicionesPagoPlazos.Add(plazos);
                                 calculodias += DiasdePagos;
                                 sumaporcentaje += Math.Round(porcentaje,2);
                    }

                }
                
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                      MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }

        }

        public void ValorCeldaCambio(CellValue celda)
        {
            if (celda != null)
            {
                CondicionesPagoPlazos celdaactual = (CondicionesPagoPlazos)celda.Row;
                celdaactual.CanValidate = true;
                celdaactual.diaactual = Item;

                if (Item.Id != 0)
                {
                    foreach (CondicionesPagoPlazos i in Item.CondicionesPagoPlazos.Where(x => x.CondicionesPagoId == 0).ToList())
                    {
                        i.CondicionesPagoId = Item.Id;
                    }
                }

                if (Item.Errores() != null)
                    return;
            }
        }
    }
}

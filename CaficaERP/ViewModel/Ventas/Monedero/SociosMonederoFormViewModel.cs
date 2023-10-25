using CaficaERP.Model.Ventas.Monedero;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Ventas.Monedero
{
    public class SociosMonederoFormViewModel : FormularioViewModel<SociosMonedero>
    {
       


        public SociosMonederoFormViewModel(SociosMonedero item, string conexion) : base(item, conexion)
        {
          

        }
        public SociosMonederoFormViewModel()
            
        {

            CargarGruposSocios();
        }

        public override void CargarItem()
        {
            try
            {
                //Nuevo


                CamposEnabled = true;

                Item.CanValidate = true;


                base.CargarItem();
                Item.Errores();
                CargarGruposSocios();

            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
    }
}

using CaficaERP.Model.Administracion;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Administracion 
{
    public class BDEmpresaFormViewModel : FormularioViewModel<BDEmpresas>
    {
        

        public BDEmpresaFormViewModel()
        {

            CargarStatus();
            CargarSiNo();
            CargarMetodosCosteo();
        }

        public BDEmpresaFormViewModel(BDEmpresas item, string conexion) : base(item, conexion)
        {

        }

        public override void CargarItem()
        {

            try
            {
                base.CargarItem();
                CargarStatus();
                CargarSiNo();
                CargarMetodosCosteo();
                ReadOnly = "True";
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                            MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
    }
}

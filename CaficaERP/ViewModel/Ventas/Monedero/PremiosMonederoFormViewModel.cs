using CaficaERP.Model.Ventas.Monedero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Core;
using DevExpress.Mvvm.POCO;
using System.Windows;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using CaficaERP.Model.Generales;
using CaficaERP.Model.Inventarios;
using System.ComponentModel;

namespace CaficaERP.ViewModel.Ventas.Monedero
{
    [POCOViewModel]
    public class PremiosMonederoFormViewModel : FormularioViewModel<PremiosMonedero>
    {

        public virtual PremiosMonederoDetalles DetalleActual { get;set; }
        public virtual PremiosMonederoDetalles DetalleSeleccionado { get; set; }
        public virtual byte[] Imagen { get; set; }
        public virtual string ImagenB64 { get; set; }


        public PremiosMonederoFormViewModel(object view, PremiosMonedero item, string conexion) : base(view, item, conexion)
        {

        }

        public PremiosMonederoFormViewModel(object view) : base(view)
        {
            //Nuevo
            CamposEnabled = true;
            CargarComponentesXTipoConImagen(2);
            DetalleActual = new PremiosMonederoDetalles();
           
            this.RaisePropertyChanged(x => x.Item);
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
                CargarComponentesXTipoConImagen(2);

                if(Item.ImagenBase64!=null)
                Imagen = Convert.FromBase64String(Item.ImagenBase64);

                foreach (PremiosMonederoDetalles pd in Item.PremiosMonederoDetalles)
                {

                    ServicioWS Ws2 = new ServicioWS("ServiciosERP/Generales/WSUnidades.svc", "getUnidadesXGrupo", pd.Componentes.GrupoUnidadesId, typeof(System.Collections.ObjectModel.ObservableCollection<Unidades>), "id");
                    pd.LstUnidades = (System.Collections.ObjectModel.ObservableCollection<Unidades>)Ws2.Peticion();
                }

                DetalleActual = new PremiosMonederoDetalles();
               

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

                if (Imagen != null)
                    ImagenB64 = Convert.ToBase64String(Imagen);
                else
                   ImagenB64 = null;


                Item.CanValidate = true;
                Item.ImagenBase64 = ImagenB64;
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


        public void ValorCeldaCambio(CellValue celda)
        {
            if (celda != null)
            {
              

                if (celda.Property == "ComponenteId")
                {
                    PremiosMonederoDetalles celdaactual = (PremiosMonederoDetalles)celda.Row;
                    celdaactual.CanValidate = true;
                    celdaactual.Componentes = LstComponentes.Where(x => x.Id == celdaactual.ComponenteId).SingleOrDefault();
                    celdaactual.UnidadId = celdaactual.Componentes.UnidadVentaId ?? 0;
                    ServicioWS Ws2 = new ServicioWS("ServiciosERP/Generales/WSUnidades.svc", "getUnidadesXGrupo", DetalleActual.Componentes.GrupoUnidadesId, typeof(System.Collections.ObjectModel.ObservableCollection<Unidades>), "id");

                    celdaactual.LstUnidades = (System.Collections.ObjectModel.ObservableCollection<Unidades>)Ws2.Peticion();

                    this.RaisePropertyChanged(x => x.Item);
                    //this.RaisePropertyChanged(x => x.Item.PremiosMonederoDetalles.Where(z=>z.ComponenteId==celdaactual.ComponenteId).SingleOrDefault().LstUnidades);

                    if (celdaactual.Errores() != null)
                        return;
                }
            }

                 if (Item.Id != 0)
                 {
                     foreach (PremiosMonederoDetalles i in Item.PremiosMonederoDetalles.Where(x => x.PremioMonederoId == 0).ToList())
                     {
                         i.PremioMonederoId = Item.Id;
                     }
                 }
        }



}
   /* public class PremiosMonederoDetallesVM : ViewModelBase
    {
        public PremiosMonederoDetallesVM()
        {
            this.Componentes = new ComponentesModel();
            this.LstUnidades = new System.Collections.ObjectModel.ObservableCollection<UnidadesModel>();
        }

        public long PremioMonederoId { get; set; }
        public long ComponenteId { get; set; }
        public double Cantidad { get; set; }
        public long UnidadId { get; set; }
        public double CantidadReal { get; set; }
        public long UnidadRealId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }

        public virtual ComponentesModel Componentes { get; set; }

        [BindableProperty]
        public virtual System.Collections.ObjectModel.ObservableCollection<UnidadesModel> LstUnidades { get; set; }

        
    }*/
}

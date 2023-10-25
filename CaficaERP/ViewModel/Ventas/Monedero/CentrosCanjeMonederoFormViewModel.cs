using CaficaERP.Model.Inventarios;
using CaficaERP.Model.Ventas.Monedero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel.Ventas.Monedero
{
   public class CentrosCanjeMonederoFormViewModel : FormularioViewModel<CentrosCanjeMonedero>
    {
        private Almacenes _AlmacenSeleccionado;
        private System.Collections.ObjectModel.ObservableCollection<Almacenes> _LstAlmacenesMercaderia;

        public Almacenes AlmacenSeleccionado
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

        public System.Collections.ObjectModel.ObservableCollection<Almacenes> LstAlmacenesMercaderia
        {
            get
            {
                return _LstAlmacenesMercaderia;
            }

            set
            {
                SetProperty(ref _LstAlmacenesMercaderia, value, () => LstAlmacenesMercaderia);
            }
        }

        public CentrosCanjeMonederoFormViewModel(CentrosCanjeMonedero item, string conexion) : base(item, conexion)
        {


        }
        public CentrosCanjeMonederoFormViewModel()

        {
            CargarAlmacenes();
            LstAlmacenes = new System.Collections.ObjectModel.ObservableCollection<Almacenes>(LstAlmacenes.Where(a=>a.TipoComponenteId==2));


        }
        public override void CargarItem()
        {
            base.CargarItem();
            CargarAlmacenes();
            LstAlmacenes = new System.Collections.ObjectModel.ObservableCollection<Almacenes>(LstAlmacenes.Where(a => a.TipoComponenteId == 2));
            AlmacenSeleccionado = LstAlmacenes.Single(x => x.Id == Item.AlmacenId);
        }
    }
}

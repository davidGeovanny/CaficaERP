using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Administracion
{
    public class Vistas : BaseModel
    {
        public Vistas()
        {
            this.AccionesVistas = new ObservableCollection<AccionesVistas>();
            this.VistasGruposVistas = new ObservableCollection<VistasGruposVistas>();
            this.VistasTablas = new ObservableCollection<VistasTablas>();
            this.VistasFiltrosReportes = new ObservableCollection<VistasFiltrosReportes>();

        }

        public string Nombre { get; set; }
        public string Parametros { get; set; }
        public string ImagenMenu { get; set; }
        public Nullable<byte> Orden { get; set; }
        public string Tipo { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
      
        public bool isChecked { get; set; }
        
        public virtual ObservableCollection<AccionesVistas> AccionesVistas { get; set; }
        public virtual ObservableCollection<VistasGruposVistas> VistasGruposVistas { get; set; }
        public virtual ObservableCollection<VistasTablas> VistasTablas { get; set; }
        public virtual ObservableCollection<VistasFiltrosReportes> VistasFiltrosReportes { get; set; }



        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El campo nombre esta vacio.";
                return null;
            }
            if (propiedad == BindableBase.GetPropertyName(()=> Parametros))
            {
                if (string.IsNullOrEmpty(Parametros))
                    return "El campo parametros esta vacio.";
                return null;
            }
            

            return null;
        }
    }

}

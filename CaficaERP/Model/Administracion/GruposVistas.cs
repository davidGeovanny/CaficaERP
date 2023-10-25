
using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace CaficaERP.Model.Administracion
{
    public class GruposVistas : BaseModel
    {
       
        public GruposVistas()
        {
            this.Vistas = new System.Collections.ObjectModel.ObservableCollection<Vistas>();
            this.VistasGruposVistas = new ObservableCollection<VistasGruposVistas>();
        }
        public string Nombre { get; set; }
        public long ModuloId { get; set; }
        public Nullable<sbyte> Orden { get; set; }
        public string UsuarioCreo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public System.DateTime FechaUltimaModificacion { get; set; }
        public long SistemaId { get; set; }
        
        public virtual System.Collections.ObjectModel.ObservableCollection<Vistas> Vistas { get; set; }
        public virtual ObservableCollection<VistasGruposVistas> VistasGruposVistas { get; set; }
        public virtual Modulos Modulos { get; set; }
        public virtual Sistemas Sistemas { get; set; }

        public override string Validar(string propiedad)
        {
            if (propiedad == BindableBase.GetPropertyName(() => Nombre))
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El campo Nombre es Obligatorio";
                if(Nombre.Length > 45)
                    return "El campo contiene demasiados Caracteres";
                return null;
            }
            if (propiedad == BindableBase.GetPropertyName(()=>ModuloId))
            {
                if (ModuloId == 0)
                    return "No ha escogido un Modulo";

                return null;

            }
            if (propiedad == BindableBase.GetPropertyName(() => SistemaId))
            {
                if (SistemaId == 0)
                    return "No ha escogido un Sistema";

                return null;

            }
            return null;
        }
    }
}

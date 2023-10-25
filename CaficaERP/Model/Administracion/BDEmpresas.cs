using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace CaficaERP.Model.Administracion
{
    public class BDEmpresas : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BDEmpresas()
        {
            this.BDEmpresasRoles = new ObservableCollection<BDEmpresasRoles>();
        }

        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public string Status { get; set; }
        public string SalidasSinExistencia { get; set; }
        public string MetodoCosteo { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public string ContrasenaReportes { get; set; }
        public string ValidaVariacionCosto { get; set; }
        public Nullable<double> PorcentajeVariacionCosto { get; set; }
        public Nullable<System.DateTime> InicioPeriodo { get; set; }
        public Nullable<System.DateTime> FinPeriodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<BDEmpresasRoles> BDEmpresasRoles { get; set; }

        public bool isChecked { get; set; }


        //Validacion de Campos en el Formulario de Empresas
        public override string Validar(string propiedad)
        {
            if(propiedad==BindableBase.GetPropertyName(()=>RazonSocial))
            {
                if (string.IsNullOrEmpty(RazonSocial))
                {
                    return "El campo Razon Social es obligatorio";
                }
            }
            if(propiedad==BindableBase.GetPropertyName(()=>RFC))
            {
                if (string.IsNullOrEmpty(RFC))
                {
                    return "RFC es un campo de caracter obligatorio";
                }
            }
           
            if (propiedad == BindableBase.GetPropertyName(() => Status))
            {
                if (string.IsNullOrEmpty(Status))
                    return "El campo Status es Obligatorio";
            }
            return null;
        }
    }
}

using CaficaERP.Model.Administracion;
using DevExpress.Mvvm;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model
{
    public class PermisosModel : ViewModelBase
    {
        private long _Id;
        private string _Nombre;
        private bool _IsChecked;
        private bool _HasChild;
        private string tipo;
        private string _Index;
        private string _ParentId;

        private Modulos modulo;
        private Vistas vista;
        private AccionesVistas accionesVista;

        public long Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
                RaisePropertyChanged(() => Nombre);
            }
        }

        public bool IsChecked
        {
            get
            {
                return _IsChecked;
            }

            set
            {
                _IsChecked = value;
                RaisePropertyChanged(() => IsChecked);
            }
        }

        public bool HasChild
        {
            get
            {
                return _HasChild;
            }

            set
            {
                _HasChild = value;
                RaisePropertyChanged(() => HasChild);
            }
        }

        public string Index
        {
            get
            {
                return _Index;
            }

            set
            {
                _Index = value;
                RaisePropertyChanged(() => Index);
            }
        }

        public string ParentId
        {
            get
            {
                return _ParentId;
            }

            set
            {
                _ParentId = value;
                RaisePropertyChanged(() => ParentId);
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
                RaisePropertyChanged(() => tipo);
            }
        }

        public Modulos Modulo
        {
            get
            {
                return modulo;
            }

            set
            {
                modulo = value;
                RaisePropertyChanged(() => Modulo);
            }
        }

        public Vistas Vista
        {
            get
            {
                return vista;
            }

            set
            {
                vista = value;
                RaisePropertyChanged(() => Vista);
            }
        }

        public AccionesVistas AccionesVista
        {
            get
            {
                return accionesVista;
            }

            set
            {
                accionesVista = value;
                RaisePropertyChanged(() => AccionesVista);
            }
        }
    }
}

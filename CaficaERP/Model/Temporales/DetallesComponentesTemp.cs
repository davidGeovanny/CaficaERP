using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Temporales
{
    public class DetallesComponentesTemp : ViewModelBase
    {
        private string _Id;
        private long _IdBd;
        private long _IdParentBd;
        private string _Clave;
        private long _ComponenteId;
        private string _Componente;
        private long _ComponentesAlmacenesId;
        private double _Existencia;
        private long _UnidadId;
        private string _ParentId;
        private string _Serie;
        private string _Lote;
        private long _LotesSeriesId;
        private long _IdsHijos;
        private string _TipoSeguimiento;
        private Nullable<System.DateTime> _FechaCaducidad;

        public string Id
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
        public string Clave
        {
            get
            {
                return _Clave;
            }

            set
            {
                _Clave = value;
                RaisePropertyChanged(() => Clave);
            }
        }
        public long ComponenteId
        {
            get
            {
                return _ComponenteId;
            }

            set
            {
                _ComponenteId = value;
                RaisePropertyChanged(() => ComponenteId);
            }
        }
        public string Componente
        {
            get
            {
                return _Componente;
            }

            set
            {
                _Componente = value;
            }
        }
        public double Existencia
        {
            get
            {
                return _Existencia;
            }

            set
            {
                _Existencia = value;
                RaisePropertyChanged(() => Existencia);
            }
        }

        public long UnidadId
        {
            get
            {
                return _UnidadId;
            }

            set
            {
                _UnidadId = value;
                RaisePropertyChanged(() => UnidadId);
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
        public string Serie
        {
            get
            {
                return _Serie;
            }

            set
            {
                _Serie = value;
                RaisePropertyChanged(() => Serie);
            }
        }

        public string Lote
        {
            get
            {
                return _Lote;
            }

            set
            {
                _Lote = value;
                RaisePropertyChanged(() => Lote);
            }
        }

        public DateTime? FechaCaducidad
        {
            get
            {
                return _FechaCaducidad;
            }

            set
            {
                _FechaCaducidad = value;
                RaisePropertyChanged(() => FechaCaducidad);
            }
        }

        public long IdsHijos
        {
            get
            {
                return _IdsHijos;
            }

            set
            {
                _IdsHijos = value;
                RaisePropertyChanged(() => IdsHijos);
            }
        }

        public string TipoSeguimiento
        {
            get
            {
                return _TipoSeguimiento;
            }

            set
            {
                _TipoSeguimiento = value;
                RaisePropertyChanged(() => TipoSeguimiento);
            }
        }

        public long IdBd
        {
            get
            {
                return _IdBd;
            }

            set
            {
                _IdBd = value;
                RaisePropertyChanged(() => IdBd);
            }
        }

        public long IdParentBd
        {
            get
            {
                return _IdParentBd;
            }

            set
            {
                _IdParentBd = value;
                RaisePropertyChanged(() => IdParentBd);
            }
        }

        public long ComponentesAlmacenesId
        {
            get
            {
                return _ComponentesAlmacenesId;
            }

            set
            {
                _ComponentesAlmacenesId = value;
                RaisePropertyChanged(() => ComponentesAlmacenesId);
            }
        }

        public long LotesSeriesId
        {
            get
            {
                return _LotesSeriesId;
            }

            set
            {
                _LotesSeriesId = value;
                RaisePropertyChanged(() => LotesSeriesId);
            }
        }
    }
}

using CaficaERP.Model.Inventarios;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Temporales
{
    public class DetallesLotes_Series_ESTemp : ViewModelBase
    {
        private long _Id;
        private int _ParentId;
        private long _InventariosESDetalleId;
        private string _Seguimiento;
        private long _ComponenteId;
        private double _Cantidad;
        private long _LoteSerieId;
        private string _SerieLote;
        private string _TipoSeguimiento;
        private string _Caducidad;
        private string _SerieLotebd;
        private string _Naturaleza;
        private Nullable<System.DateTime> _FechaCaducidad;
        private System.Collections.ObjectModel.ObservableCollection<LotesSeries> _LstLotesSeries;

        public long InventariosESDetalleId
        {
            get
            {
                return _InventariosESDetalleId;
            }

            set
            {
                _InventariosESDetalleId = value;
                RaisePropertyChanged(() => InventariosESDetalleId);
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

        public double Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
                RaisePropertyChanged(() => Cantidad);
            }
        }

        public string SerieLote
        {
            get
            {
                return _SerieLote;
            }

            set
            {
                //no te permite modificar las celdas que no sean sin lote o serie
                if (this.Id != 0 && _SerieLotebd != "SIN SERIE" && _SerieLotebd != "SIN LOTE" && _SerieLotebd != null)
                    return;
                _SerieLote = value;
                //  FechaCaducidad = DateTime.Now; 
                if(LstLotesSeries!=null && LstLotesSeries.Count>0 && LstLotesSeries.FirstOrDefault().Lote!=null && value!="SIN LOTE" && (Naturaleza=="Salida" || Naturaleza=="SALIDA") )
                FechaCaducidad = LstLotesSeries.Where(l => l.Lote == value).FirstOrDefault().FechaCaducidad;
                RaisePropertyChanged(() => SerieLote);
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

        public int ParentId
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

        public string Seguimiento
        {
            get
            {
                if (TipoSeguimiento == "NÚMERO DE SERIE")
                    return "Serie:";
                else if (TipoSeguimiento == "LOTES")
                    return "Lote:";
                else
                    return "";
            }
            set
            {
                _Seguimiento = value;
                RaisePropertyChanged(() => Seguimiento);
            }
        }

        public string Caducidad
        {
            get
            {
                if (TipoSeguimiento == "LOTES")
                    return "Caducidad:";
                else
                    return "";
            }

            set
            {
                _Caducidad = value;
                RaisePropertyChanged(() => Caducidad);
            }
        }

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

        public long LoteSerieId
        {
            get
            {
                return _LoteSerieId;
            }

            set
            {
             
                
                _LoteSerieId = value;
                RaisePropertyChanged(() => LoteSerieId);
            }
        }

        public string SerieLotebd
        {
            get
            {
                return _SerieLotebd;
            }

            set
            {
                _SerieLotebd = value;
                RaisePropertyChanged(() => SerieLotebd);
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<LotesSeries> LstLotesSeries
        {
            get
            {
                return _LstLotesSeries;
            }

            set
            {
                _LstLotesSeries = value;
                RaisePropertyChanged(() => LstLotesSeries);
            }
        }

        public string Naturaleza
        {
            get
            {
                return _Naturaleza;
            }

            set
            {
                _Naturaleza = value;
                RaisePropertyChanged(() => Naturaleza);
            }
        }
    }
}

using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel
{
    public abstract class TabViewModel : ViewModelBase
    {
        //Esta clase permite castear todas las vistas para ser mostradas en los tabs
        private DateTime _FechaInicioFiltrado;
        private DateTime _FechaFinFiltrado;
        private bool _FiltradoFechas;
        public abstract void Nuevo();
        public abstract void Abrir();
        public abstract void Eliminar();
        public abstract void Imprimir();
        public abstract void Refrescar();
        public abstract long Siguiente();
        public abstract long Anterior();
        public abstract void Meses();
        public abstract void Home();

        public string Titulo;

        public DateTime FechaInicioFiltrado
        {
            get
            {
                return _FechaInicioFiltrado;
            }

            set
            {
                _FechaInicioFiltrado = value;
            }
        }

        public DateTime FechaFinFiltrado
        {
            get
            {
                return _FechaFinFiltrado;
            }

            set
            {
                _FechaFinFiltrado = value;
            }
        }

        public bool FiltradoFechas
        {
            get
            {
                return _FiltradoFechas;
            }

            set
            {
                _FiltradoFechas = value;
            }
        }
    }
}

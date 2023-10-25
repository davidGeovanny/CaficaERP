using CaficaERP.Model;
using CaficaERP.Model.Inventarios;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CaficaERP.ViewModel.Inventarios
{
    [POCOViewModel]
    public class BuscadorFormViewModel <TModelo> where TModelo: BaseModel
    {
        public virtual System.Collections.ObjectModel.ObservableCollection<TModelo> LstItems { get; set; }
        public virtual System.Collections.ObjectModel.ObservableCollection<Column> Columns { get; set; }

        public virtual TModelo ItemSeleccionado { get; set; }
 
        public BuscadorFormViewModel(System.Collections.ObjectModel.ObservableCollection<TModelo> ListaOrigen, System.Collections.ObjectModel.ObservableCollection<TModelo> ListaSeleccionada, System.Collections.ObjectModel.ObservableCollection<Column> Columnas)
        {
            LstItems = new System.Collections.ObjectModel.ObservableCollection<TModelo>(ListaOrigen.Except(ListaSeleccionada).ToList());
            Columns = Columnas;
        }
        public BuscadorFormViewModel(System.Collections.ObjectModel.ObservableCollection<TModelo> ListaOrigen, System.Collections.ObjectModel.ObservableCollection<Column> Columnas)
        {
            LstItems = ListaOrigen;
            Columns = Columnas;
        }
        public void SeleccionarItem()
        {
            try
            {
               VariablesGlobales.BuscadorItemSeleccionado = ItemSeleccionado;
                 
                for (int i = 0; i < Application.Current.Windows.Count; i++)
                {
                    if (Application.Current.Windows[i].DataContext == this)
                    {
                        Application.Current.Windows[i].Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

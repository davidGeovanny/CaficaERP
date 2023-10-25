using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Clase para expadir los hijos del padre seleccion en el gridcontrol con agruparadores
  */
namespace CaficaERP
{
    public interface IMasterDetailService
    {
        void ExpandMasterRow(object row);
        void CollapseMasterRow(object row);
    }

    public class MasterDetailService : ServiceBase, IMasterDetailService
    {

        GridControl Grid { get { return AssociatedObject as GridControl; } }

        public void ExpandMasterRow(object row)
        {
            SetIsRowExpanded(row, true);
        }

        public void CollapseMasterRow(object row)
        {
            SetIsRowExpanded(row, false);
        }

        void SetIsRowExpanded(object row, bool expand)
        {
            if (Grid == null || row == null)
                return;
            int rowHandle = Grid.DataController.FindRowByRowValue(row);
            Grid.SetMasterRowExpanded(rowHandle, expand);
        }
    }
}

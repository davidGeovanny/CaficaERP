// Developer Express Code Central Example:
// How to make GridControl immediately save changes in a cell after editing
// 
// This example shows how to update GridControl's data source right after a cell
// editor value has been changed. To implement this scenario, we created a custom
// helper class exposing the CommitHelper.CommitOnValueChanged attached
// property.
// 
// This example uses the same idea as the one demonstrated in the
// http://www.devexpress.com/scid=E1801 thread. If you don't want to use custom
// helpers, check the solution from the E1801 example instead.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4155

// Developer Express Code Central Example:
// How to make GridControl immediately save changes in a cell after editing
// 
// This example shows how to update GridControl DataSource right after a cell
// editor value has been changed. To implement this scenario, we have introduced
// the CommitHelper.CommitOnValueChanged attached property.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4155

using System;
using System.Windows;
using System.Windows.Threading;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.TreeList;

namespace CaficaERP
{
    class CommitHelper
    {
        public static readonly DependencyProperty CommitOnValueChangedProperty = DependencyProperty.RegisterAttached("CommitOnValueChanged", typeof(bool), typeof(CommitHelper), new PropertyMetadata(CommitOnValueChangedPropertyChanged));

        public static void SetCommitOnValueChanged(GridColumnBase element, bool value)
        {
            element.SetValue(CommitOnValueChangedProperty, value);
        }

        public static bool GetCommitOnValueChanged(GridColumnBase element)
        {
            return (bool)element.GetValue(CommitOnValueChangedProperty);
        }

        private static void CommitOnValueChangedPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            GridColumnBase col = source as GridColumnBase;
            if (col.View == null)
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action<GridColumnBase, bool>((column, subscribe) => { ToggleCellValueChanging(column, subscribe); }), col, (bool)e.NewValue);
            else
                ToggleCellValueChanging(col, (bool)e.NewValue);
        }

        private static void ToggleCellValueChanging(GridColumnBase col, bool subscribe)
        {
            if (!(col.View is DataViewBase))
                return;

            if (subscribe)
            {
                if (col.View is TreeListView)
                    (col.View as TreeListView).CellValueChanging += TreeCellValueChanging;
                else
                    (col.View as GridViewBase).CellValueChanging += GridCellValueChanging;
            }
            else
            {
                if (col.View is TreeListView)
                    (col.View as TreeListView).CellValueChanging -= TreeCellValueChanging;
                else
                    (col.View as GridViewBase).CellValueChanging -= GridCellValueChanging;
            }
        }

        static void TreeCellValueChanging(object sender, TreeListCellValueChangedEventArgs e)
        {
            if ((bool)e.Column.GetValue(CommitOnValueChangedProperty))
            {
                (sender as DataViewBase).PostEditor();
                e.Handled = true;
            }
        }

        static void GridCellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if ((bool)e.Column.GetValue(CommitOnValueChangedProperty))
            {
                (sender as DataViewBase).PostEditor();
                e.Handled = true;
            }
        }
    }
}

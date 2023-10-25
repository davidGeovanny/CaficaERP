using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CaficaERP
{
    public class Column
    {
        public string Header { get; set; }
        public string FieldName { get; set; }
        public SettingsType Settings { get; set; }
    }
    public class ComboColumn : Column
    {
        public IList Source { get; set; }
    }
    public class Imagen : Column
    {
        //public string RutaImagen { get; set; }
        public string ToolTip { get; set; }
    }
    public enum SettingsType { Default, Combo,Imagen }

    public class ColumnTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Column column = (Column)item;
            return (DataTemplate)((Control)container).FindResource(column.Settings + "ColumnTemplate");
        }
    }
}

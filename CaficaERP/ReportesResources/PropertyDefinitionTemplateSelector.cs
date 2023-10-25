
using System.Collections;

using System.Collections.ObjectModel;
using System.Data;

using System.Windows;
using System.Windows.Controls;
using System.Linq;
using DevExpress.Mvvm;

namespace CaficaERP.ReportesResources
{
    public class Property : ViewModelBase
    {
        private string _name;
        private TipoTemplate _template;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public TipoTemplate Template
        {
            get
            {
                return _template;
            }

            set
            {
                _template = value;
                RaisePropertyChanged(() => Template);
            }
        }
    }
    public class PropertyCombo : Property
    {
        private IList _SourceData;
        private string _CampoValue;
        private string _CampoDisplay;
        public IList SourceData
        {
            get
            {
                return _SourceData;
            }

            set
            {
                _SourceData = value;
                RaisePropertyChanged(() => SourceData);
            }
        }

        public string CampoValue
        {
            get
            {
                return _CampoValue;
            }

            set
            {
                _CampoValue = value;
                RaisePropertyChanged(() => CampoValue);
            }
        }

        public string CampoDisplay
        {
            get
            {
                return _CampoDisplay;
            }

            set
            {
                _CampoDisplay = value;
                RaisePropertyChanged(() => CampoDisplay);
            }
        }
    }
    public class PropertyLookUp : Property
    {
        public DataTable _SourceDataL;
        public DataTable SourceDataL
        {
            get
            {
                return _SourceDataL;
            }

            set
            {
                _SourceDataL = value;
                RaisePropertyChanged(() => SourceDataL);
            }
        }
    }
    public class GridColumn 
    {
        public string FieldName { get; set; }
        public string Header { get; set; }
    }

    public enum TipoTemplate { Default, Combo, Date , LookUp, ComboEnum }
    // A template selector. 
    public class PropertyDefinitionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ComboTemplate { get; set; }
        
        public DataTemplate DateTemplate { get; set; }
        public DataTemplate LookUpTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (!(item is Property))
            {
                return null;
            }
            if (((Property)item).Template == TipoTemplate.Combo)
            {
                return ComboTemplate;
            }
            if (((Property)item).Template == TipoTemplate.Date)
            {
                return DateTemplate;
            }
            if (((Property)item).Template == TipoTemplate.LookUp)
            {
                return LookUpTemplate;
            }
            

            return base.SelectTemplate(item, container);
        }
    }

   

    // ... 
}
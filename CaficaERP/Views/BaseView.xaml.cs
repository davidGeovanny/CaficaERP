using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;


namespace CaficaERP.Views
{
    /// <summary>
    /// Interaction logic for BaseView.xaml
    /// </summary>
    public partial class BaseView : DXWindow
    {
        public BaseView()
        {
            InitializeComponent();
        }

        private void DockPanel_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}

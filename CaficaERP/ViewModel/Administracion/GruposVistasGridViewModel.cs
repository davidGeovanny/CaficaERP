﻿using CaficaERP.Model.Administracion;
using CaficaERP.Views.Administracion;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel.Administracion
{
    public class GruposVistasGridViewModel : GridViewModel<GruposVistas, GruposVistasFormView, GruposVistasFormViewModel>

    {
       

        public GruposVistasGridViewModel(string WebService, string Reporte, string ReporteForm) : base(WebService, Reporte, ReporteForm)
        {
            Columns = new System.Collections.ObjectModel.ObservableCollection<Column>() {
                new Column() { Header="Nombre", FieldName = "Nombre", Settings = SettingsType.Default },
                new Column() { Header="Sistema", FieldName = "Sistemas.Nombre", Settings = SettingsType.Default },
                new Column() { Header="Modulo", FieldName = "Modulos.Nombre", Settings = SettingsType.Default },

            };
        }

    }

}


 
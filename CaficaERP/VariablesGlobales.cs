using CaficaERP.Model;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP
{
    public static class VariablesGlobales
    {

        public static DXWindow Main { get; set; }
        public static string Token { get; set; }
        public static string TokenEmpresa { get; set; }
        public static string TokenReportes { get; set; }
        public static string BdEmpresa { get; set; }
        public static string RazoSocialEmpresa { get; set; }
        public static string MetodoCosteoEmpresa { get; set; }
        public static string PasswordReportes { get; set; }
        public static string UsuarioFirmado { get; set; }
        public static DateTime? FechaActual { get; set; }
        public static DateTime FechaInicio { get; set; }
        public static DateTime FechaFin { get; set; }
        public static string Version { get; set; }
        public static BaseModel BuscadorItemSeleccionado { get; set; }
    }
}

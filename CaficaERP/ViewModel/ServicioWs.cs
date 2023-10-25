using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaficaERP.ViewModel
{
    class ServicioWS
    {
        private object JSONRequest;
        private string JSONmethod;
        private string JSONContentType;
        private Type JSONResponseType;
        private string ObjWS;
        private string Servicie;
        private string Method;
        private string Url;
        private string requestUrl
        {
            get
            {
                if (this.Url == null)
                    if (System.Diagnostics.Debugger.IsAttached)
                        return "http://localhost:54363/" + this.Servicie + "/" + this.Method;
                    else
                        return "http://10.10.1.170/WcfCafica/" + this.Servicie + "/" + this.Method;
                else
                    return this.Url;

            }
        }
        public string url
        {
            get
            {
                return this.Url;
            }
            set
            {
                this.Url = value;
            }
        }
        public string Servicio
        {
            get
            {
                return this.Servicie;
            }
            set
            {
                this.Servicie = value;
            }
        }
        public string Metodo
        {
            get
            {
                return this.Method;
            }

            set
            {
                this.Method = value;
            }
        }
        public Object ObjetoEnvio
        {
            set
            {
                this.JSONRequest = value;
            }
        }
        public Type TipoObjetoRespuesta
        {
            set
            {
                this.JSONResponseType = value;
            }
        }
        public string Parametros
        {
            set
            {
                this.ObjWS = value;
            }
        }
        public ServicioWS(string url, Object ObjetoEnvio, Type TipoObjetoRespuesta, string Parametros)
        {
            Url = url;
            JSONRequest = ObjetoEnvio;
            JSONmethod = "POST";
            JSONContentType = "application/json";
            JSONResponseType = TipoObjetoRespuesta;
            ObjWS = Parametros;
        }
        public ServicioWS(string Servicio, string Metodo, Object ObjetoEnvio, Type TipoObjetoRespuesta, string Parametros)
        {
            //requestUrl = @"http://localhost/WsCfdi/"+Servicio+"/"+Metodo;
            Servicie = Servicio;
            Method = Metodo;
            JSONRequest = ObjetoEnvio;
            JSONmethod = "POST";
            JSONContentType = "application/json";
            JSONResponseType = TipoObjetoRespuesta;
            ObjWS = Parametros;
        }
        public object Peticion()
        {

            object result;
            try
            {

                HttpWebRequest httpWebRequest = WebRequest.Create(requestUrl) as HttpWebRequest;
                //Formatea la fecha a formato json /Date(21423423)/
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                string text = JsonConvert.SerializeObject(JSONRequest, microsoftDateFormatSettings);
                text = string.Concat(new string[]{"{\"",
                    ObjWS,
                    "\":",
                    text,
                    "}"
                });
                httpWebRequest.Method = JSONmethod;
                httpWebRequest.ContentType = JSONContentType;
                //Agrega el token de autorizacion a cada peticion
                httpWebRequest.Headers.Add("Token", VariablesGlobales.Token);
                //Agrega el token empresa a cada peticion
                httpWebRequest.Headers.Add("TokenEmpresa", VariablesGlobales.TokenEmpresa);
                //Fecha en la vista principal
                httpWebRequest.Headers.Add("FechaInicio", VariablesGlobales.FechaInicio.ToShortDateString());
                //Fecha en la vista princial
                httpWebRequest.Headers.Add("FechaFin", VariablesGlobales.FechaFin.ToShortDateString());
                //Variables para idenficar la versio del sistema corriendo
                httpWebRequest.Headers.Add("Version", VariablesGlobales.Version);
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(string.Format("Server error (HTTP {0}: {1}).", httpWebResponse.StatusCode, httpWebResponse.StatusDescription));
                    }
                    if (httpWebResponse.Headers["Error"] != null)
                        throw new Exception(httpWebResponse.Headers["Error"]);

                    if (VariablesGlobales.FechaActual == null)
                        VariablesGlobales.FechaActual = Convert.ToDateTime(httpWebResponse.Headers["FechaActual"]);

                    Stream responseStream = httpWebResponse.GetResponseStream();
                    StreamReader streamReader = new StreamReader(responseStream);
                    string text2 = streamReader.ReadToEnd();

                    object obj = JsonConvert.DeserializeObject(text2, JSONResponseType);
                    result = obj;
                }
            }
            catch (Exception ex)
            {
                //Dispatcher.FromThread(newWindowThread).InvokeShutdown();
                //MessageBox.Show(ex.Message);
                throw;
                //result = JSONRequest;
            }
            return result;
        }
    }
}

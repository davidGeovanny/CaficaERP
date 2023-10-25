using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.ViewModel
{
    public class ServicioWSReportes
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
                    return "http://172.16.5.45:54363/" + this.Servicie + "/" + this.Method;
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
        public ServicioWSReportes(string url, Object ObjetoEnvio, Type TipoObjetoRespuesta, string Parametros)
        {
            Url = url;
            JSONRequest = ObjetoEnvio;
            JSONmethod = "POST";
            JSONContentType = "application/json";
            JSONResponseType = TipoObjetoRespuesta;
            ObjWS = Parametros;
        }
        public ServicioWSReportes(string Servicio, string Metodo, Object ObjetoEnvio, Type TipoObjetoRespuesta, string Parametros)
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
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };

                string text = JsonConvert.SerializeObject(JSONRequest, microsoftDateFormatSettings);
              
                httpWebRequest.Method = JSONmethod;
                httpWebRequest.ContentType = JSONContentType;

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

                    Stream responseStream = httpWebResponse.GetResponseStream();
                    StreamReader streamReader = new StreamReader(responseStream);
                    string text2 = streamReader.ReadToEnd();

                    object obj = JsonConvert.DeserializeObject(text2, JSONResponseType);
                    result = obj;
                }
            }
            catch (Exception)
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

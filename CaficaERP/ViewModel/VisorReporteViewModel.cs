using CaficaERP.Model.Reportes;
using DevExpress.Mvvm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CaficaERP.ReportesResources;
using System.ComponentModel;
using CaficaERP.Views;
using CaficaERP.Model.Inventarios;
using System.Dynamic;
using System.Data;
using System.Reflection;
using System.Collections;
using CaficaERP.Model.Administracion;
using DevExpress.Xpf.WindowsUI;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.PdfViewer;
using Microsoft.Win32;

namespace CaficaERP.ViewModel
{

    public class Employee
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime BirthDate { get; set; }
        public long Almacen { get; set; }
    }

    public class VisorReporteViewModel : ListasFormulario
    {
      
        //  public dynamic Data { get; set; }
        private System.Collections.ObjectModel.ObservableCollection<Property> _Properties;
        private MyDictionary _dict;
        public Employee EditObject { get; set; }
        enum Days { Sun = 1, Mon = 2, Tue = 3, Wed = 4, Thu = 5, Fri = 6, Sat = 10 };
        private string requestUrl = System.Diagnostics.Debugger.IsAttached==true ? "http://10.10.1.72:8082/jasperserver/"  : "http://10.10.1.170:8080/jasperserver/" ;
        private string token;
        private ContentControl _reporte;
        private string _UrlReporte;
        private List<reportParameter> _LstParametros;

        private string _PanelFiltrosState;
        private string _PanelFiltrosVisibility;

        private PdfViewerControl _VisorReporte;
        private string _Formato;
        
        public Vistas VistaReporte { get; set; }
        public DelegateCommand DcGenerarReporte { get; set; }
        public DelegateCommand DCCambioValorCelda { get; set; }
        public DelegateCommand DCLimpiarFiltros { get; set; }



        public ContentControl Reporte
        {
            get
            {
                return _reporte;
            }

            set
            {
                SetProperty(ref _reporte, value, () => Reporte);
            }
        }

        public string UrlReporte
        {
            get
            {
                return _UrlReporte;
            }

            set
            {
                _UrlReporte = value;
            }
        }

        public List<reportParameter> LstParametros
        {
            get
            {
                return _LstParametros;
            }

            set
            {
                _LstParametros = value;
            }
        }

        public string Formato
        {
            get
            {
                return _Formato;
            }

            set
            {
                _Formato = value;
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Property> Properties
        {
            get
            {
                return _Properties;
            }

            set
            {

                 SetProperty(ref _Properties, value, () => Properties); 
            }
        }

        public MyDictionary Dict
        {
            get
            {
                return _dict;
            }

            set
            {
                SetProperty(ref _dict, value, () => Dict);
            }
        }

        public string PanelFiltrosState
        {
            get
            {
                return _PanelFiltrosState;
            }

            set
            {
                SetProperty(ref _PanelFiltrosState, value, () => PanelFiltrosState);
            }
        }

        public string PanelFiltrosVisibility
        {
            get
            {
                return _PanelFiltrosVisibility;
            }

            set
            {
                SetProperty(ref _PanelFiltrosVisibility, value, () => PanelFiltrosVisibility);
            }
        }

        public PdfViewerControl VisorReporte
        {
            get
            {
                return _VisorReporte;
            }

            set
            {
                SetProperty(ref _VisorReporte, value, () => VisorReporte);
            }
        }

        public VisorReporteViewModel(string urlreporte, List<reportParameter> parametros, string formato)
        {
            LstParametros = new List<reportParameter>();
            UrlReporte = urlreporte;
            LstParametros = parametros;
            Formato = formato;
            GenerarReporte();
            PanelFiltrosVisibility = "Hidden";
      
        }
        public VisorReporteViewModel(string urlreporte, reportParameter parametro, string formato)
        {
            LstParametros = new List<reportParameter>();
            UrlReporte = urlreporte;
            LstParametros.Add(parametro);
            Formato = formato;
            PanelFiltrosVisibility = "Hidden";
            

            GenerarReporte();
          
        }
        public VisorReporteViewModel(string urlreporte, string formato)
        {
            LstParametros = new List<reportParameter>();
            UrlReporte = urlreporte;
            Formato = formato;
            PanelFiltrosVisibility = "Hidden";
            GenerarReporte();
        }
        public VisorReporteViewModel(int idreporte, string urlreporte, string formato)
        {
            LstParametros = new List<reportParameter>();
            UrlReporte = urlreporte;
            Formato = formato;
            DcGenerarReporte = new DelegateCommand(GenerarReporte);
            DCCambioValorCelda = new DelegateCommand(CambioValorCelda);
            DCLimpiarFiltros = new DelegateCommand(LimpiarFiltros);
            ContentControl rep = new ContentControl();
            rep.Content = new PDFVisorReporteView();
            rep.DataContext = new PDFVisorReporteViewModel(null);
            Reporte = rep;
            PanelFiltrosVisibility = "Visible";
            PanelFiltrosState = "Visible";

            CreateFiltros(idreporte);
        }

        public void LimpiarFiltros()
        {

            Dict.Clear();
            Properties.Clear();

            CreateFiltros((Int32)VistaReporte.Id);


        }

        public static DataTable ListToDataTable(IList items,string[] columnas)
        {

            try
            {
                DataTable dataTable = new DataTable();

                //Get all the properties

                PropertyInfo[] Props = items[0].GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (string col in columnas)
                {
                    PropertyInfo prop = Array.Find(Props, element => element.Name == col);
                    //Defining type of data column gives proper data table 
                    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name, type);
                }

                foreach (var item in items)
                {
                    var values = new object[columnas.Length];
                    int j = 0;
                    foreach (string col in columnas)
                    {
                        PropertyInfo prop = Array.Find(Props, element => element.Name == col);
                        values[j] = prop.GetValue(item, null);
                        j = j + 1;
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
                return null;
               
            }
        }

    
        private void CreateFiltros(int reporteId)
        {

            try
            {
                ServicioWS Ws = new ServicioWS("ServiciosERP/Administracion/WSVistas.svc", "get", reporteId, typeof(Vistas), "id");
                VistaReporte = (Vistas)Ws.Peticion();



                Dict = new MyDictionary();
                Properties = new System.Collections.ObjectModel.ObservableCollection<Property>();

                foreach (VistasFiltrosReportes fr in VistaReporte.VistasFiltrosReportes)
                {
                    if (fr.Tipo == "COMBO")
                    {
                        if(string.IsNullOrEmpty(fr.DependeDeEtiqueta))
                        {
                            Type type = typeof(ListasFormulario);
                            MethodInfo info = type.GetMethod(fr.MetodoLista);
                            info.Invoke(this, null);
                            IList lstSource = (IList)this.GetType().GetProperty(fr.Lista).GetValue(this);
                            //info.Invoke(this, null);
                            //Agregamos la opcion de Todos
                            /*Type tipo = lstSource[0].GetType();                            
                            var objeto = Activator.CreateInstance(tipo);
                            objeto.GetType().GetProperty("Id").SetValue(objeto, 0);
                            objeto.GetType().GetProperty("Nombre").SetValue(objeto, "TODOS");
                            lstSource.Add(objeto);               */
                            var valorcampo = lstSource[0].GetType().GetProperty(fr.CampoValue).GetValue(lstSource[0]);
                            Type tipo = valorcampo.GetType();
                            if (tipo == typeof(string))
                            {
                                var valor = "";
                                Dict.Add(fr.Etiqueta,valor );
                            }    
                            else
                            {
                                var valor = Activator.CreateInstance(tipo);
                                Dict.Add(fr.Etiqueta, valor);
                            }

                            Properties.Add(new PropertyCombo() { Name = fr.Etiqueta,CampoDisplay=fr.CampoDisplay,CampoValue=fr.CampoValue, Template = TipoTemplate.Combo, SourceData = lstSource });
                        }
                        else
                        {
                            long valor = new long();
                            Dict.Add(fr.Etiqueta, valor);
                            Properties.Add(new PropertyCombo() { Name = fr.Etiqueta, CampoDisplay = fr.CampoDisplay, CampoValue = fr.CampoValue, Template = TipoTemplate.Combo });
                        }
                           

                    }
                    else if (fr.Tipo == "LOOKUP")
                    {
                        if (string.IsNullOrEmpty(fr.DependeDeEtiqueta))
                        {
                            var Columnas = fr.Columnas.Split(',');

                            long valor = new long();
                            Dict.Add(fr.Etiqueta, valor);

                            Type type = typeof(ListasFormulario);
                            MethodInfo info = type.GetMethod(fr.MetodoLista);
                            info.Invoke(this, null);
                            IList lstSource = (IList)this.GetType().GetProperty(fr.Lista).GetValue(this);
                            info.Invoke(this, null);

                            DataTable table = new DataTable();
                            table = ListToDataTable(lstSource, Columnas);

                            Properties.Add(new PropertyLookUp() { Name = fr.Etiqueta, Template = TipoTemplate.LookUp, SourceDataL = table });
                        }
                        else
                        {
                            long valor = new long();
                            Dict.Add(fr.Etiqueta, valor);
                            Properties.Add(new PropertyLookUp() { Name = fr.Etiqueta, Template = TipoTemplate.LookUp });
                        }
                    }
                    else if (fr.Tipo == "DATE")
                    {
                        DateTime valor = DateTime.Now;
                        Dict.Add(fr.Etiqueta, valor);
                        Properties.Add(new Property() { Name = fr.Etiqueta, Template = TipoTemplate.Date });
                    }

                }

                // Agregar la opcion del formato
                LstFormatosReportes = null;
                CargarFormatosReportes();
                Dict.Add("Formato", "Vista Previa(PDF)");
                Properties.Add(new PropertyCombo() { Name = "Formato", CampoDisplay = "nombre", CampoValue = "nombre", Template = TipoTemplate.Combo, SourceData = LstFormatosReportes });


            }
            catch (Exception ex)
            {

                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }

        private void GenerarReporte()
          {
              try
              {


                //Paso 1
                //Adquire un idetificado con jaspersoft
                token = null;
                  token = (string)Peticion("POST", "j_username=" + VariablesGlobales.BdEmpresa + "&j_password=" + VariablesGlobales.PasswordReportes, "application/x-www-form-urlencoded", "", typeof(string), "rest/login");
                var Extension = "pdf";
                // Obtener el formato  que selecciono el usuario
                if (VistaReporte != null)
                {
                    object valorformato = new object();
                    Dict.TryGetValue("Formato", out valorformato);
                    Formato = valorformato.ToString();
                    
                    foreach (object o in LstFormatosReportes)
                    {
                        if (o.GetType().GetProperty("nombre").GetValue(o).ToString() == Formato)
                        {
                            Extension = o.GetType().GetProperty("extension").GetValue(o).ToString();
                        }
                    }
                }
            
                

                //Genera caracterizticas del reporte
                ReporteModel rpt = new ReporteModel();
                  rpt.reportUnitUri = UrlReporte;
                  rpt.async = false;
                  rpt.freshData = false;
                  rpt.saveDataSnapshot = false;
                  rpt.outputFormat = Extension;
                  rpt.interactive = true;
                  rpt.ignorePagination = false;

                //    reportParameter parametro = new reportParameter();

                if (VistaReporte != null)
                {
                    LstParametros.Clear();
                    foreach (VistasFiltrosReportes vf in VistaReporte.VistasFiltrosReportes)
                    {
                       
                            
                            object valorparametro = new object();
                            Dict.TryGetValue(vf.Etiqueta, out valorparametro);
                            reportParameter Parametro = new reportParameter();
                            Parametro.name = vf.NombreParametro;

                            if (vf.Tipo == "DATE")
                                Parametro.value.Add(valorparametro.ToString().Substring(0,10));
                            else
                                Parametro.value.Add(valorparametro.ToString());

                            LstParametros.Add(Parametro);


                    }
                }
                //Agrega el parametro usuario y empresa
                reportParameter ParametroEmpresa = new reportParameter();
                  ParametroEmpresa.name = "ParametroEmpresa";
                  ParametroEmpresa.value.Add(VariablesGlobales.RazoSocialEmpresa);
                  LstParametros.Add(ParametroEmpresa);

                  reportParameter ParametroUsuario = new reportParameter();
                  ParametroUsuario.name = "ParametroUsuario";
                  ParametroUsuario.value.Add(VariablesGlobales.UsuarioFirmado);
                  LstParametros.Add(ParametroUsuario);

                  

                  //Agrega los parametros al reporte
                  reportParameters parametros = new reportParameters();
                  parametros.reportParameter = LstParametros;

                  rpt.parameters = parametros;

               


                //Paso 2
                //Mandas la orden para que genere el reporte y retorne el identificador del mismo
                ResponseReportModel RespuestaReporte = new ResponseReportModel();
                  JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
                  RespuestaReporte = (ResponseReportModel)Peticion("POST", JsonConvert.SerializeObject(rpt, microsoftDateFormatSettings), "application/json", "application/json", typeof(ResponseReportModel), "rest_v2/reportExecutions");

                  if (RespuestaReporte.exports[0].status != "ready")
                      throw new Exception(RespuestaReporte.exports[0].status);

                  //Paso 3
                  //Una vez con el id generado mandas a descargar el reporte
                  //Nota se utiliza la clase WebCliente por que la clase HttpWebRequest solo es compatible con texto
                  string url = requestUrl + "rest_v2/reportExecutions/" + RespuestaReporte.requestId + "/exports/" + RespuestaReporte.exports[0].id + "/outputResource";

                

                if(Extension=="pdf")
                {
                    string rutaTemporal = Path.GetDirectoryName(Path.GetTempPath()) + "\\Erp-" + RespuestaReporte.exports[0].id + "." + Extension;

                    WebClient Cliente = new WebClient();
                    Cliente.Headers.Add("Cookie", token);
                    Cliente.DownloadFile(url, rutaTemporal);

                    ContentControl r = new ContentControl();
                    r.Content = new PDFVisorReporteView();
                    r.DataContext = new PDFVisorReporteViewModel(rutaTemporal);
                    Reporte = r;
                    PanelFiltrosState = "Hidden";
                }
                else
	            {
                    // Displays a SaveFileDialog so the user can save the Image
                    // assigned to Button2.
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Title = "Guardar Reporte";
                    saveDialog.AddExtension = true;
                   // saveDialog.DefaultExt = Extension;

                    if (saveDialog.ShowDialog()== true)
                    {
                        string filepath = saveDialog.FileName;
                        string rutaTemporal =filepath  + "." + Extension;
                        WebClient Cliente = new WebClient();
                        Cliente.Headers.Add("Cookie", token);
                        Cliente.DownloadFile(url, rutaTemporal);
                        DXMessageBox.Show("El reporte se ha descargado en: " +rutaTemporal, "Generación de Reporte");
                    }
                }
               

                
            }
            catch (Exception ex)
              {
                DXMessageBox.Show(VariablesGlobales.Main, ex.Message, "Error", MessageBoxButton.OK,
                                          MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
          }

        public void CambioValorCelda()
        {
           
            foreach(VistasFiltrosReportes item in VistaReporte.VistasFiltrosReportes.Where(x=>x.DependeDeEtiqueta!=null).Where(x => x.DependeDeEtiqueta != "").ToList())
            {
                object valorparametro = new object();
                Dict.TryGetValue(item.DependeDeEtiqueta, out valorparametro);
                //  var filtro = VistaReporte.VistasFiltrosReportes.Where(x => x.Etiqueta == item.DependeDeEtiqueta).FirstOrDefault();
               
                if (item.Tipo == "COMBO")
                {

                   PropertyCombo propiedad=(PropertyCombo)Properties.Where(x => x.Name == item.Etiqueta).FirstOrDefault();
                    
                    Type type = typeof(ListasFormulario);
                    MethodInfo info = type.GetMethod(item.MetodoLista);
                    int id = Convert.ToInt32(valorparametro.ToString());
                    object[] parametersArray = new object[] { id};
                    this.GetType().GetProperty(item.Lista).SetValue(this, null);
                    info.Invoke(this, parametersArray);
                    IList lstSource = (IList)this.GetType().GetProperty(item.Lista).GetValue(this);

                    //AGREGAR LA OPCION DE TODOS
                    if(lstSource!=null)
                    {
                        if(lstSource.Count>0)
                        {
                            /*Type tipo = lstSource[0].GetType();
                            var objeto = Activator.CreateInstance(tipo);
                            objeto.GetType().GetProperty("Id").SetValue(objeto, 0);
                            objeto.GetType().GetProperty("Nombre").SetValue(objeto, "TODOS");
                            lstSource.Add(objeto);*/
                            propiedad.SourceData = lstSource;
                        }
                        else
                            propiedad.SourceData = null;

                    }
                    else
                    {
                        propiedad.SourceData = null;
                    }
                }
                if (item.Tipo == "LOOKUP")
                {

                    PropertyLookUp propiedad = (PropertyLookUp)Properties.Where(x => x.Name == item.Etiqueta).FirstOrDefault();

                    Type type = typeof(ListasFormulario);
                    MethodInfo info = type.GetMethod(item.MetodoLista);

                    int id = Convert.ToInt32(valorparametro.ToString());
                    object[] parametersArray = new object[] { id };
                    this.GetType().GetProperty(item.Lista).SetValue(this, null);
                    info.Invoke(this, parametersArray);
                    IList lstSource = (IList)this.GetType().GetProperty(item.Lista).GetValue(this);

                    
                    //AGREGAR LA OPCION DE TODOS
                    if (lstSource != null  )
                    {
                        if(lstSource.Count > 0)
                        {
                            propiedad.SourceDataL = null;
                            var Columnas = item.Columnas.Split(',');
                            DataTable table = new DataTable();
                            table = ListToDataTable(lstSource, Columnas);
                            propiedad.SourceDataL = table;
                        }
                        else
                            propiedad.SourceDataL = null;

                    }
                    else
                        propiedad.SourceDataL = null;
                }


            }




        }

        public object Peticion(string Method, string Request, string ContentType, string Accept, Type ResponseType, string URL)
          {

              object result;
              try
              {
                  
                  HttpWebRequest httpWebRequest = WebRequest.Create(requestUrl + URL) as HttpWebRequest;
                  httpWebRequest.Method = Method;
                  httpWebRequest.ContentType = ContentType;
                  httpWebRequest.Accept = Accept;

                  if (!String.IsNullOrEmpty(token))
                      httpWebRequest.Headers.Add("Cookie", token);

                  if (Method == "POST")
                  {
                      byte[] bytes = Encoding.UTF8.GetBytes(Request);
                      Stream requestStream = httpWebRequest.GetRequestStream();
                      requestStream.Write(bytes, 0, bytes.Length);
                      requestStream.Close();
                  }
                  using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                  {
                      if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                      {
                          throw new Exception(string.Format("Server error (HTTP {0}: {1}).", httpWebResponse.StatusCode, httpWebResponse.StatusDescription));
                      }

                      Stream responseStream = httpWebResponse.GetResponseStream();
                      StreamReader streamReader = new StreamReader(responseStream);

                      string text2 = streamReader.ReadToEnd();

                      object obj;
                      if (String.IsNullOrEmpty(token))
                          obj = httpWebResponse.Headers["Set-Cookie"];
                      else
                          obj = JsonConvert.DeserializeObject(text2, ResponseType);

                      result = obj;
                  }
              }
              catch (Exception)
              {
                  throw;
              }
              return result;
          }
      }

      public class MyDictionary : Dictionary<string, object>, ICustomTypeDescriptor
      {

          public AttributeCollection GetAttributes()
          {
              return TypeDescriptor.GetAttributes(this, true);
          }

          string ICustomTypeDescriptor.GetClassName()
          {
              return TypeDescriptor.GetClassName(this, true);
          }

          string ICustomTypeDescriptor.GetComponentName()
          {
              return TypeDescriptor.GetComponentName(this, true);
          }

          TypeConverter ICustomTypeDescriptor.GetConverter()
          {
              return TypeDescriptor.GetConverter(this, true);
          }

          EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
          {
              return TypeDescriptor.GetDefaultEvent(this, true);
          }

          PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
          {
              return TypeDescriptor.GetDefaultProperty(this, true);
          }

          object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
          {
              return TypeDescriptor.GetEditor(this, editorBaseType, true);
          }

          EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
          {
              return TypeDescriptor.GetEvents(attributes, true);
          }

          EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
          {
              return TypeDescriptor.GetEvents(this, true);
          }

          public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
          {
              List<MyDictionaryPropertyDescriptor> properties = new List<MyDictionaryPropertyDescriptor>();
              foreach (string key in this.Keys)
              {
                  properties.Add(new MyDictionaryPropertyDescriptor(key, this));
              }
              return new PropertyDescriptorCollection(properties.ToArray());
          }

          public PropertyDescriptorCollection GetProperties()
          {
              throw new NotImplementedException();
          }

          object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
          {
              return this;
          }
      }


      public class MyDictionaryPropertyDescriptor : PropertyDescriptor
      {
          MyDictionary parent;
          public MyDictionaryPropertyDescriptor(string propertyName, MyDictionary _parent)
              : base(propertyName, null)
          {
              parent = _parent;
          }

          public override bool CanResetValue(object component)
          {
              return true;
          }

          public override bool ShouldSerializeValue(object component)
          {
              return false;
          }

          public override object GetValue(object component)
          {
              return ((MyDictionary)component)[this.Name];
          }

          public override void ResetValue(object component)
          {

          }

          public override void SetValue(object component, object value)
          {
              ((MyDictionary)component)[this.Name] = value;
          }

          public override Type ComponentType
          {
              get { return typeof(MyDictionary); }
          }

          public override Type PropertyType
          {
              get
              {
                  return parent[this.Name].GetType();
              }
          }

          public override bool IsReadOnly
          {
              get { return false; }
          }
      }

      


  }

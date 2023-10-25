using System.ComponentModel;
using System.Reflection;


namespace CaficaERP.Model
{
    public abstract class BaseModel : IDataErrorInfo
    {        
        private bool _canValidate;
       
        public abstract string Validar(string propiedad);

        public long Id { get; set; } 

        public bool CanValidate
        {
            get { return _canValidate; }
            set { _canValidate = value; }
        }

        string IDataErrorInfo.Error
        {
            get
            {
                if (this.CanValidate)
                //if (this.CanValidate)
                {
                    return Errores();
                }
                return string.Empty;
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (this.CanValidate)
                //if (this.CanValidate)
                {
                    //return IDataErrorInfoHelper.GetErrorText(this, columnName);
                    return Validar(columnName);
                }
                return string.Empty;
            }
        }
        public virtual string Errores()
        {
            string error = null;
            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
            {
                error = Validar(propertyInfo.Name);
                if (!string.IsNullOrEmpty(error))
                    //return "Existen campos con errores, favor de corregir";
                    return error;
            }
            return null;
        }
    }
}

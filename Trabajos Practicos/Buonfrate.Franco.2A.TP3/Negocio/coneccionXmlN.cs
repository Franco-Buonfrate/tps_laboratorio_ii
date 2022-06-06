using System;
using System.Data;

namespace Negocio
{
    public class coneccionXmlN 
    {
        public DataTable ConsultaDT( string directorio)
        {

            DataSet dataset = new DataSet();
            dataset.ReadXml();

        }
    }
}

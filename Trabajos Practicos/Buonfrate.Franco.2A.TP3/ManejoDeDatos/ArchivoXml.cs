using System;
using System.IO;
using System.Xml.Serialization;

namespace ManejoDeDatos
{
    public static class ArchivoXml<T>
    {
        static string ruta;

        static ArchivoXml()
        {
            ruta = AppDomain.CurrentDomain.BaseDirectory + @"Datos\";
        }

        public static void Escribir(T datos, string nombreDelArchivo)
        {
            string archivo = ruta + nombreDelArchivo + ".xml";
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                using (StreamWriter streamWriter = new StreamWriter(archivo))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, datos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el archivo ubicado en {archivo}", ex);
            }
        }

        public static T Leer(string nombreDelArchivo)
        {
            string archivo = null;
            T datos = default;

            try
            {
                string[] archivosEnLaRuta = Directory.GetFiles(ruta);
                foreach (string ruta in archivosEnLaRuta)
                {
                    if (ruta.Contains(nombreDelArchivo))
                    {
                        archivo = ruta;
                        break;
                    }
                }

                if (archivo != null)
                {
                    using (StreamReader sr = new StreamReader(archivo))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                        datos = (T)xmlSerializer.Deserialize(sr);
                    }
                }

                return datos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el archivo ubicado en {ruta}", ex);
            }
        }
    }
}

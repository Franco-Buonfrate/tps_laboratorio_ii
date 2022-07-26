using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDeDatos
{
    public static class ArchivoTxt
    {

        static string ruta;

        static ArchivoTxt()
        {
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ruta += @"\Facturas\";
        }

        public static void EscribirTicket(string Articulos, string cliente)
        {
            string nombreArchivo = ruta + "Factura_"+ cliente + "_" + DateTime.Now.ToString("dd-MM-yy(HH,mm,ss)") + ".txt";
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Pintureria REX");
                sb.AppendLine($"Fecha:\n{DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm tt")}");
                sb.AppendLine("-------------------------------------");
                sb.AppendLine("Articulos:");
                sb.AppendLine(Articulos);
                sb.AppendLine("-------------------------------------");
                sb.AppendLine("ticket valido como");
                sb.AppendLine("factura de compra");

                File.WriteAllText(nombreArchivo, sb.ToString());


            }
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo ubicado en {ruta}", e);
            }
        }
    }
}

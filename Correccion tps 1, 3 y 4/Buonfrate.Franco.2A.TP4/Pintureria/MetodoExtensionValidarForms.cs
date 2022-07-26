using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pintureria
{
    public static class MetodoExtensionValidarForms
    {
        /// <summary>
        /// Metodo de extension. Valida que solo se ingrese texto 
        /// </summary>
        /// <param name="frmAValidar"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SoloTexto(this Form frmAValidar ,object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Metodo de extension. Valida que solo se ingrese numero
        /// </summary>
        /// <param name="frmAValidar"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SoloNumero(this Form frmAValidar ,object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}

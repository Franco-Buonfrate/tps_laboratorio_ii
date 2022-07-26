using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Buonfrate.Franco._2A.TP1
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor que inicializa el objeto formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que carga el formulario. Llama al metodo que limpia el formulario. Ademas,
        /// centra el formulario en la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            this.CenterToScreen();
        }

        /// <summary>
        /// Al presionar el boton btnCerrar, muestro un modal al usuario preguntando si en verdad
        /// desea salir de la aplicacion. Si presiona "Sí" se cerrara la calculadora. Si presiona "No",
        /// se cierra el modal y continua la ejecucion del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Al presionar el boton btnConvertirAbinario, instancio un objeto tipo Operando con 
        /// el contenido del label lblResultado para poder llamar al metodo DecimalBinario y realizar
        /// la conversion sistema decimal-binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
        }

        /// <summary>
        /// Al presionar el boton btnConvertirADecimal, instancio un objeto tipo Operando con 
        /// el contenido del label lblResultado para poder llamar al metodo BinarioDecimal y realizar,
        /// si es posible, la conversion sistema binario-decimal        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.BinarioDecimal(this.lblResultado.Text);
        }

        /// <summary>
        /// Llama al metodo Limpiar al hacer click en el boton btnLimpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Al presionar el boton btnOperar realizara la operacion correspondiente (segun el operador
        /// elegido en el ComboBox) de los numeros presentes en los TextBox. Para realizar la operacion
        /// llama al metodo Operar, validando previamente que los numeros en formato string no tengan 
        /// caracteres y validando el operador. Ademas, si el string contiene comas las reemplaza por
        /// puntos. Si todo es correcto, asigno el resultado de la operacion al label lblResultado y la 
        /// operacion perse al ListBox lstOperaciones. Caso contrario, asigno "Valor inválido" al 
        /// label lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = this.txtNumero1.Text;
            string numero2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;

            if (operador == string.Empty)
                operador = "+";

            if (double.TryParse(numero1, out double validator) && double.TryParse(numero2, out validator))
            {
                if (numero1.Contains(','))
                {
                    numero1 = numero1.Replace(',', '.');
                }
                if (numero2.Contains(','))
                {
                    numero2 = numero2.Replace(',', '.');
                }
                this.lblResultado.Text = Operar(numero1, numero2, operador).ToString();
                this.lstOperaciones.Items.Add(numero1 + " " + operador + " " + numero2 + " = " + this.lblResultado.Text);
            }
            else
            {
                this.lblResultado.Text = "Valor Invalido";
            }
        }

        /// <summary>
        /// Realiza la limpieza de los TextBox, ComboBox y Label
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// Crea dos instancias del objeto tipo Operando que seran los operadores y convierte
        /// el operador formato string recibido a char. Llama al metodo Operar de la clase estatica 
        /// Calculadora
        /// </summary>
        /// <param name="numero1">string correspondiente al operando uno</param>
        /// <param name="numero2">string correspondiente al operando dos</param>
        /// <param name="operador">string correspondiente al operador</param>
        /// <returns>Retorna el resultado de la operacion entre ambos numeros</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            
            char operadorAChar = operador.ToCharArray()[0];

            return Calculadora.Operar(num1, num2, operadorAChar);
        }

        /// <summary>
        /// Metodo que muestra una alerta al cerrar el formulario pidiendo confirmacion para cerrarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Seguro que quiere cerrar la calculadora?", "Exit", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        
    }
}

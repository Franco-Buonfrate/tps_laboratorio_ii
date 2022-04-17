using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Sobrecarga del constructor que contempla el caso en el que no se reciben parametros.
        /// Llamo al constructor base inicializando el atributo numero en 0.
        /// </summary>
        public Operando():this(0)
        {
        }

        /// <summary>
        /// Instancia el objeto tipo Operando con un numero double
        /// </summary>
        /// <param name="numero">Numero double</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Sobrecarga del constructor que contempla el caso en el que se recibe un parametro
        /// tipo string. La propiedad Numero se encargara de validar el operando
        /// </summary>
        /// <param name="strNumero">string que pasara por la propiedad para ser evaluado y asignado</param>
        public Operando(string strNumero) : this(double.Parse(strNumero))
        {

        }

        /// <summary>
        /// Realiza, de ser posible, el parseo del string recibido a double
        /// </summary>
        /// <param name="strNumero">string a parsear</param>
        /// <returns>Retorna el numero si se pudo parsear. Caso contrario, retorna 0</returns>
        public double ValidarOperando(string strNumero)
        {
            if (!double.TryParse(strNumero, out double validator))
            {
                validator = 0;
            }
            return validator;
        }

        /// <summary>
        /// Propiedad que inicializa el atributo numero validando previamente
        /// </summary>
        public string Numero
        {
            set
            {
                double numero = this.ValidarOperando(value);
                this.numero = numero;
            }
        }

        /// <summary>
        /// Valida que el string recibido este conformado solamente de caracteres '1' y '0'.
        /// </summary>
        /// <param name="binario">string a validar</param>
        /// <returns>Retorna true si contiene solos '1' y '0' (es binario). Caso contrario,
        /// retorna false
        /// </returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;
            double contador = 1;
            double binarioDouble = double.Parse(binario);
            for (double i = 10; i < Math.Pow(10, binario.Length); i = Math.Pow(10, contador))
            {
                if (binarioDouble % i != Math.Pow(10,contador-1) && binarioDouble % i != 0)
                {
                    retorno = false;
                    break;
                }
                contador++;
                binarioDouble = binarioDouble - (binarioDouble % i);
            }
            return retorno;
        }

        /// <summary>
        /// Realiza, de ser posible, la conversion de binario a decimal
        /// </summary>
        /// <param name="binario">string (binario o no) a convertir a decimal</param>
        /// <returns>Retorna el numero correspondiente en sistema en decimal (formato string)
        /// o "Valor inválido" si no pasa la prueba de ser binario
        /// </returns>
        public static string BinarioDecimal(string binario)
        { 
            int contador = 0;
            int contador2 = 1;
            int acum = 0;
            int largo = binario.ToString().Length;

            if (double.TryParse(binario,out double validator) && EsBinario(binario))
            {
                int numeroEntero = int.Parse(binario);
                for (int i = 10; i <= (int)Math.Pow(10, largo); i = (int)Math.Pow(10, contador2))
                {
                    if ((numeroEntero % i) > 0)
                    {
                        acum += (int)Math.Pow(2, contador);
                        numeroEntero = numeroEntero - (numeroEntero % i);
                    }
                    contador++;
                    contador2++;
                }
                return acum.ToString();
            }
            else
            {
                return "Valor invalido";
            }
        }

        /// <summary>
        /// Realiza la conversion de sistema decimal a binario
        /// </summary>
        /// <param name="numero">Numero a convertir a binario</param>
        /// <returns>Retorna el numero binario correspondiente</returns>
        public static string DecimalBinario(double numero)
        {
            string numeroString = "";

            while (numero >= 2)
            {
                if (numero % 2 > 0)
                {
                    numeroString = "1" + numeroString;
                }
                else
                {
                    numeroString = "0" + numeroString;
                }

                numero = numero / 2;
            }

            if (numero > 0)
            {
                numeroString = "1" + numeroString;
            }

            return numeroString;
        }

        /// <summary>
        /// Sobrecarga del metodo DecimalBinario que contempla el caso en el que el parametro
        /// sea tipo string
        /// </summary>
        /// <param name="numero">string que representa un numero decimal</param>
        /// <returns>Retorna el numero binario correspondiente</returns>
        public static string DecimalBinario(string numero)
        {
            double num;
            string retorno;
            if (double.TryParse(numero, out num))
            {
                retorno = DecimalBinario(num).ToString();
            }
            else
            {
                retorno = "Valor invalido";
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador - para poder realizar una resta entre los atributos numero
        /// del objeto tipo Operando
        /// </summary>
        /// <param name="n1">Primer objeto tipo Operando</param>
        /// <param name="n2">Segundo objeto tipo Operando</param>
        /// <returns>Retorna la resta entre ambos campos</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador * para poder realizar una multiplicacion entre los atributos
        /// numero del objeto tipo Operando
        /// </summary>
        /// <param name="n1">Primer objeto tipo Operando</param>
        /// <param name="n2">Segundo objeto tipo Operando</param>
        /// <returns>Retorna la multiplicacion entre ambos campos</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador + para poder realizar una suma entre los atributos numero
        /// del objeto tipo Operando
        /// </summary>
        /// <param name="n1">Primer objeto tipo Operando</param>
        /// <param name="n2">Segundo objeto tipo Operando</param>
        /// <returns>Retorna la suma entre ambos campos</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador / para poder realizar una division entre los atributos
        /// numero del objeto tipo Operando
        /// </summary>
        /// <param name="n1">Primer objeto tipo Operando</param>
        /// <param name="n2">Segundo objeto tipo Operando</param>
        /// <returns>Si el operando dos es distinto, retorna la division entre ambos campos.
        /// Caso contrario, retorna el menor valor posible para un Double (Double.MinValue)
        /// </returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            
            return n1.numero / n2.numero;
        }

    }
}

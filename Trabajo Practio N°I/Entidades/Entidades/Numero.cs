using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero = double.MinValue;
        /// <summary>
        /// Constructor que asigna el valor de Numero en 0;
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor que recibe un numero en formato double y se lo pasa a SetNumero para asingar el valor al atributo numero
        /// </summary>
        /// <param name="numero"> Numero recibido en formato double para ser seteado en el atributo numero</param>
        public Numero(double numero)
        {
            SetNumero = Convert.ToString(numero);
        }
        /// <summary>
        /// Constructor que recibe un numero en formato string y se lo pasa a SetNumero para asingar el valor al atributo numero
        /// </summary>
        /// <param name="numero">Numero recibido en formato string para ser seteado en el atributo numero</param>
        public Numero(string numero)
        {
            SetNumero = numero;

        }
        /// <summary>
        /// SetNumero setea el value al atributo numero.
        /// </summary>
        public string SetNumero
        {
            set
            {
                numero = Convert.ToDouble(ValidarNumero(value));
            }
        }
        /// <summary>
        ///  comprobará que el valor recibido sea numérico, y lo retornará en formato double. Caso contrario, retornará 0
        /// </summary>
        /// <param name="strNumero">Numero recibido que hay que validar</param>
        /// <returns>numero validado</returns>
        private static double ValidarNumero(string strNumero)
        {
            //Se inicializa el valor de numero en 0.0 y solo se cambiara si la conversion a Double fue correcta, caso
            //contratio retornara 0;
            double numero = 0;

            if (!double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return numero;

            }
        }

        /// <summary>
        /// Metodo que recibe un string con un numeor binario y lo transforma a a un numero del tipo entero
        /// </summary>
        /// <param name="binario">string con el nuevo binario</param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            char[] array = binario.ToCharArray();
            double numero = Convert.ToDouble(binario);
            // Invertido pues los valores van incrementandose de derecha a izquierda: 16-8-4-2-1
            Array.Reverse(array);
            string retorno = "";
            double sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1' && numero >= 0)
                {
                    // Usamos la potencia de 2, según la posición
                    sum += (double)Math.Pow(2, i);
                    retorno = Convert.ToString(sum);
                }
                else if(binario == "0")
                {
                    retorno = "0";
                }
                else
                {
                    retorno = "Valor invalido";
                }
            }
            return retorno;
        }

        /// <summary>
        /// Recibe un numero en formato double y lo convierte a binario
        /// </summary>
        /// <param name="numero">Numero recibido para convertirlo</param>
        /// <returns>Numero convertido o valor invalido si la conversion falla</returns>
        public static string DecimalBinario(double numero)
        {
            //Convierte el double en string para hacer el TryParse a int
            string numerostr = Convert.ToInt32(numero).ToString();
            int num;
            if (Int32.TryParse(numerostr, out num) && num > 0)
            {
                return Convert.ToString(num, 2);
            }
            else
            {
                return "Valor invalido";
            }
        }

        /// <summary>
        /// Recibe un numero decimal en formato string y lo convierte a binario
        /// </summary>
        /// <param name="numero">Numero recibido para convertirlo</param>
        /// <returns>Numero convertido o valor invalido si la conversion falla</returns>
        public static string DecimalBinario(string numero)
        {
            Int64 num = Convert.ToInt64(numero);
            if (numero.All(Char.IsNumber) && num >= 0)
            {
                return Convert.ToString(num, 2);
            }
            else
            { 
                return "Valor invalido";
            }
        }
        
        //SOBRECARGA DEL OPERADOR + PARA PODER PODER SUMAR DOS OBJETOS DEL TIPO NUMERO
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        //SOBRECARGA DEL OPERADOR - PARA PODER PODER RESTAR DOS OBJETOS DEL TIPO NUMERO
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        //SOBRECARGA DEL OPERADOR * PARA PODER PODER MULTIPLICAR DOS OBJETOS DEL TIPO NUMERO
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        //SOBRECARGA DEL OPERADOR / PARA PODER PODER DIVIDIR DOS OBJETOS DEL TIPO NUMERO
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        //SOBRECARGA DEL OPERADOR == PARA PODER PODER COMPARAR DOS OBJETOS DEL TIPO NUMERO
        public static bool operator ==(Numero n1, double numero)
        {
            return n1.numero == numero;
        }

        //SOBRECARGA DEL OPERADOR != PARA PODER PODER COMPARAR DOS OBJETOS DEL TIPO NUMERO
        public static bool operator !=(Numero n1, double numero)
        {
            return n1.numero != numero;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Calculadora
    {
        /// <summary>
        /// Metodo Operar utlizado para realizar los calculos solicitados por el usuario
        /// </summary>
        /// <param name="num1">Numero Uno recibido para operar</param>
        /// <param name="num2">Numero Dos recibido para operar</param>
        /// <param name="operador">Operador a utilizar </param>
        /// <returns>Resultado de la operacion solicitada</returns>
        public static string Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0.0;
            //SE VALIDA EL OPERADOR, SI EL USR PONE CUALQUIER COSA, RETORNA +
            string operadorValidado = ValidarOperador(operador);

            switch (operadorValidado)
            {

                case "+":
                    {//SUMA
                        resultado = num1 + num2;
                        break;
                    }
                case "-":
                    {//RESTA
                        resultado = num1 - num2;
                        break;
                    }
                case "*":
                    {//MULTIPLICACION
                        resultado = num1 * num2;
                        break;
                    }
                case "/":
                    {//DIVISION
                        if (num2 == 0.0) // Se valida que no se divida por 0.
                        {
                            resultado = double.MinValue;
                            break;
                        }
                        else
                        {
                            resultado = num1 / num2;
                            break;
                        }
                    }
            }
            return Convert.ToString(resultado);
        }
        /// <summary>
        /// Metodo Validar Operador utilizado para validar que el operador que ingrese el usuario sea valido
        /// Si no es valido, retornara un +
        /// </summary>
        /// <param name="operador">Operador que hay que validar</param>
        /// <returns>Operador validado</returns>
        private static string ValidarOperador(string operador)
        {
            if(operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }
           
        }
    }
}

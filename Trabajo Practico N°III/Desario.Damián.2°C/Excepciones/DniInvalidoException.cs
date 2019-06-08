using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "DNI invalido";

        public DniInvalidoException() : this(mensajeBase)
        {
           
        }
        public DniInvalidoException(Exception exception) :this(mensajeBase, exception)
        {

        }
        public DniInvalidoException(string message) : this(message,null)
        {

        }
        public DniInvalidoException(string message, Exception exception) : base(message,exception)
        {

        }
    }
}

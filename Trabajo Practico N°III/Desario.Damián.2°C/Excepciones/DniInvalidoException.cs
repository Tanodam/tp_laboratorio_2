using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Preguntar como usar mensajeBase
        /// </summary>
        private string mensajeBase;

        public DniInvalidoException() : this("DNI invalido")
        {
           
        }
        public DniInvalidoException(Exception exception) :this("DNI invalido", exception)
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

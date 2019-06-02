using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException()
        {
           
        }
        public DniInvalidoException(Exception exception)
        {

        }
        public DniInvalidoException(string message)
        {

        }
        public DniInvalidoException(string message, Exception exception)
        {

        }
    }
}

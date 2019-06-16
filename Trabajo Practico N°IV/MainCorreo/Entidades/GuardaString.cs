using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        static StreamWriter archivoGuardar;
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                archivoGuardar = new StreamWriter(archivo, true);
                archivoGuardar.WriteLine(texto);
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                archivoGuardar.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        StreamWriter writer;
        StreamReader reader;
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                writer = new StreamWriter(archivo, true);
                writer.WriteLine(datos);
                writer.Close();
                return true;
            }
            catch (Exception exception)
            {
                writer.Close();
                throw new ArchivosException(exception.InnerException);
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                reader = new StreamReader(archivo, Encoding.UTF8);
                datos = reader.ReadToEnd();
                reader.Close();
                return true;
            }
            catch (Exception exception)
            {
                reader.Close();
                throw new ArchivosException(exception.InnerException);
            }
        }
    }
}

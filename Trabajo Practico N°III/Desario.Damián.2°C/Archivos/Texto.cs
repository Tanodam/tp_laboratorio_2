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
                return true;
            }
            catch (Exception exception)
            {
                throw new ArchivosException(exception.InnerException);
            }
            finally
            {
                //Cierro conexion con el archivo
                writer.Close();
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                reader = new StreamReader(archivo, Encoding.UTF8);
                datos = reader.ReadToEnd();
                return true;
            }
            catch (Exception exception)
            {
                throw new ArchivosException(exception.InnerException);
            }
            finally
            {
                //Cierro conexion con el archivo
                reader.Close();
            }
        }
    }
}

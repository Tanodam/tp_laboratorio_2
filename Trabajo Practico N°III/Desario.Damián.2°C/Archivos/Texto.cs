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
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter writer = new StreamWriter(archivo,true);
            try
            {
                writer.WriteLine(datos);
                writer.Close();
                return true;
            }
            catch(ArchivosException exception)
            {
                writer.Close();
                throw exception.InnerException;
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader reader = new StreamReader(archivo, true);
            try
            {
                datos = reader.ReadToEnd();
                reader.Close();
                return true;
            }
            catch (ArchivosException exception)
            {
                reader.Close();
                throw exception.InnerException;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            //Objeto que escribirá en XML.
            XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
            //Objeto que serializará.
            XmlSerializer objetoSerializador = new XmlSerializer(typeof(T)); /// T es del tipo Universidad.
            try
            {
                //Serializo
                objetoSerializador.Serialize(writer, datos);
                //Cierro conexion con el archivo
                writer.Close();
                return true;
            }
            catch(ArchivosException exception)
            {
                writer.Close();
                throw exception.InnerException;

            }

        }

        public bool Leer(string archivo, out T datos)
        {
            //Objeto que leerá en XML.
            XmlTextReader reader = new XmlTextReader(archivo);
            //Objeto que serializará.
            XmlSerializer objetoDeserializador = new XmlSerializer(typeof(T)); /// T es del tipo Universidad.
            try
            {
                //Deserializo
                datos = (T)objetoDeserializador.Deserialize(reader);
                //Cierro conexion con el archivo
                reader.Close();
                return true;
            }
            catch (ArchivosException exception)
            {
                reader.Close();
                ///preguntar que pasa con el out en este caso.
                throw exception.InnerException;

            }
        }
    }
}

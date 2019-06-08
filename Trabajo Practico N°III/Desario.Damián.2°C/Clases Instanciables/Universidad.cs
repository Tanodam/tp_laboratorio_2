using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    [Serializable]
    public class Universidad
    {
        #region Enumerado Clases
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        #endregion

        #region Atributos
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;
        #endregion

        #region Propiedades
        /// <summary>
        /// Constuctor lista alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad lista profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad lista jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Indexador jornadas
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor de instancia, inicializa todos l
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        /// <summary>
        /// Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores,
        /// Alumnos y Jornadas.
        /// </summary>
        /// <returns></returns>
        public static bool Guardar(Universidad universidad)
        {
            Xml<Universidad> texto = new Xml<Universidad>();
            return texto.Guardar("Universidad.xml", universidad);

        }
        /// <summary>
        /// Leer de clase retornará un Universidad con todos los datos previamente serializados. 
        /// ESTE METODO NO FIGURA EN EL DIAGRAMA DE CLASES
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public static Universidad Leer(Universidad datos)
        {
            Xml<Universidad> import = new Xml<Universidad>();
            Universidad retorno;
            import.Leer("Universidad.xml", out retorno);
            return retorno;
        }
        /// <summary>
        /// Metodo MostrarDatos privado y de clase.
        /// </summary>
        /// <returns></returns>
        private static string MostrarDatos(Universidad universidad)
        {
            StringBuilder datos = new StringBuilder();
            foreach (Jornada jornada in universidad.jornada)
            {
                datos.Append(jornada);
            }
            return datos.ToString();
        }
        /// <summary>
        /// Sobrecarga ==
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            foreach (Alumno alumnito in universidad.alumnos)
            {
                if (alumnito == alumno)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga ==
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return !(universidad == alumno);
        }
        /// <summary>
        /// Sobrecarga ==
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            foreach (Profesor profesorsito in universidad.profesores)
            {
                if (profesorsito == profesor)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga !=
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return !(universidad == profesor);
        }
        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad universidad, EClases clase)
        {
            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor == clase)
                {
                    if (!(object.Equals(profesor, null)))
                    {
                        return profesor;
                    }
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        ///  El distinto retornará el primer Profesor que no pueda 
        /// dar la clase.
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor != clase)
                {
                    return profesor;
                }
            }
            return null;
        }
        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, 
        /// un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman 
        /// (todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, EClases clase)
        {
             Jornada jornadaNueva = new Jornada(clase, (universidad == clase));

            foreach (Alumno alumno in universidad.alumnos)
            {
                if(alumno == clase)
                {
                    //Agrego alumnos a la jornada
                    jornadaNueva.Alumnos.Add(alumno);
                }
            }
            universidad.jornada.Add(jornadaNueva);
            return universidad;
        }
        /// <summary>
        ///Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            if (universidad != profesor)
            {
                universidad.profesores.Add(profesor);
            }

            return universidad;
        }
        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            if (universidad != alumno)
            {
                universidad.alumnos.Add(alumno);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return universidad;
        }
        /// <summary>
        /// Sobrecarga ToString, publicara todos los datos de la universidad a traves del metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion
    }
}

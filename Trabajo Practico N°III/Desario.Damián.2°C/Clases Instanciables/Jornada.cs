using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion
        #region Propiedades
        /// <summary>
        /// Propiedad alumnos
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
        /// Propiedad clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Propiedad Instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Construcot estatico, inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de instacia, inicializa todos los campos con los parametros de entrada
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        /// <summary>
        /// Guardar de clase guardará los datos de la Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// Leer de clase retornará los datos de la Jornada como texto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string textoLeido;
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out textoLeido);
            return textoLeido;
        }
        /// <summary>
        /// Sbrecarga == entre jornada y alumno, una Jornada será igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            foreach (Alumno alumnitos in jornada.alumnos)
            {
                if (alumnitos != jornada.clase)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sbrecarga != entre jornada y alumno
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }
        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente
        ///    cargados.
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if(jornada != alumno)
            {
                jornada.alumnos.Add(alumno);
            }
            return jornada;
        }
        /// <summary>
        /// ToString mostrará todos los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("JORNADA:\nCLASE DE {0} POR {1}", this.Clase, this.instructor.ToString());
            datos.AppendLine("\nALUMNOS: ");

            foreach (Alumno alumnito in this.alumnos)
            {
                datos.Append(alumnito);
            }

            return datos.ToString();
        }
        #endregion
    }
}

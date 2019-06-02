using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones; 

namespace Clases_Instanciables
{
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
        /// Metodo guardaar
        /// </summary>
        /// <returns></returns>
        public bool Guardar()
        {
            return true;
        }
        /// <summary>
        /// Metodo Mostrr Datos
        /// </summary>
        /// <returns></returns>
        private string MostrarDatos()
        {
            return "";
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
        /// Sobrecarga ==
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
        /// Sobrecarga ==
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
        /// Sobrecarga +
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, EClases clase)
        {
            return universidad;
        }
        /// <summary>
        /// Sobrecarga +
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            return universidad;
        }
        /// <summary>
        /// Sobrecarga +
        /// </summary>
        /// <param name="universidad"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            return universidad;
        }
        /// <summary>
        /// Sobrecarga ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion
        #region Metodos
        /// <summary>
        /// Constructor
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
        }
        /// <summary>
        /// Sobrecarga Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }
        /// <summary>
        ///Metodo Mostrar Datos 
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return String.Format("{0}\nLegajo: {1}", base.ToString(), this.legajo);
        }
        /// <summary>
        /// Sobrecarga ==
        /// </summary>
        /// <param name="universitarioUno"></param>
        /// <param name="universitarioDos"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario universitarioUno, Universitario universitarioDos)
        {
            if(universitarioUno.Equals(universitarioDos) || universitarioDos.Equals(universitarioUno) && universitarioUno.legajo == universitarioDos.legajo ||
                universitarioUno.DNI == universitarioDos.DNI)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Sobrecarga  !=
        /// </summary>
        /// <param name="universitarioUno"></param>
        /// <param name="universitarioDos"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario universitarioUno, Universitario universitarioDos)
        {
            return !(universitarioUno == universitarioDos);
        }
        /// <summary>
        /// Metodo participar
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

    }
}

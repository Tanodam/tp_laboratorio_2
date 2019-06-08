using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
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
        /// Constructor de instancia, recibe los datos de un Universitario y se los pasa a la base y ademas 
        /// setea el legajo
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
                      : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Sobrecarga Equals, retorna true si el objeto es del tipo Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }
        /// <summary>
        ///Metodo Mostrar, retorna los datos de la base y agrega el legajo del Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return String.Format("{0}\n\nLEGAJO NÚMERO: {1}", base.ToString(), this.legajo);
        }
        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="universitarioUno"></param>
        /// <param name="universitarioDos"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario universitarioUno, Universitario universitarioDos)
        {
            if ((universitarioUno.legajo == universitarioDos.legajo) || (universitarioUno.DNI == universitarioDos.DNI) &&
                (universitarioUno.Equals(universitarioDos) || universitarioDos.Equals(universitarioUno)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga != entre universitarios
        /// </summary>
        /// <param name="universitarioUno"></param>
        /// <param name="universitarioDos"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario universitarioUno, Universitario universitarioDos)
        {
            return !(universitarioUno == universitarioDos);
        }
        /// <summary>
        /// Metodo participar abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

    }
}

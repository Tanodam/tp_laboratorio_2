using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerado Estado Cuenta
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #endregion
        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion
        #region Metodos
        /// <summary>
        /// Constructor alumno
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Constrcutor Alumno utiliza constructor clase base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id,nombre,apellido,dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constuctor Alumno utiliza constructor de la clase
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Sobrecarga mostrarDatos
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return String.Format("\n{0}\n\nESTADO DE CUENTA: {1}\n{2}\n",
                                  base.MostrarDatos(), this.estadoCuenta, this.ParticiparEnClase());
        }
        /// <summary>
        /// Sobrecarga Participar En Clase
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASE DE {0}", this.claseQueToma);
        }
        /// <summary>
        /// Sobrecarga ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator == (Alumno alumno, Universidad.EClases clase)
        {
            return (alumno.claseQueToma == clase && alumno.estadoCuenta != EEstadoCuenta.Deudor);
        }
        /// <summary>
        /// Sobrecarga !=
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            return (alumno.claseQueToma != clase);
        }
        #endregion
    }
}

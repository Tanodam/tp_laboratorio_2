using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        static Random random;
        #endregion
        #region Meotodos
   
        /// <summary>
        /// constructor profesor
        /// </summary>
        public Profesor()
        {

        }
        /// <summary>
        /// Constructor estatico
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// En el constructor de instancia se inicializará ClasesDelDia y se asignarán dos clases al azar al Profesor
        /// mediante el método randomClases.Las dos clases pueden o no ser la misma.    
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nomrbe"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }
        /// <summary>
        /// 
        /// </summary>
        private void _randomClase()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }
        /// <summary>
        /// Devuelve todos los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.MostrarDatos());
            datos.AppendLine("Clases del dia");
            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                datos.AppendFormat("{0}\n", clases);
            }
            return datos.ToString();
        }
        /// <summary>
        /// Un profesor sera igual a una clase si el mismo dicta la clase.
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {
            return profesor.clasesDelDia.Contains(clase);
        }
        /// <summary>
        /// Sobrecarga !=
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor profesor, Universidad.EClases clase)
        {
            return !(profesor == clase);
        }
        /// <summary>
        /// Sobreescritura ParticiparEnClase
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("Clases del dia");
            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                datos.AppendFormat("{0}\n", clases);
            }
            return datos.ToString();
        }
        /// <summary>
        /// Publica los datos del profesor con el metodo mostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}

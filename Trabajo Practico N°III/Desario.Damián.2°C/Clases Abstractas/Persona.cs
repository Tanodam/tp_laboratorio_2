using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        /// <summary>
        /// Enumerado de las nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        };
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion
        #region Propiedades
        /// <summary>
        /// Propiedad Apellido {get; set;}
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if(ValidarNombreApellido(value) is string)
                {
                    this.apellido = value;
                }
            }
        }
        /// <summary>
        /// Propiedad DNI {get; set;}
        /// </summary>
        public int DNI
        {
            get
            {
                return this.DNI;
            }
            set
            {
                if (ValidarDni(this.nacionalidad, value.ToString()) == 1)
                {
                    this.DNI = value;
                }
            }
        }
        /// <summary>
        /// Propiedad Nacionalidad {get; set;}
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad Nombre {get; set;}
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(ValidarNombreApellido(value) is string)
                {
                     this.nombre = value;
                }
            }
        }
        /// <summary>
        /// Propiedad StringToDNI {get}
        /// </summary>
        public string StringToDNI
        {
            set
            {
                if (ValidarDni(this.nacionalidad, value) == 1)
                {
                    this.DNI = Convert.ToInt32(value);
                }
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Constructor Persona
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nnombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,dni.ToString(),nacionalidad)
        {
        }
        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// Sobrecarga To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Nombre: {0}\nApellido: {1}\nDNI: {2}\nNacionalidad: {3}",
                                 this.Nombre, this.Apellido, this.DNI, this.Nacionalidad);
        }
        /// <summary>
        /// Validar DNI
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 0 && dato <= 89999999)
                    {
                        return 1;
                    }
                    break;
                case ENacionalidad.Extranjero://Extranjero
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        return 1;
                    }
                    break;
            }
            throw new NacionalidadInvalidaException();

        }
        /// <summary>
        /// Validar DNI string
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                ValidarDni(nacionalidad, Convert.ToInt32(dato));
                return 1;
            }
            catch (FormatException exception)
            {
                throw new DniInvalidoException("El DNI no es valido", exception);
            }
        }
        /// <summary>
        /// Validacion nombre apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex match = new Regex(@"^[0-9-]*$");
            if(match.IsMatch(dato))
            {
                return dato;
            }
            return "";

        }

        #endregion

    }
}

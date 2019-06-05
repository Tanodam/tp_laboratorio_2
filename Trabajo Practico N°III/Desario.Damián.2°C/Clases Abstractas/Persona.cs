using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        /// <summary>
        /// Enumerado de las nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
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
                if (ValidarNombreApellido(value) is string)
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
                return this.dni;
            }
            set
            {
                try
                {
                    this.dni = ValidarDni(Nacionalidad, value);
                }
                catch (NacionalidadInvalidaException)
                {
                    throw new NacionalidadInvalidaException();
                }
                catch (DniInvalidoException)
                {
                    throw new DniInvalidoException();
                }
            }
        }
        /// <summary>
        /// Propiedad StringToDNI {set}
        /// </summary>
        public string StringToDNI
        {
            set
            {
                try
                {

                    this.dni = ValidarDni(this.Nacionalidad, value);
                }
                catch (NacionalidadInvalidaException)
                {
                    throw new NacionalidadInvalidaException();
                }
                catch (DniInvalidoException)
                {
                    throw new DniInvalidoException();
                }
                ///Si el DNI no es un INT lanza excepcion DNI invalido
                catch (FormatException)
                {
                    throw new DniInvalidoException();
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
                if (ValidarNombreApellido(value) is string)
                {
                    this.nombre = value;
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
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
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
            return String.Format("NOMBRE COMPLETO: {0}\nNACIONALIDAD: {1}", this.Nombre + ", " + this.Apellido, this.Nacionalidad);
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
                        return dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                case ENacionalidad.Extranjero://Extranjero
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        return dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
            }

            throw new DniInvalidoException();
        }
        /// <summary>
        /// Validar DNI string
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoInt = int.Parse(dato);
            return ValidarDni(nacionalidad, datoInt);
        }
        /// <summary>
        /// Validacion nombre apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex match = new Regex("^[A-Za-z]+$");
            if (match.IsMatch(dato) && dato != "")
            {
                return dato;
            }
            return "";

        }

        #endregion

    }
}

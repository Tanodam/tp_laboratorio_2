using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using Clases_Instanciables;
using System.Text.RegularExpressions;


namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ValidarExcepcionesDni()
        {
            /*Valida que una DNI sea valido y que sea valido para la nacionalidad indicada.
             * Para un Extranjero el DNI debe ser mayor o igual a 90000000 y 
             * menor o igual a 99999999
             * Para un Argentino el DNI debe ser mayor a 0 y menor o igual a
               89999999*/

            //arrange
            Persona profesor;
            //act
            try
            {                /*Variando el numero de dni y nacionalidad se controla el exito del test*/
                profesor = new Profesor(1, "Damian", "Desario", "99999999", Persona.ENacionalidad.Extranjero);
            }
            //Assert
            catch (DniInvalidoException exception)
            {
                Assert.Fail(exception.Message);
            }
            catch (NacionalidadInvalidaException exception)
            {
                Assert.Fail(exception.Message);
            }
        }
        [TestMethod]
        public void ValidarAlumnoRepeditoExeption()
        {
            //Arrange
            Alumno alumnoUno = new Alumno(1, "Juan", "Perez", "39879564", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
            Alumno alumnoDos = new Alumno(1, "Pedro", "Elescamoso", "99154333", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Alumno alumnoTres = new Alumno(3, "Pierre", " Nodoyuna", "42118165", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Universidad universidad = new Universidad();

            try
            {
                //Act
                universidad += alumnoUno;
                universidad += alumnoDos;
                universidad += alumnoTres;
            }
            catch(AlumnoRepetidoException exception)
            {
                //Arrange
                Assert.Fail(exception.Message);
            }
        }
        [TestMethod]
        public void ValidarValorNumerico()
        {
            //Arrange
            string numero = "123456";
            int number;
            //Act y Assert
            Assert.IsTrue(int.TryParse(numero, out number), "No es un numero valido!");
        }
        [TestMethod]
        public void ValidarQueAtributosNoSeanNull()
        {
            //Arrange
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "Pedro", "Elescamoso", "99154333", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, new Profesor(1, "Damian", "Desario", "99999999", Persona.ENacionalidad.Extranjero));
            //Act y Arrange
            ///Validar NULL en universidades
            Assert.IsNotNull(universidad.Alumnos,"La lista de ALUMNOS en UNIVERSIDAD es null");
            Assert.IsNotNull(universidad.Instructores, "La lista de INSTRUCTORES en UNIVERSIDAD es null");
            Assert.IsNotNull(universidad.Jornadas, "La lista de JORNADAS en UNIVERSIDAD es null");
            ///Validar Alumno
            Assert.IsNotNull(alumno.Apellido,"El APELLIDO de ALUMNO es null");
            Assert.IsNotNull(alumno.Nombre, "El NOMBRE de ALUMNO es null");
            ///Validar Jornada
            Assert.IsNotNull(jornada.Instructor, "El instructor en JORNADA es null");
            Assert.IsNotNull(jornada.Alumnos, "La lista de ALUMNOS en JORNADA es null");
        }
    }
}

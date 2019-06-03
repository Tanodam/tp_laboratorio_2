using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using Clases_Instanciables;
using Archivos;


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
             * menor o igual a 99999999*/

            //arrange
            Persona profesor;
            //act
            try
            {                            /*Variando el numero de dnide excepcion se controla el exito del test*/
                profesor = new Profesor(1, "Damian", "Desario", "89999999", Persona.ENacionalidad.Extranjero);
            }
            //assert

            catch (Exception exception)
            {
                Assert.Fail(exception.Message);
            }
        }

        [TestMethod]
        public void ValidarExcepcionesArchivo()
        {
            //arrange
            Texto texto;
            string text;
            //act
            try
            {
                texto = new Texto();
                texto.Leer("C:\\Jornada.txt", out text);
            }
            catch(Exception exception)
            {
                Assert.Fail(exception.Message);
            }
            //assert
        }
    }
}

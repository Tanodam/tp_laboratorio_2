using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        Correo correo = null;
        [TestMethod]
        public void TestListaPaqueteEstaInstanciada()
        {
            correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestNoSePuedenCargarDosPaquetesIguales()
        {
            correo = new Correo();
            Paquete paqueteUno = new Paquete("Emilio Zola 5871", "123aa");
            Paquete paqueteDos = new Paquete("Emilio Zola 5871", "123aa");
            correo += paqueteUno;
            correo += paqueteDos;
        }
    }
}

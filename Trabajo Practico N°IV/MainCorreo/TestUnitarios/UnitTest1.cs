using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListaPaqueteEstaInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
        [TestMethod]
        public void TestNoSePuedenCargarDosPaquetesIguales()
        {
            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("Emilio Zola 5871","123aa");
            Paquete paqueteDos = new Paquete("Emilio Zola 5871", "123bb");
            Assert.IsTrue(paqueteUno != paqueteDos);
        }
    }
}

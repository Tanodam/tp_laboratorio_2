using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum TipoDeLeche
        {
            Entera, Descremada
        };
        private TipoDeLeche tipo;

        /// <summary>
        ///  Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigoDeBarras">Codigo de barras del producto</param>
        /// <param name="colorPrimarioEmpaque">Color del empaque del producto</param>
        public Leche(MarcaDelProducto marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque) : base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
            this.tipo = TipoDeLeche.Entera;
        }
        /// <summary>
        /// Permite asignar un valor distinto a TIPO
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigoDeBarras">Codigo de barras del producto</param>
        /// <param name="colorPrimarioEmpaque">Color del empaque del producto</param>
        public Leche(MarcaDelProducto marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque, TipoDeLeche tipo) : base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        /// <summary>
        /// Modificacion del metodo Mostrar de la clase base, agrega la info de calorias mediante el getter de CantidadCalorias
        /// y el TIPO de leche.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendLine("LECHE");
            datosProducto.AppendLine(base.Mostrar());
            datosProducto.AppendLine("\nCALORIAS: " + this.CantidadCalorias);
            datosProducto.AppendLine("TIPO : " + this.tipo);
            datosProducto.AppendLine("");
            datosProducto.AppendLine("---------------------");

            return datosProducto.ToString();
        }
    }
}

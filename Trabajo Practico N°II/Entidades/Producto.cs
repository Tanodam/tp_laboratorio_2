using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    abstract public class Producto
    {
        public enum MarcaDelProducto
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        private MarcaDelProducto marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// Retornara la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        public Producto(MarcaDelProducto marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque)
        {
            this.marca = marca;
            this.codigoDeBarras = codigoDeBarras;
            this.colorPrimarioEmpaque = colorPrimarioEmpaque;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        /// <summary>
        /// Arma un string builder con todos los datos del producto, es utilizado por Mostrar()
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Producto producto)
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendFormat("CODIGO DE BARRAS: {0}\r\n", producto.codigoDeBarras);
            datosProducto.AppendFormat("MARCA          : {0}\r\n", producto.marca.ToString());
            datosProducto.AppendFormat("COLOR EMPAQUE  : {0}\r\n", producto.colorPrimarioEmpaque.ToString());
            datosProducto.AppendFormat("---------------------");

            return datosProducto.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto producto1, Producto producto2)
        {
            return (producto1.codigoDeBarras == producto2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return (producto1.codigoDeBarras == producto2.codigoDeBarras);
        }
    }
}

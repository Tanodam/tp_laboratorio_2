using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        /// <summary>
        /// Constructor de la clase, utiliza todos los campos de clase base, esta clase no tiene atributos propios
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigoDeBarras">Codigo de barras del producto</param>
        /// <param name="colorPrimarioEmpaque">Color del empaque del producto</param>
        public Snacks(MarcaDelProducto marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque) : base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        /// <summary>
        /// Modificacion del metodo Mostrar de la clase base, agrega la info de calorias mediante el getter de CantidadCalorias
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendLine("SNACKS");
            datosProducto.AppendLine(base.Mostrar());
            datosProducto.AppendLine("\nCALORIAS: " + this.CantidadCalorias);
            datosProducto.AppendLine("");
            datosProducto.AppendLine("---------------------");

            return datosProducto.ToString();
        }
    }
}

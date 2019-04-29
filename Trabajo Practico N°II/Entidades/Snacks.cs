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
        public Snacks(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque) : base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        new protected short CantidadCalorias
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
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("\nCALORIAS: " + this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

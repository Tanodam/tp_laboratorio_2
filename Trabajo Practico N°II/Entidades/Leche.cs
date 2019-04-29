using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public enum ETipo
    {
        Entera,
        Descremada
    };
    public class Leche : Producto
    {
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque) : base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
            this.tipo = ETipo.Entera;
        }
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque, ETipo tipo) : base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("\nCALORIAS: " + this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

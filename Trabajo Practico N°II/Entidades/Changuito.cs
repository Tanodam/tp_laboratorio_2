using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        public enum ETipo
        {
            Dulce,
            Leche,
            Snacks,
            Todos
        };
        List<Producto> productos;
        int espacioDisponible;

        #region "Constructores"
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Changuito c, Changuito.ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();
            int i = (int)tipo;

            Console.WriteLine("-----------------------------------TIPO" + i);
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c.productos)
            {
                if(v is Dulce)
                {
                    Dulce dulce = (Dulce)(v);
                    sb.AppendLine(dulce.Mostrar());
                    
                }
                else if(v is Snacks)
                {
                    Snacks snacks = (Snacks)(v);
                    sb.AppendLine(snacks.Mostrar());
                    
                }
                else if(v is Leche)
                {
                    Leche leche = (Leche)(v);
                    sb.AppendLine(leche.Mostrar());
                    
                }
                //switch (i)
                //{
                //    case 0:
                //        sb.AppendLine(dulce.Mostrar());
                //        Console.WriteLine("entre aca dulce");
                //        break;
                //    case 2:
                //        sb.AppendLine(v.Mostrar());
                //        Console.WriteLine("entre aca snacks");
                //        break;
                //    case 1:
                //        sb.AppendLine(v.Mostrar());
                //        Console.WriteLine("entre aca chele");
                //        break;
                //    default:
                //        sb.AppendLine(v.Mostrar());
                //        Console.WriteLine("entre aca todos");
                //        break;
                //}
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            foreach (Producto v in c.productos)
            {
                if (v == p)
                    return c;
            }

            c.productos.Add(p);
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c.productos)
            {
                if (v == p)
                {
                    c.productos.Remove(v);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}

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
        public enum TipoDeLeche
        {
            Dulce,
            Leche,
            Snacks,
            Todos
        };
        private List<Producto> productos;
        private int espacioDisponible;

        #region "Constructores"
        /// <summary>
        /// Constructor privado que instancia la lista de articulos
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        /// <summary>
        /// Constructor que asigna el espacio disponible y instancia la lista mediante la llamada al constructor privado
        /// </summary>
        /// <param name="espacioDisponible"></param>
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
            return Changuito.Mostrar(this, TipoDeLeche.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="TipoDeLeche">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, Changuito.TipoDeLeche tipo)
        {
            StringBuilder datosProducto = new StringBuilder();
            int i = (int)tipo;

            datosProducto.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            datosProducto.AppendLine("");
            foreach (Producto v in c.productos)
            {
                switch (tipo)
                {
                    case TipoDeLeche.Leche:
                        if (v is Leche)
                        {
                            datosProducto.AppendLine(v.Mostrar());
                        }
                        break;
                    case TipoDeLeche.Snacks:
                        if (v is Snacks)
                        {
                            datosProducto.AppendLine(v.Mostrar());
                        }
                        break;
                    case TipoDeLeche.Dulce:
                        if (v is Dulce)
                        {
                            datosProducto.AppendLine(v.Mostrar());
                        }
                        break;
                    default: //TipoDeLeche.Todos
                        datosProducto.AppendLine(v.Mostrar());
                        break;
                }
            }
            return datosProducto.ToString();
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
            if (c.espacioDisponible > c.productos.Count && !c.productos.Contains(p))
            {
                c.productos.Add(p);
            }

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

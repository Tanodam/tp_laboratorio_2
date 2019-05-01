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
        public enum TipoDeProducto
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
            return Changuito.Mostrar(this, TipoDeProducto.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="changuito">Elemento a exponer</param>
        /// <param name="TipoDeLeche">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito changuito, Changuito.TipoDeProducto tipo)
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", changuito.productos.Count, changuito.espacioDisponible);
            datosProducto.AppendLine("");
            foreach (Producto productoAux in changuito.productos)
            {
                switch (tipo)
                {
                    case TipoDeProducto.Leche:
                        if (productoAux is Leche)
                        {
                            datosProducto.AppendLine(productoAux.Mostrar());
                        }
                        break;
                    case TipoDeProducto.Snacks:
                        if (productoAux is Snacks)
                        {
                            datosProducto.AppendLine(productoAux.Mostrar());
                        }
                        break;
                    case TipoDeProducto.Dulce:
                        if (productoAux is Dulce)
                        {
                            datosProducto.AppendLine(productoAux.Mostrar());
                        }
                        break;
                    default: //TipoDeLeche.Todos
                        datosProducto.AppendLine(productoAux.Mostrar());
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
        /// <param name="changuito">Objeto donde se agregará el elemento</param>
        /// <param name="producto">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito changuito, Producto producto)
        {
            if (changuito.espacioDisponible > changuito.productos.Count && !changuito.productos.Contains(producto))
            {
                changuito.productos.Add(producto);
            }

            return changuito;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="changuito">Objeto donde se quitará el elemento</param>
        /// <param name="producto">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito changuito, Producto producto)
        {
            foreach (Producto productoAux in changuito.productos)
            {
                if (productoAux == producto)
                {
                    changuito.productos.Remove(producto);
                    break;
                }
            }

            return changuito;
        }
        #endregion
    }
}

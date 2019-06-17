using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Propiedades
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Constructor de clase, instancia las listas de Correo.
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        /// <summary>
        /// Metodo que detiene todos los hilos que esten activos
        /// </summary>
        public void FinEntrega()
        {
            foreach (Thread hiloAux in this.mockPaquetes)
            {
                if (hiloAux.IsAlive)
                {
                    hiloAux.Abort();
                }
            }
        }
        /// <summary>
        /// Muestra la informacion de todos los paquetes que hay dentro de Correo.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string datos = "";
            foreach (Paquete p in ((Correo)elementos).Paquetes)
            {
                datos += String.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return datos;
        }

        /// <summary>
        /// Sobrecarga del operador + entre Correo y Paquete
        ///    a. Controlar si el paquete ya está en la lista. En el caso de que esté, 
        ///    se lanzará la excepción TrackingIdRepetidoException.
        ///    b.De no estar repetido, agregar el paquete a la lista de paquetes.
        ///    c.Crear un hilo para el método MockCicloDeVida del paquete, y agregar dicho hilo a mockPaquetes.
        ///    d.Ejecutar el hilo.
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="paquete"></param>
        /// <returns></returns>
        public static Correo operator +(Correo correo, Paquete paquete)
        {
            foreach (Paquete paqueteAux in correo.paquetes)
            {
                if (paqueteAux == paquete)
                {
                    throw new TrackingIdRepetidoException("El paquete ya fue ingresado");
                }
            }
            //Agrego el paquete a la lista
            correo.paquetes.Add(paquete);
            //Instancio el hilo para Mock Ciclo de Vida
            Thread hilo = new Thread(paquete.MockCicloDeVida);
            //Agrego el hilo a la lista de hilos
            correo.mockPaquetes.Add(hilo);
            //Inicio el hilo
            hilo.Start();
            return correo;
        }

        #endregion
    }
}

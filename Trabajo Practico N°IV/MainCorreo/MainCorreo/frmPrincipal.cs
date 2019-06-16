using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class frmPrincipal : System.Windows.Forms.Form
    {
        private Correo correo;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            rtbMostrar.Enabled = false;
            this.correo = new Correo();
        }
        /// <summary>
        /// El evento click del botón btnAgregar realizará las siguientes acciones en el siguiente orden:
        ///     a.Creará un nuevo paquete y asociará al evento InformaEstado el método paq_InformaEstado.
        ///     b.Agregará el paquete al correo, controlando las excepciones que puedan derivar de dicha acción.
        ///     c.Llamará al método ActualizarEstados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //a. Creará un nuevo paquete y asociará al evento InformaEstado el método paq_InformaEstado.
            Paquete paquete = new Paquete(txtBoxDireccion.Text, maskedTxtBoxTracking.Text);
            paquete.InformaEstado += paq_InformaEstado;
            // Asocio el envento InformaException con el metodo InformarExepcion para el manejo de la excepciones
            // ocurridas durante la conexion con SQL
            paquete.InformaException += InformarExcepcion;
            //b. Agregará el paquete al correo, controlando las excepciones que puedan derivar de dicha acción.
            try
            {
                correo += paquete;
                //c. Llamará al método ActualizarEstados.
                this.ActualizarEstado();
            }
            catch (TrackingIdRepetidoException exceptionTracking)
            {
                MessageBox.Show(exceptionTracking.Message + "\nTracking ID:" + paquete.TrackingID, "ALERTA!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// Manejador de eventos que controla el estado del paquete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstado();
            }
        }
        /// <summary>
        /// Manejador de eventos que controla las excepciones producidas por SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InformarExcepcion(object paquete, Exception exception)
        {
            MessageBox.Show("Se ha producido un error en la comunicacion con SQL\n" + exception.Message,
                            "SQL ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// El método ActualizarEstados limpiará los 3 ListBox y luego recorrerá 
        /// la lista de paquetes agregando cada uno de ellos en el listado que corresponda.
        /// </summary>
        private void ActualizarEstado()
        {

            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }
        /// <summary>
        /// Al cerrarse el formulario, se deberá llamar al método FinEntregas a fin de cerrar todos los hilos abiertos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntrega();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// Método MostrarInformacion<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\salida.txt";
            /// El método MostrarInformacion<T> evaluará que el atributo elemento no sea nulo
            if (elemento != null)
            {
                /// a.Mostrará los datos de elemento en el rtbMostrar.
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    /// b.Utilizará el método de extensión para guardar los datos en un archivo llamado salida.txt.
                    GuardaString.Guardar(this.rtbMostrar.Text, rutaArchivo);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "ALERTA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}

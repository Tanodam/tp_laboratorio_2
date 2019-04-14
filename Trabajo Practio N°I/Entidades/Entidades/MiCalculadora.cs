using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Metodo load que inhabilita los botones convertir a binario y convertir a decimal porque si no hay un
        /// resultado valido en el lblResultado, no un numero valido para convertir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiCalculadora_Load(object sender, EventArgs e)
        {
           btnConvertirABinario.Enabled = false;
           btnConvertirADecimal.Enabled = false;

        }
        /// <summary>
        /// El metodo click del btnOperar llama al metodo estatico Operar de la clase FormCalculadora previamente validando
        /// que en los textbox's de los numeros haya algo escrito, si eso es valido, se llama a Form.Calculadora.Operar().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = 0;
            if (txtNumeroUno.Text != "" && txtNumeroDos.Text != "")
            {
                resultado = FormCalculadora.Operar(txtNumeroUno.Text, txtNumeroDos.Text, cbOperador.Text);
                lblResultado.Text = Convert.ToString(resultado);
                //Luego de obtener el resultado se habilitan el boton Convertir de Decimal a Binario
                btnConvertirABinario.Enabled = true;
            }
        }
        /// <summary>
        /// Metodo Operar, recibe los numeros desde los textbox, hace el new correspondiente a cada numero y 
        /// llama Calculadora.Operar() para realizar el calculo y luego devolver el resultado en formato double
        /// </summary>
        /// <param name="numeroUno">Numero Uno leido desde txtNumeroUno.Text</param>
        /// <param name="numeroDos">Numero Dos leido desde txtNumeroDos.Text</param>
        /// <param name="operador">Operador recibido desde el cbOperador.Text</param>
        /// <returns>(double)Resultado<</returns>
        private static double Operar(string numeroUno, string numeroDos, string operador)
        {
            Numero numero1 = new Numero(numeroUno);
            Numero numero2 = new Numero(numeroDos);
            string resultado = Calculadora.Operar(numero1, numero2, operador);
            double resultadoDouble = double.MinValue;
            double retorno = double.MinValue;
            if (double.TryParse(resultado, out resultadoDouble))
            {
                retorno = resultadoDouble;
            }
            return retorno;
        }
        /// <summary>
        /// El metodo Click del btnLimpiar llama a Limpiar() que se encarga de reestablecer los campos a sus valores iniciales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Limpiar se encarga de borrar el contenido de los textbox's, combobox Operador, lblResultado y ademas inhabilita
        /// nuevamente los botones convertirABinario y ConvertirADecimal hasta que el usuario realice algun calculo nuevamente
        /// </summary>
        private void Limpiar()
        {
            txtNumeroUno.Text = "";
            txtNumeroDos.Text = "";
            cbOperador.Text = "";
            lblResultado.Text = "Resultado";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }
        /// <summary>
        /// El metodo click de btnCerrar, llama al metodo .Close de Form para cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// El metodo click del btnConvertiraBinario se encaga de tomar el valor de lblResultado.Text y lo convierte a binario.
        /// De ser un valor invalido, se mostrara en pantalla el error y ademas se inhabilitan los botones convertir a binario y
        /// convertir a decimal. Si el valor es valido entonces se lo muestra en pantalla y ademas se habilita el boton converir 
        /// a Decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            btnConvertirADecimal.Enabled = true;
            //Si el valor en biniario es demasiado grande, se mostrara en un MessageBox
            if (lblResultado.Text.Length > 21)
            {
                MessageBox.Show(lblResultado.Text,"Resultado binario");

            }
            //Si el contenido de lblresultado despues de convetir a binario no es numerico entonces quedaran inhabilitadas las opciones de convertir a binario
            //y convertir a decimal.
            else if (!lblResultado.Text.All(Char.IsNumber))
            {
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = false;
            }
        }
        /// <summary>
        /// Si el metodo convertir a binario fue exitoso entonces estara habilitado para poder convertir de binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string lblBackup = lblResultado.Text;
            this.lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

    }
}

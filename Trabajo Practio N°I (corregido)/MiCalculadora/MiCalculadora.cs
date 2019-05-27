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

namespace MiCalculadora
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
        private void ButtonOperar_Click(object sender, EventArgs e)
        {
            double resultado = 0;
            if (txtBoxNumeroUno.Text != "" && txtBoxNumeroDos.Text != "")
            {
                resultado = FormCalculadora.Operar(txtBoxNumeroUno.Text, txtBoxNumeroDos.Text, comboBoxOperador.Text);
                lblResultado.Text = Convert.ToString(resultado);
                //Luego de obtener el resultado se habilitan el boton Convertir a Binario
                if(lblResultado.Text.Length < 19)
                {
                     btnConvertirABinario.Enabled = true;
                }
            }
        }
        /// <summary>
        /// Metodo Operar, recibe los numeros desde los textbox, hace el new correspondiente a cada numero y 
        /// llama Calculadora.Operar() para realizar el calculo y luego convierte el resultado en un string par
        /// mostrarlo en el lblResultado
        /// </summary>
        /// <param name="numeroUno">Numero Uno leido desde txtNumeroUno.Text</param>
        /// <param name="numeroDos">Numero Dos leido desde txtNumeroDos.Text</param>
        /// <param name="operador">Operador recibido desde el cbOperador.Text</param>
        /// <returns>(double)Resultado<</returns>
        private static double Operar(string numeroUno, string numeroDos, string operador)
        {
            string resultado = Calculadora.Operar(new Numero(numeroUno), new Numero(numeroDos), operador);
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
        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Limpiar se encarga de borrar el contenido de los textbox's, combobox Operador, lblResultado y ademas inhabilita
        /// nuevamente los botones convertirABinario y ConvertirADecimal hasta que el usuario realice algun calculo nuevamente
        /// </summary>
        private void Limpiar()
        {
            txtBoxNumeroUno.Text = "";
            txtBoxNumeroDos.Text = "";
            comboBoxOperador.Text = "";
            lblResultado.Text = "Resultado";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }
        /// <summary>
        /// El metodo click de btnCerrar, llama al metodo .Close de Form para cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCerrar_Click(object sender, EventArgs e)
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
        private void ButtonConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            btnConvertirADecimal.Enabled = true;
            //Se desactiva el boton convertir a binario descartar posibles overflow de variable INT en metodo 
            //Numero.DecimalBinario(double numero)
            btnConvertirABinario.Enabled = false;
            //Si el tamaño del string resultado en biniario es demasiado grande, se mostrara en un MessageBox
            if (lblResultado.Text.Length > 21)
            {
                MessageBox.Show(lblResultado.Text, "Resultado binario",MessageBoxButtons.OK);

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
        /// Metodo click para convertir a decimal, siempre y cuando el convertir a binario haya sido exitoso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            //Se deshabilita el boton convertir a decimal ya que el numero mostrado en el lblresultado ya es un decimal.
            btnConvertirADecimal.Enabled = false;
            //Se habilita hacer la conversion a binario nuevamente.
            btnConvertirABinario.Enabled = true;
        }
    }
}

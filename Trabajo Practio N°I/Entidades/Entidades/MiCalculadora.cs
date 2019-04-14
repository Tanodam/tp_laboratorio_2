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
                //Luego de obtener el resultado se habilitan los botones Convertir de Decimal a Binario y Convertir de binario a Decimal
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = true;
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string lblBackup = lblResultado.Text;
            this.lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            if(!lblResultado.Text.All(Char.IsNumber))
            {
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = false;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string lblBackup = lblResultado.Text;
            this.lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            if(!lblResultado.Text.All(Char.IsNumber))
            {
                lblResultado.Text = lblBackup;
            }
        
        }

    }
}

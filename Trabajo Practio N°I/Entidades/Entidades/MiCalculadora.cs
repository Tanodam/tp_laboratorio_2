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
        private void MiCalculadora_Load(object sender, EventArgs e)
        {
           btnConvertirABinario.Enabled = false;
           btnConvertirADecimal.Enabled = false;

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = 0;
            if (txtNumeroUno.Text != "" && txtNumeroDos.Text != "")
            {
                resultado = FormCalculadora.Operar(txtNumeroUno.Text, txtNumeroDos.Text, cbOperador.Text);
                lblResultado.Text = Convert.ToString(resultado);
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = true;
            }
        }
        private static double Operar(string numeroUno, string numeroDos, string operador)
        {
            Numero numero1 = new Numero(numeroUno);
            Numero numero2 = new Numero(numeroDos);
            string resultado = Calculadora.Operar(numero1, numero2, operador);
            double resultadoDouble = double.MinValue;
            if (double.TryParse(resultado, out resultadoDouble))
            {
                return resultadoDouble;
            }
            else
            {
                return resultadoDouble;
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtNumeroUno.Text = "";
            txtNumeroDos.Text = "";
            cbOperador.Text = "";
            lblResultado.Text = "Resultado";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

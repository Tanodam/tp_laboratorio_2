using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        // Se llama al método operar con el botón.
        private void btnOperar_Click(object sender, EventArgs e)
        {

            double resultado;

            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);

            resultado = Calculadora.operar(numero1, numero2, cmbOperacion.Text);

            lblResultado.Text = resultado.ToString();
        }
    }
}

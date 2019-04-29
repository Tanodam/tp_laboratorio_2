namespace MiCalculadora
{
    partial class FormCalculadora
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxNumeroUno = new System.Windows.Forms.TextBox();
            this.TextBoxNumeroDos = new System.Windows.Forms.TextBox();
            this.ComboBoxOperador = new System.Windows.Forms.ComboBox();
            this.ButtonOperar = new System.Windows.Forms.Button();
            this.ButtonLimpiar = new System.Windows.Forms.Button();
            this.ButtonCerrar = new System.Windows.Forms.Button();
            this.ButtonConvertirABinario = new System.Windows.Forms.Button();
            this.ButttonConvertirADecimal = new System.Windows.Forms.Button();
            this.LabelResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxNumeroUno
            // 
            this.TextBoxNumeroUno.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNumeroUno.Location = new System.Drawing.Point(12, 63);
            this.TextBoxNumeroUno.Name = "TextBoxNumeroUno";
            this.TextBoxNumeroUno.Size = new System.Drawing.Size(100, 40);
            this.TextBoxNumeroUno.TabIndex = 0;
            this.TextBoxNumeroUno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxNumeroDos
            // 
            this.TextBoxNumeroDos.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNumeroDos.Location = new System.Drawing.Point(277, 63);
            this.TextBoxNumeroDos.Name = "TextBoxNumeroDos";
            this.TextBoxNumeroDos.Size = new System.Drawing.Size(100, 40);
            this.TextBoxNumeroDos.TabIndex = 2;
            this.TextBoxNumeroDos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ComboBoxOperador
            // 
            this.ComboBoxOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxOperador.FormattingEnabled = true;
            this.ComboBoxOperador.Items.AddRange(new object[] {
            "/",
            "*",
            "-",
            "+"});
            this.ComboBoxOperador.Location = new System.Drawing.Point(144, 62);
            this.ComboBoxOperador.Name = "ComboBoxOperador";
            this.ComboBoxOperador.Size = new System.Drawing.Size(100, 41);
            this.ComboBoxOperador.TabIndex = 1;
            // 
            // ButtonOperar
            // 
            this.ButtonOperar.Location = new System.Drawing.Point(12, 134);
            this.ButtonOperar.Name = "ButtonOperar";
            this.ButtonOperar.Size = new System.Drawing.Size(100, 39);
            this.ButtonOperar.TabIndex = 3;
            this.ButtonOperar.Text = "Operar";
            this.ButtonOperar.UseVisualStyleBackColor = true;
            this.ButtonOperar.Click += new System.EventHandler(this.ButtonOperar_Click);
            // 
            // ButtonLimpiar
            // 
            this.ButtonLimpiar.Location = new System.Drawing.Point(144, 134);
            this.ButtonLimpiar.Name = "ButtonLimpiar";
            this.ButtonLimpiar.Size = new System.Drawing.Size(100, 39);
            this.ButtonLimpiar.TabIndex = 4;
            this.ButtonLimpiar.Text = "Limpiar";
            this.ButtonLimpiar.UseVisualStyleBackColor = true;
            this.ButtonLimpiar.Click += new System.EventHandler(this.ButtonLimpiar_Click);
            // 
            // ButtonCerrar
            // 
            this.ButtonCerrar.Location = new System.Drawing.Point(278, 134);
            this.ButtonCerrar.Name = "ButtonCerrar";
            this.ButtonCerrar.Size = new System.Drawing.Size(100, 39);
            this.ButtonCerrar.TabIndex = 5;
            this.ButtonCerrar.Text = "Cerrar";
            this.ButtonCerrar.UseVisualStyleBackColor = true;
            this.ButtonCerrar.Click += new System.EventHandler(this.ButtonCerrar_Click);
            // 
            // ButtonConvertirABinario
            // 
            this.ButtonConvertirABinario.Location = new System.Drawing.Point(12, 179);
            this.ButtonConvertirABinario.Name = "ButtonConvertirABinario";
            this.ButtonConvertirABinario.Size = new System.Drawing.Size(183, 39);
            this.ButtonConvertirABinario.TabIndex = 6;
            this.ButtonConvertirABinario.Text = "Convertir a binario";
            this.ButtonConvertirABinario.UseVisualStyleBackColor = true;
            this.ButtonConvertirABinario.Click += new System.EventHandler(this.ButtonConvertirABinario_Click);
            // 
            // ButttonConvertirADecimal
            // 
            this.ButttonConvertirADecimal.Location = new System.Drawing.Point(201, 179);
            this.ButttonConvertirADecimal.Name = "ButttonConvertirADecimal";
            this.ButttonConvertirADecimal.Size = new System.Drawing.Size(176, 39);
            this.ButttonConvertirADecimal.TabIndex = 0;
            this.ButttonConvertirADecimal.Text = "Convertir a decimal";
            this.ButttonConvertirADecimal.UseVisualStyleBackColor = true;
            this.ButttonConvertirADecimal.Click += new System.EventHandler(this.ButtonConvertirADecimal_Click);
            // 
            // LabelResultado
            // 
            this.LabelResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelResultado.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LabelResultado.Location = new System.Drawing.Point(12, 9);
            this.LabelResultado.Name = "LabelResultado";
            this.LabelResultado.Size = new System.Drawing.Size(367, 39);
            this.LabelResultado.TabIndex = 7;
            this.LabelResultado.Text = "Resultado";
            this.LabelResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 234);
            this.Controls.Add(this.LabelResultado);
            this.Controls.Add(this.ButttonConvertirADecimal);
            this.Controls.Add(this.ButtonConvertirABinario);
            this.Controls.Add(this.ButtonCerrar);
            this.Controls.Add(this.ButtonLimpiar);
            this.Controls.Add(this.ButtonOperar);
            this.Controls.Add(this.ComboBoxOperador);
            this.Controls.Add(this.TextBoxNumeroDos);
            this.Controls.Add(this.TextBoxNumeroUno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Damián Desario del curso 2°C";
            this.Load += new System.EventHandler(this.MiCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxNumeroUno;
        private System.Windows.Forms.TextBox TextBoxNumeroDos;
        private System.Windows.Forms.ComboBox ComboBoxOperador;
        private System.Windows.Forms.Button ButtonOperar;
        private System.Windows.Forms.Button ButtonLimpiar;
        private System.Windows.Forms.Button ButtonCerrar;
        private System.Windows.Forms.Button ButtonConvertirABinario;
        private System.Windows.Forms.Button ButttonConvertirADecimal;
        private System.Windows.Forms.Label LabelResultado;
    }
}


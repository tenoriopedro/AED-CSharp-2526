namespace MaqCalcular_v2
{
    partial class fMaqCalcular
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSoma = new Button();
            btnSubtrair = new Button();
            btnMultiplicar = new Button();
            btnDividir = new Button();
            btnSair = new Button();
            lblTitulo = new Label();
            txtBoxNum1 = new TextBox();
            txtBoxNum2 = new TextBox();
            txtBoxResult = new TextBox();
            lblResult = new Label();
            btnLimpar = new Button();
            SuspendLayout();
            // 
            // btnSoma
            // 
            btnSoma.Location = new Point(49, 152);
            btnSoma.Name = "btnSoma";
            btnSoma.Size = new Size(75, 23);
            btnSoma.TabIndex = 0;
            btnSoma.Text = "+";
            btnSoma.UseVisualStyleBackColor = true;
            btnSoma.Click += btnSoma_Click;
            // 
            // btnSubtrair
            // 
            btnSubtrair.Location = new Point(49, 208);
            btnSubtrair.Name = "btnSubtrair";
            btnSubtrair.Size = new Size(75, 23);
            btnSubtrair.TabIndex = 1;
            btnSubtrair.Text = "-";
            btnSubtrair.UseVisualStyleBackColor = true;
            btnSubtrair.Click += btnSubtrair_Click;
            // 
            // btnMultiplicar
            // 
            btnMultiplicar.Location = new Point(49, 269);
            btnMultiplicar.Name = "btnMultiplicar";
            btnMultiplicar.Size = new Size(75, 23);
            btnMultiplicar.TabIndex = 2;
            btnMultiplicar.Text = "*";
            btnMultiplicar.UseVisualStyleBackColor = true;
            btnMultiplicar.Click += btnMultiplicar_Click;
            // 
            // btnDividir
            // 
            btnDividir.Location = new Point(49, 340);
            btnDividir.Name = "btnDividir";
            btnDividir.Size = new Size(75, 23);
            btnDividir.TabIndex = 3;
            btnDividir.Text = "/";
            btnDividir.UseVisualStyleBackColor = true;
            btnDividir.Click += btnDividir_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(417, 388);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(75, 23);
            btnSair.TabIndex = 4;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 30F);
            lblTitulo.Location = new Point(65, 45);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(386, 54);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "Maquina de Calcular";
            // 
            // txtBoxNum1
            // 
            txtBoxNum1.BorderStyle = BorderStyle.FixedSingle;
            txtBoxNum1.Location = new Point(221, 195);
            txtBoxNum1.Name = "txtBoxNum1";
            txtBoxNum1.PlaceholderText = "inserir num1";
            txtBoxNum1.Size = new Size(100, 23);
            txtBoxNum1.TabIndex = 6;
            txtBoxNum1.KeyPress += txtBoxNum1_KeyPress;
            // 
            // txtBoxNum2
            // 
            txtBoxNum2.BorderStyle = BorderStyle.FixedSingle;
            txtBoxNum2.Location = new Point(221, 236);
            txtBoxNum2.Name = "txtBoxNum2";
            txtBoxNum2.PlaceholderText = "inserir num2";
            txtBoxNum2.Size = new Size(100, 23);
            txtBoxNum2.TabIndex = 7;
            // 
            // txtBoxResult
            // 
            txtBoxResult.BorderStyle = BorderStyle.FixedSingle;
            txtBoxResult.Location = new Point(221, 322);
            txtBoxResult.Name = "txtBoxResult";
            txtBoxResult.Size = new Size(100, 23);
            txtBoxResult.TabIndex = 8;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(244, 304);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(59, 15);
            lblResult.TabIndex = 9;
            lblResult.Text = "Resultado";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(376, 195);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 23);
            btnLimpar.TabIndex = 10;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // fMaqCalcular
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 451);
            Controls.Add(btnLimpar);
            Controls.Add(lblResult);
            Controls.Add(txtBoxResult);
            Controls.Add(txtBoxNum2);
            Controls.Add(txtBoxNum1);
            Controls.Add(lblTitulo);
            Controls.Add(btnSair);
            Controls.Add(btnDividir);
            Controls.Add(btnMultiplicar);
            Controls.Add(btnSubtrair);
            Controls.Add(btnSoma);
            Name = "fMaqCalcular";
            Text = "Máquina de Calcular";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSoma;
        private Button btnSubtrair;
        private Button btnMultiplicar;
        private Button btnDividir;
        private Button btnSair;
        private Label lblTitulo;
        private TextBox txtBoxNum1;
        private TextBox txtBoxNum2;
        private TextBox txtBoxResult;
        private Label lblResult;
        private Button btnLimpar;
    }
}

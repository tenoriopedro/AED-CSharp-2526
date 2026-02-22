namespace MaqCalcular_v2
{
    partial class fSegundoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBoxResultForm2 = new TextBox();
            btnSairForm2 = new Button();
            SuspendLayout();
            // 
            // txtBoxResultForm2
            // 
            txtBoxResultForm2.BorderStyle = BorderStyle.FixedSingle;
            txtBoxResultForm2.Font = new Font("Segoe UI", 15F);
            txtBoxResultForm2.Location = new Point(79, 185);
            txtBoxResultForm2.Name = "txtBoxResultForm2";
            txtBoxResultForm2.Size = new Size(240, 34);
            txtBoxResultForm2.TabIndex = 0;
            // 
            // btnSairForm2
            // 
            btnSairForm2.Location = new Point(167, 260);
            btnSairForm2.Name = "btnSairForm2";
            btnSairForm2.Size = new Size(75, 23);
            btnSairForm2.TabIndex = 1;
            btnSairForm2.Text = "Sair";
            btnSairForm2.UseVisualStyleBackColor = true;
            btnSairForm2.Click += btnSairForm2_Click;
            // 
            // fSegundoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 450);
            Controls.Add(btnSairForm2);
            Controls.Add(txtBoxResultForm2);
            Name = "fSegundoForm";
            Text = "fSegundoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxResultForm2;
        private Button btnSairForm2;
    }
}
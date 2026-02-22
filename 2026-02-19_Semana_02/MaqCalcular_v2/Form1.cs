using System.Globalization;

namespace MaqCalcular_v2
{
    public partial class fMaqCalcular : Form
    {
        public fMaqCalcular()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Sair da aplicação
        }

        private void txtBoxNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números (0-9)

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                // Se não for nada disto, bloqueia a tecla
                e.Handled = true;
            }

            // Impede que o utilizador digite mais do que um ponto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSoma_Click(object sender, EventArgs e) => ExecutarOperacao("+");
        private void btnSubtrair_Click(object sender, EventArgs e) => ExecutarOperacao("-");
        private void btnMultiplicar_Click(object sender, EventArgs e) => ExecutarOperacao("*");
        private void btnDividir_Click(object sender, EventArgs e) => ExecutarOperacao("/");

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpa todas as caixas de texto
            txtBoxNum1.Clear();
            txtBoxNum2.Clear();
            txtBoxResult.Clear();

            // Devolve foco para a Primeira Caixa de Texto
            txtBoxNum1.Focus();
        }

        private void ExecutarOperacao(string operacao)
        {
            // 1. Validação de Entrada (Igual para todos)
            bool isNum1Valido = double.TryParse(txtBoxNum1.Text, CultureInfo.InvariantCulture, out double num1);
            bool isNum2Valido = double.TryParse(txtBoxNum2.Text, CultureInfo.InvariantCulture, out double num2);

            if (!isNum1Valido || !isNum2Valido)
            {
                MessageBox.Show("Insira números válidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double resultado = 0;

            // 2. Lógica de Cálculo
            switch (operacao)
            {
                case "+": resultado = num1 + num2; break;
                case "-": resultado = num1 - num2; break;
                case "*": resultado = num1 * num2; break;
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("Divisão por zero!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    resultado = num1 / num2;
                    break;
            }

            // 3. Exibição
            txtBoxResult.Text = resultado.ToString(CultureInfo.InvariantCulture);

            // Passar resultado para fSegundoForm
            fSegundoForm frm2 = new fSegundoForm(txtBoxResult.Text);
            frm2.ShowDialog();

        }
    }
}

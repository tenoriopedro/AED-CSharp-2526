using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaqCalcular_v2
{
    public partial class fSegundoForm : Form
    {
        public fSegundoForm()
        {
            InitializeComponent();
        }
        public fSegundoForm(string sResultadoForm1)
        {
            InitializeComponent();
            txtBoxResultForm2.Text = sResultadoForm1;
        }

        private void btnSairForm2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

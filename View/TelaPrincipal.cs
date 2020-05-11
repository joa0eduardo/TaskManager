using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FrmTelaPrincipal : Form
    {
        public FrmTelaPrincipal()
        {
            InitializeComponent();
        }

        private void FrmTelaPrincipal_Load(object sender, EventArgs e)
        {
            FrmTelaLogin frmTelaLogin = new FrmTelaLogin();

            DialogResult dialogResult = frmTelaLogin.ShowDialog();

            if (dialogResult == DialogResult.Yes)
            {
                frmTelaLogin.Close();
            }

        }
    }
}

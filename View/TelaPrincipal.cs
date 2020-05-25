using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

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
            // TODO: esta linha de código carrega dados na tabela 'taskManagerDataSet.GRUPO_ATIVIDADE'. Você pode movê-la ou removê-la conforme necessário.
            this.gRUPO_ATIVIDADETableAdapter.Fill(this.taskManagerDataSet.GRUPO_ATIVIDADE);
            FrmTelaLogin frmTelaLogin = new FrmTelaLogin();

            DialogResult dialogResult = frmTelaLogin.ShowDialog();

            if (dialogResult == DialogResult.Yes)
            {
                frmTelaLogin.Close();
            }

        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void opcaoUsuario_Click(object sender, EventArgs e)
        {
            FrmUsuarioSelecao frmUsuarioSelecao = new FrmUsuarioSelecao();

            frmUsuarioSelecao.Show();
        }
    }
}

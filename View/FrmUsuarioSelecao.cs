using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controller;

namespace View
{
    public partial class FrmUsuarioSelecao : Form
    {
        public FrmUsuarioSelecao()
        {
            InitializeComponent();

            dataGridUsuario.AutoGenerateColumns = false;
        }

        private void AtualizarGrid()
        {
            UsuarioController usuarioController = new UsuarioController();
            UsuarioColecao usuarioColecao = new UsuarioColecao();

            if (txtCodigo == '')
            {
                usuarioColecao = usuarioController.GridConsultar(0, txtNome.Text, chkAtivo.Checked);
            }
            else
            {
                usuarioColecao = usuarioController.GridConsultar(Convert.ToInt32(txtCodigo.Text), txtNome.Text, chkAtivo.Checked);
            }
            

            dataGridUsuario.DataSource = null;
            dataGridUsuario.DataSource = usuarioColecao;

            dataGridUsuario.Update();
            dataGridUsuario.Refresh();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

    }
}

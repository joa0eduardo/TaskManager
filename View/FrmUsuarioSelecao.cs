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


            usuarioColecao = usuarioController.GridConsultar(txtCodigo.Text, txtNome.Text, chkAtivo.Checked);
            

            dataGridUsuario.DataSource = null;
            dataGridUsuario.DataSource = usuarioColecao;

            dataGridUsuario.Update();
            dataGridUsuario.Refresh();
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            FrmUsuarioCadastro frmUsuarioCadastro = new FrmUsuarioCadastro(Enumerador.Inserir,null);

            DialogResult dialogResult = frmUsuarioCadastro.ShowDialog();

            if (dialogResult == DialogResult.Yes)
            {
                AtualizarGrid();
            }
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            if (dataGridUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum registro selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuarioSelecionado = (dataGridUsuario.SelectedRows[0].DataBoundItem as Usuario);

            FrmUsuarioCadastro frmUsuarioCadastro = new FrmUsuarioCadastro(Enumerador.Consultar, usuarioSelecionado);

            DialogResult dialogResult = frmUsuarioCadastro.ShowDialog();

        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum registro selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuarioSelecionado = (dataGridUsuario.SelectedRows[0].DataBoundItem as Usuario);

            FrmUsuarioCadastro frmUsuarioCadastro = new FrmUsuarioCadastro(Enumerador.Alterar, usuarioSelecionado);

            DialogResult dialogResult = frmUsuarioCadastro.ShowDialog();


            if (dialogResult == DialogResult.Yes)
            {
                AtualizarGrid();
            }
        }
    }
}

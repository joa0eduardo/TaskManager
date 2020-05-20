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
    public partial class FrmUsuarioCadastro : Form
    {

        Enumerador enumeradorSelecionado;

        public FrmUsuarioCadastro(Enumerador enumerador, Usuario usuario)
        {
            InitializeComponent();

            this.enumeradorSelecionado = enumerador;

            if (enumerador.Equals(Enumerador.Inserir))
            {
                this.Text = "Inserir Usuário";

            }
            else if (enumerador.Equals(Enumerador.Alterar))
            {
                this.Text = "Alterar usuário";
                this.lbcodigo.Text = usuario.IdUsuario.ToString();
                this.txtNome.Text = usuario.NomeUsuario.ToString();
                this.txtUsuario.Text = usuario.LoginUsuario;
                this.chkAtivo.Checked = usuario.AtivoUsuario;
                this.chkAdm.Checked = usuario.AmbienteAdmUsuario;

                txtUsuario.Enabled = false;
            }
            else if (enumerador.Equals(Enumerador.Consultar))
            {
                this.Text = "Consultar usuário";
                this.lbcodigo.Text = usuario.IdUsuario.ToString();
                this.txtNome.Text = usuario.NomeUsuario.ToString();
                this.txtUsuario.Text = usuario.LoginUsuario.ToString();
                this.chkAtivo.Checked = usuario.AtivoUsuario;
                this.chkAdm.Checked = usuario.AmbienteAdmUsuario;

                txtUsuario.Enabled = false;
                txtNome.Enabled = false;
                txtSenha.Enabled = false;
                chkAtivo.Enabled = false;
                chkAdm.Enabled = false;
                btSalvar.Visible = false;
                btCancelar.Text = "Fechar";
                btCancelar.Focus();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (enumeradorSelecionado.Equals(Enumerador.Inserir))
            {

                    Usuario usuario = new Usuario();

                    usuario.NomeUsuario = txtNome.Text;
                    usuario.LoginUsuario = txtUsuario.Text;
                    usuario.SenhaUsuario = txtSenha.Text;
                    usuario.AtivoUsuario = chkAtivo.Checked;
                    usuario.AmbienteAdmUsuario = chkAdm.Checked;

                    UsuarioController usuarioController = new UsuarioController();

                    string retorno = usuarioController.Inserir(usuario);

                try
                {
                    int IdUsuario = Convert.ToInt32(retorno);

                    MessageBox.Show("Usuário cadastrado com sucesso. Código:" + IdUsuario.ToString());

                    this.DialogResult = DialogResult.Yes;
                }
                catch (Exception)
                {
                    MessageBox.Show("Não foi possível cadastrar o usuário. Detalhes:" + retorno,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.Yes;
                }
            }
            else if (enumeradorSelecionado.Equals(Enumerador.Alterar))
            {
                Usuario usuario = new Usuario();

                usuario.IdUsuario = Convert.ToInt32(lbcodigo.Text);
                usuario.NomeUsuario = txtNome.Text;
                usuario.LoginUsuario = txtUsuario.Text;
                usuario.SenhaUsuario = txtSenha.Text;
                usuario.AtivoUsuario = chkAtivo.Checked;
                usuario.AmbienteAdmUsuario = chkAdm.Checked;

                UsuarioController usuarioController = new UsuarioController();

                string retorno = usuarioController.Alterar(usuario);

                try
                {
                    int IdUsuario = Convert.ToInt32(retorno);

                    MessageBox.Show("Usuário de código " + IdUsuario.ToString() + " alterado com sucesso." );

                    this.DialogResult = DialogResult.Yes;
                }
                catch (Exception)
                {
                    MessageBox.Show("Não foi possível alterar o usuário. Detalhes:" + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.No;
                }
            }
        }
    }
}

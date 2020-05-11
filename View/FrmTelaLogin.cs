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
    public partial class FrmTelaLogin : Form
    {
        public FrmTelaLogin()
        {
            InitializeComponent();
        }

        private void btAcesso_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.LoginUsuario = TxtUsuario.Text;
            usuario.SenhaUsuario = txtSenha.Text;

            LoginController loginController = new LoginController();

            string retorno = loginController.ValidarUsuario(usuario);

            try
            {
                int retornoValidacao = Convert.ToInt32(retorno);

                if(retornoValidacao.Equals(1))
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

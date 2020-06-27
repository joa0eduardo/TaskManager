using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controller;
using Model;

namespace ViewWPF
{
    /// <summary>
    /// Lógica interna para FrmTelaLogin.xaml
    /// </summary>
    public partial class FrmTelaLogin : Window
    {
        public FrmTelaLogin()
        {
            InitializeComponent();
        }

        private void BtAcessar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioColecao usuarioColecao = new UsuarioColecao();

            usuario.LoginUsuario = txtUsuario.Text;
            usuario.SenhaUsuario = txtSenha.Password;

            LoginController loginController = new LoginController();

            string retorno = loginController.ValidarUsuario(usuario);

            try
            {
                int retornoValidacao = Convert.ToInt32(retorno);

                if (retornoValidacao.Equals(1))
                {

                    this.DialogResult = true;

                }
            }
            catch (Exception)
            {
                MessageBox.Show(retorno, "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

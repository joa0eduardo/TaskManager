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

namespace ViewWPF.Cadastro.Usuario
{
    /// <summary>
    /// Lógica interna para FrmPerfilUsuarioCadastro.xaml
    /// </summary>
    public partial class FrmPerfilUsuarioCadastro : Window
    {
        Enumerador enumeradorSelecionado;

        public FrmPerfilUsuarioCadastro(Enumerador enumerador, PerfilUsuario perfilUsuario)
        {
            InitializeComponent();

            this.enumeradorSelecionado = enumerador;

            if (enumerador.Equals(Enumerador.Inserir))
            {
                this.Title = "Inserir Perfil Usuário";
            }
            else if (enumerador.Equals(Enumerador.Alterar))
            {
                this.Title = "Alterar Perfil Usuário";
                this.lbCodigo.Content = perfilUsuario.IdPerfilUsuario.ToString();
                this.txtNome.Text = perfilUsuario.NomePerfilUsuario.ToString();
                this.chkAtivo.IsChecked = perfilUsuario.AtivoPerfilUsuario;
            }
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNome.Text))
            {
                lbAviso.Content = "* Campos obrigatórios.";

                if (String.IsNullOrEmpty(txtNome.Text))
                {
                    txtNome.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    txtNome.BorderBrush = new SolidColorBrush(Colors.LightGray);
                }
            }
            else
            {
                if (enumeradorSelecionado.Equals(Enumerador.Inserir))
                {

                    PerfilUsuario perfilUsuario = new PerfilUsuario();

                    perfilUsuario.NomePerfilUsuario = txtNome.Text;
                    perfilUsuario.AtivoPerfilUsuario = chkAtivo.IsChecked == true;

                    PerfilUsuarioController perfilUsuarioController = new PerfilUsuarioController();

                    string retorno = perfilUsuarioController.Inserir(perfilUsuario);

                    try
                    {
                        int IdPerfilUsuario = Convert.ToInt32(retorno);

                        MessageBox.Show("Perfil de Usuário cadastrado com sucesso. Código: " + IdPerfilUsuario.ToString());

                        this.DialogResult = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(" Detalhes: " + retorno, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

                        this.DialogResult = true;
                    }
                }
                else if (enumeradorSelecionado.Equals(Enumerador.Alterar))
                {
                    PerfilUsuario perfilUsuario = new PerfilUsuario();

                    perfilUsuario.IdPerfilUsuario = Convert.ToInt32(lbCodigo.Content);
                    perfilUsuario.NomePerfilUsuario = txtNome.Text;
                    perfilUsuario.AtivoPerfilUsuario = chkAtivo.IsChecked == true;

                    PerfilUsuarioController perfilUsuarioController = new PerfilUsuarioController();

                    string retorno = perfilUsuarioController.Alterar(perfilUsuario);

                    try
                    {
                        int IdPerfilUsuario = Convert.ToInt32(retorno);

                        MessageBox.Show("Usuário de código " + IdPerfilUsuario.ToString() + " alterado com sucesso.");

                        this.DialogResult = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(" Detalhes:" + retorno, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

                        this.DialogResult = true;
                    }
                }

            }
        }


        private void BtFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

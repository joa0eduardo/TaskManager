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
using ViewWPF.Cadastro;
using ViewWPF.Cadastro.Usuario;

namespace ViewWPF
{
    /// <summary>
    /// Lógica interna para FrmPerfilUsuarioSelecao.xaml
    /// </summary>
    public partial class FrmPerfilUsuarioSelecao : Window
    {
        public FrmPerfilUsuarioSelecao()
        {
            InitializeComponent();

            dataGridPerfilUsuario.AutoGenerateColumns = false;
        }

        private void AtualizarGrid()
        {
            PerfilUsuarioController perfilUsuarioController = new PerfilUsuarioController();
            PerfilUsuarioColecao perfilUsuarioColecao = new PerfilUsuarioColecao();

            perfilUsuarioColecao = perfilUsuarioController.GridConsultar(txtCodigo.Text, txtNome.Text, chkAtivo.IsChecked == true);

            dataGridPerfilUsuario.ItemsSource = null;
            dataGridPerfilUsuario.ItemsSource = perfilUsuarioColecao;

            dataGridPerfilUsuario.Items.Refresh();
        }

        private void BtLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = "";
            txtNome.Text = "";

            dataGridPerfilUsuario.ItemsSource = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PerfilUsuario perfilUsuarioSelecionado = (dataGridPerfilUsuario.SelectedItems[0] as PerfilUsuario);

            FrmPerfilUsuarioCadastro frmPerfilUsuarioCadastro = new FrmPerfilUsuarioCadastro(Enumerador.Alterar, perfilUsuarioSelecionado);

            bool? dialogResult = frmPerfilUsuarioCadastro.ShowDialog();

            if (dialogResult == true)
            {
                AtualizarGrid();
            }
        }

        private void BtPesquisar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarGrid();
        }

        private void BtInserir_Click(object sender, RoutedEventArgs e)
        {
            FrmPerfilUsuarioCadastro frmPerfilUsuarioCadastro = new FrmPerfilUsuarioCadastro(Enumerador.Inserir,null);

            bool? dialogResult = frmPerfilUsuarioCadastro.ShowDialog();

            if (dialogResult == true)
            {
                AtualizarGrid();
            }
        }

        private void BtFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

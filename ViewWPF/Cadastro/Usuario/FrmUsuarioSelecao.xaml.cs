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
using Model;
using Controller;

namespace ViewWPF
{
    /// <summary>
    /// Lógica interna para FrmUsuarioSelecao.xaml
    /// </summary>
    public partial class FrmUsuarioSelecao : Window
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

            usuarioColecao = usuarioController.GridConsultar(txtCodigo.Text, txtNome.Text, chkAtivo.IsChecked == true);

            dataGridUsuario.ItemsSource = null;
            dataGridUsuario.ItemsSource = usuarioColecao;

            dataGridUsuario.Items.Refresh();
        }

        private void BtFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtPesquisar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarGrid();
        }

        private void BtLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = "";
            txtNome.Text = "";

            dataGridUsuario.ItemsSource = null;
        }

        private void BtInserir_Click(object sender, RoutedEventArgs e)
        {
            FrmUsuarioCadastro frmUsuarioCadastro = new FrmUsuarioCadastro(Enumerador.Inserir, null);

            bool? dialogResult = frmUsuarioCadastro.ShowDialog();

            if (dialogResult == true)
            {
                AtualizarGrid();
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuarioSelecionado = (dataGridUsuario.SelectedItems[0] as Usuario);
            UsuarioController usuarioController = new UsuarioController();

            UsuarioColecao usuarioColecao = new UsuarioColecao();
            
           // usuarioColecao = usuarioController.ConsultarUsuario(usuarioSelecionado.IdUsuario); 

            FrmUsuarioCadastro frmUsuarioCadastro = new FrmUsuarioCadastro(Enumerador.Alterar, usuarioSelecionado);

            bool? dialogResult = frmUsuarioCadastro.ShowDialog();

            if (dialogResult == true)
            {
                AtualizarGrid();
            }

        }
    }
}

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
    }
}

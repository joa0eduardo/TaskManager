﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Controller;

namespace ViewWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*  COMENTADO PARA NÃO PEDIR LOGIN POR ENQUANTO
            FrmTelaLogin frmTelaLogin = new FrmTelaLogin();
            LoginController loginController = new LoginController();

            bool? dialogResult = frmTelaLogin.ShowDialog();

            if (dialogResult == true)
            {
                frmTelaLogin.Close();
            }
            else
            {
                this.Close();
            }*/
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemUsuario_Click(object sender, RoutedEventArgs e)
        {
            FrmUsuarioSelecao frmUsuarioSelecao = new FrmUsuarioSelecao();

            bool? dialogResult = frmUsuarioSelecao.ShowDialog();

            if (dialogResult == true)
            {
                frmUsuarioSelecao.Close();
            }
        }

        private void MenuItemPerfil_Click(object sender, RoutedEventArgs e)
        {
            FrmPerfilUsuarioSelecao frmPerfilUsuarioSelecao = new FrmPerfilUsuarioSelecao();

            bool? dialogResult = frmPerfilUsuarioSelecao.ShowDialog();

            if (dialogResult == true)
            {
                frmPerfilUsuarioSelecao.Close();
            }
        }
    }
}

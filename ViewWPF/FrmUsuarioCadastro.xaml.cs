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
using System.Windows.Shapes;
using Model;
using Controller;

namespace ViewWPF
{
    /// <summary>
    /// Lógica interna para FrmUsuarioCadastro.xaml
    /// </summary>
    public partial class FrmUsuarioCadastro : Window
    {
        Enumerador enumeradorSelecionado;

        public FrmUsuarioCadastro(Enumerador enumerador, Usuario usuario)
        {
            InitializeComponent();

            this.enumeradorSelecionado = enumerador;

            if (enumerador.Equals(Enumerador.Inserir))
            {
                this.Title = "Inserir Usuário";
            }
            else if (enumerador.Equals(Enumerador.Alterar))
            {
                this.Title = "Alterar usuário";
                this.lbCodigo.Content = usuario.IdUsuario.ToString();
                this.txtNome.Text = usuario.NomeUsuario.ToString();
                this.txtLogin.Text = usuario.LoginUsuario;
                this.chkAtivo.IsChecked = usuario.AtivoUsuario;

                txtLogin.IsEnabled = false;
            }
            else if ((enumerador.Equals(Enumerador.Consultar)))
            {
                this.Title = "Consultar usuário";
                this.lbCodigo.Content = usuario.IdUsuario.ToString();
                this.txtNome.Text = usuario.NomeUsuario.ToString();
                this.txtLogin.Text = usuario.LoginUsuario;
                this.chkAtivo.IsChecked = usuario.AtivoUsuario;

                txtNome.IsEnabled = false;
                txtLogin.IsEnabled = false;
                chkAtivo.IsEnabled = false;
            }

        }

        private void BtFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(txtNome.Text) 
                || String.IsNullOrEmpty(txtSenha.Password) 
                || String.IsNullOrEmpty(txtLogin.Text)
                || String.IsNullOrEmpty(cmbPerfil.SelectedValue.ToString()))
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

                if (String.IsNullOrEmpty(txtSenha.Password))
                {
                    txtSenha.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    txtSenha.BorderBrush = new SolidColorBrush(Colors.LightGray);
                }

                if (String.IsNullOrEmpty(txtLogin.Text))
                {
                    txtLogin.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    txtLogin.BorderBrush = new SolidColorBrush(Colors.LightGray);
                }

               if (cmbPerfil.SelectedItem == null)
                {
                    lbPerfil.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    lbPerfil.Foreground = new SolidColorBrush(Colors.Black);
                }

            }
            else
            {
                if (enumeradorSelecionado.Equals(Enumerador.Inserir))
                {

                    Usuario usuario = new Usuario();
                    usuario.PerfilUsuario = new PerfilUsuario();

                    usuario.NomeUsuario = txtNome.Text;
                    usuario.LoginUsuario = txtLogin.Text;
                    usuario.SenhaUsuario = txtSenha.Password;
                    usuario.AtivoUsuario = chkAtivo.IsChecked == true;
                    usuario.PerfilUsuario.IdPerfilUsuario = Convert.ToInt32(cmbPerfil.SelectedValue);

                    UsuarioController usuarioController = new UsuarioController();

                    string retorno = usuarioController.Inserir(usuario);

                    try
                    {
                        int IdUsuario = Convert.ToInt32(retorno);

                        MessageBox.Show("Usuário cadastrado com sucesso. Código: " + IdUsuario.ToString());

                        this.DialogResult = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Não foi possível cadastrar o usuário. Detalhes:" + retorno, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

                        this.DialogResult = true;
                    }
                }
                else if (enumeradorSelecionado.Equals(Enumerador.Alterar))
                {
                    Usuario usuario = new Usuario();
                    PerfilUsuario perfilUsuario = new PerfilUsuario();

                    usuario.NomeUsuario = txtNome.Text;
                    usuario.LoginUsuario = txtLogin.Text;
                    usuario.SenhaUsuario = txtSenha.Password;
                    usuario.AtivoUsuario = chkAtivo.IsChecked == true;
                    perfilUsuario.IdPerfilUsuario = Convert.ToInt32(cmbPerfil.SelectedValue);

                    UsuarioController usuarioController = new UsuarioController();

                    string retorno = usuarioController.Alterar(usuario);

                    try
                    {
                        int IdUsuario = Convert.ToInt32(retorno);

                        MessageBox.Show("Usuário de código " + IdUsuario.ToString() + " alterado com sucesso.");

                        this.DialogResult = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Não foi possível alterar o usuário. Detalhes:" + retorno, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

                        this.DialogResult = true;
                    }
                }

            }
        }

        private void CmbPerfil_Loaded(object sender, RoutedEventArgs e)
        {
            PerfilUsuarioColecao perfilUsuarioColecao = new PerfilUsuarioColecao();
            PerfilUsuarioController perfilUsuarioController = new PerfilUsuarioController();

            if (cmbPerfil.SelectedValue == null)
            {
                perfilUsuarioColecao = perfilUsuarioController.ComboBoxConsultar(true);

                cmbPerfil.ItemsSource = null;
                cmbPerfil.ItemsSource = perfilUsuarioColecao;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPerfil.SelectedItem == null)
            {
                MessageBox.Show("0");
            }
            else
            {
                MessageBox.Show(cmbPerfil.SelectedValue.ToString());
            }
        }
    }
}
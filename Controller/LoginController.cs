using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionFactory;
using Model;
using System.Data;

namespace Controller
{
    public class LoginController
    {
        SQLServer sqlServer = new SQLServer();

        public string ValidarUsuario(Usuario usuario)
        {
            try
            {
                sqlServer.LimparParametros();
                sqlServer.AdicionarParametros("@USU_Login", usuario.LoginUsuario);
                sqlServer.AdicionarParametros("@USU_Senha", usuario.SenhaUsuario);
                string UsuarioValido = sqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "USUARIO_LOGAR").ToString();

                return UsuarioValido;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Usuario DadosUsuarioLogado (string login)
        {
            try
            {
                Usuario usuario = new Usuario();

                sqlServer.LimparParametros();
                sqlServer.AdicionarParametros("@USU_Login", login);

                DataSet dataTableUsuarioLogado = sqlServer.BuscarDados(CommandType.StoredProcedure, "USUARIO_LOGADO_CONSULTAR");

                usuario.IdUsuario = Convert.ToInt32("USU_Tid");
                usuario.NomeUsuario = Convert.ToString("USU_Nome");
                usuario.PerfilUsuario.IdPerfilUsuario = Convert.ToInt32("USU_PFU_TidPerfilUsuario");

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível verificar os dados do usuário. Detalhes: " + ex.Message);
            }
        }
    }
}

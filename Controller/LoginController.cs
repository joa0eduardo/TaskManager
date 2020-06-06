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

        public UsuarioColecao DadosUsuarioLogado (string login)
        {
            try
            {
                UsuarioColecao usuarioColecao = new UsuarioColecao();

                sqlServer.LimparParametros();
                sqlServer.AdicionarParametros("@USU_Login", login);

                DataTable dataTableUsuarioLogado = sqlServer.ExecutarConsulta(CommandType.StoredProcedure, "USUARIO_LOGADO_CONSULTAR");

                foreach (DataRow linha in dataTableUsuarioLogado.Rows)
                {
                    Usuario usuario = new Usuario();

                    usuario.IdUsuario = Convert.ToInt32(linha["USU_Tid"]);
                    usuario.NomeUsuario = Convert.ToString(linha["USU_Nome"]);
                    usuario.LoginUsuario = Convert.ToString(linha["USU_Login"]);

                    usuarioColecao.Add(usuario);
                }

                return usuarioColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível verificar os dados do usuário. Detalhes: " + ex.Message);
            }
        }
    }
}

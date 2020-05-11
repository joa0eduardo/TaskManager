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
    }
}

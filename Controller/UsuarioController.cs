using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ConnectionFactory;
using System.Data;

namespace Controller
{
    public class UsuarioController
    {
        SQLServer sQLServer = new SQLServer();

        public string Inserir(Usuario usuario)
        {
            try
            {
                sQLServer.LimparParametros();
                sQLServer.AdicionarParametros("@USU_Nome", usuario.NomeUsuario);
                sQLServer.AdicionarParametros("@USU_Login", usuario.LoginUsuario);
                sQLServer.AdicionarParametros("@USU_Senha", usuario.SenhaUsuario);
                sQLServer.AdicionarParametros("@USU_Ativo", usuario.AtivoUsuario);
                sQLServer.AdicionarParametros("@USU_AmbienteAdministrativo", usuario.AmbienteAdmUsuario);
                string IdUsuario = sQLServer.ExecutarManipulacao(CommandType.StoredProcedure, "USUARIO_INSERIR").ToString();
                return IdUsuario;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(Usuario usuario)
        {
            try
            {
                sQLServer.LimparParametros();
                sQLServer.AdicionarParametros("@USU_Tid", usuario.IdUsuario);
                sQLServer.AdicionarParametros("@USU_Nome", usuario.NomeUsuario);
                sQLServer.AdicionarParametros("@USU_Login", usuario.LoginUsuario);
                sQLServer.AdicionarParametros("@USU_Senha", usuario.SenhaUsuario);
                sQLServer.AdicionarParametros("@USU_Ativo", usuario.AtivoUsuario);
                sQLServer.AdicionarParametros("@USU_AmbienteAdministrativo", usuario.AmbienteAdmUsuario);
                string IdUsuario = sQLServer.ExecutarManipulacao(CommandType.StoredProcedure, "USUARIO_INSERIR").ToString();
                return IdUsuario;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public UsuarioColecao GridConsultar(int id, string usuario, bool ativo )
        {
            try
            {

                UsuarioColecao usuarioColecao = new UsuarioColecao();

                sQLServer.LimparParametros();
                sQLServer.AdicionarParametros("@USU_Tid", id);
                sQLServer.AdicionarParametros("@USU_Nome", usuario);
                sQLServer.AdicionarParametros("@USU_Ativo", ativo);

                DataTable dataTableUsuario = sQLServer.ExecutarConsulta(CommandType.StoredProcedure, "USUARIO_GRID_CONSULTAR");

                foreach (DataRow linha in dataTableUsuario.Rows)
                {
                    Usuario usu = new Usuario();

                    usu.IdUsuario = Convert.ToInt32(linha["USU_Tid"]);
                    usu.NomeUsuario = Convert.ToString(linha["USU_Nome"]);
                    usu.AtivoUsuario = Convert.ToBoolean(linha["USU_Ativo"]);
                    usu.AmbienteAdmUsuario = Convert.ToBoolean(linha["USU_AmbienteAdministrativo"]);

                    usuarioColecao.Add(usu);
                }

                return usuarioColecao;

            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível consultar os usuários. Detalhes:" + ex.Message);
            }

        }
 
    }
}

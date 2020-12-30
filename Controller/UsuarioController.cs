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
                sQLServer.AdicionarParametros("@USU_PFU_TidPerfilUsuario", usuario.PerfilUsuario.IdPerfilUsuario);
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
            PerfilUsuario perfilUsuario = new PerfilUsuario();
            try
            {
                sQLServer.LimparParametros();
                sQLServer.AdicionarParametros("@USU_Tid", usuario.IdUsuario);
                sQLServer.AdicionarParametros("@USU_Nome", usuario.NomeUsuario);
                sQLServer.AdicionarParametros("@USU_Login", usuario.LoginUsuario);
                sQLServer.AdicionarParametros("@USU_Senha", usuario.SenhaUsuario);
                sQLServer.AdicionarParametros("@USU_Ativo", usuario.AtivoUsuario);
                sQLServer.AdicionarParametros("@USU_PFU_TidPerfilUsuario", usuario.PerfilUsuario.IdPerfilUsuario);
                string IdUsuario = sQLServer.ExecutarManipulacao(CommandType.StoredProcedure, "USUARIO_ALTERAR").ToString();
                return IdUsuario;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public UsuarioColecao GridConsultar(string id, string usuario, bool ativo )
        {
            try
            {

                UsuarioColecao usuarioColecao = new UsuarioColecao();

                sQLServer.LimparParametros();
                if (String.IsNullOrEmpty(id) == false)
                {
                    sQLServer.AdicionarParametros("@USU_Tid", id);
                }

                if (String.IsNullOrEmpty(usuario) == false)
                {
                    sQLServer.AdicionarParametros("@USU_Nome", usuario);
                }
                sQLServer.AdicionarParametros("@USU_Ativo", ativo);

                DataTable dataTableUsuario = sQLServer.ExecutarConsulta(CommandType.StoredProcedure, "USUARIO_GRID_CONSULTAR");

                foreach (DataRow linha in dataTableUsuario.Rows)
                {
                    Usuario usu = new Usuario();
                    usu.PerfilUsuario = new PerfilUsuario();

                    usu.IdUsuario = Convert.ToInt32(linha["USU_Tid"]);
                    usu.NomeUsuario = Convert.ToString(linha["USU_Nome"]);
                    usu.LoginUsuario = Convert.ToString(linha["USU_Login"]);
                    usu.AtivoUsuario = Convert.ToBoolean(linha["USU_Ativo"]);
                    usu.PerfilUsuario.NomePerfilUsuario = Convert.ToString(linha["PFU_Nome"]);

                    usuarioColecao.Add(usu);
                }

                return usuarioColecao;

            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível consultar os usuários. Detalhes:" + ex.Message);
            }

        }

        public UsuarioColecao ConsultarUsuario(int id)
        {
            try
            {

                UsuarioColecao usuarioColecao = new Usuario();

                sQLServer.AdicionarParametros("@USU_Tid", id);
                sQLServer.AdicionarParametros("@USU_Ativo", true);

                DataTable dataTableUsuario = sQLServer.ExecutarConsulta(CommandType.StoredProcedure, "USUARIO_CONSULTAR");

                Usuario usuario = new Usuario();
 
                usuario.PerfilUsuario = new PerfilUsuario();

                for (int i = 0; i < dataTableUsuario.Rows.Count; i++)
                {
                    usuario.IdUsuario = Convert.ToInt32("USU_Tid");
                    usuario.NomeUsuario = Convert.ToString("USU_Nome");
                    usuario.LoginUsuario = Convert.ToString("USU_Login");
                    usuario.AtivoUsuario = Convert.ToBoolean("USU_Ativo");
                    usuario.PerfilUsuario.IdPerfilUsuario = Convert.ToInt32("USU_PFU_TidPerfilUsuario");

                    usuarioColecao.Add(usuario);
                }

                return usuarioColecao;

            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível consultar os usuários. Detalhes: " + ex.Message);
            }
        }
 
    }
}

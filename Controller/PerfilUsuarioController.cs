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
    public class PerfilUsuarioController
    {
        SQLServer sQLServer = new SQLServer();

        public string Inserir(PerfilUsuario perfilUsuario)
        {
            try
            {
                sQLServer.LimparParametros();
                sQLServer.AdicionarParametros("@PFU_Nome", perfilUsuario.NomePerfilUsuario);
                sQLServer.AdicionarParametros("@PFU_Ativo", perfilUsuario.AtivoPerfilUsuario);
                string IdUsuario = sQLServer.ExecutarManipulacao(CommandType.StoredProcedure, "PERFIL_USUARIO_INSERIR").ToString();
                return IdUsuario;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(PerfilUsuario perfilUsuario)
        {
            try
            {
                sQLServer.LimparParametros();
                sQLServer.AdicionarParametros("@PFU_Tid", perfilUsuario.IdPerfilUsuario);
                sQLServer.AdicionarParametros("@PFU_Nome", perfilUsuario.NomePerfilUsuario);
                sQLServer.AdicionarParametros("@PFU_Ativo", perfilUsuario.AtivoPerfilUsuario);
                string IdUsuario = sQLServer.ExecutarManipulacao(CommandType.StoredProcedure, "PERFIL_USUARIO_ALTERAR").ToString();
                return IdUsuario;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public PerfilUsuarioColecao GridConsultar(string id, string nome, bool ativo)
        {
            try
            {
                PerfilUsuarioColecao perfilUsuarioColecao = new PerfilUsuarioColecao();

                sQLServer.LimparParametros();

                if (String.IsNullOrEmpty(id) == false)
                {
                    sQLServer.AdicionarParametros("@PFU_Tid", id);
                }

                if (String.IsNullOrEmpty(nome) == false)
                {
                    sQLServer.AdicionarParametros("@PFU_Nome", nome);
                }

                sQLServer.AdicionarParametros("PFU_Ativo", ativo);

                DataTable dataTablePerfilUsuario = sQLServer.ExecutarConsulta(CommandType.StoredProcedure, "PERFIL_USUARIO_CONSULTAR");

                foreach (DataRow linha in dataTablePerfilUsuario.Rows)
                {
                    PerfilUsuario perfilUsuario = new PerfilUsuario();

                    perfilUsuario.IdPerfilUsuario = Convert.ToInt32(linha["PFU_Tid"]);
                    perfilUsuario.NomePerfilUsuario = Convert.ToString(linha["PFU_Nome"]);
                    perfilUsuario.AtivoPerfilUsuario = Convert.ToBoolean(linha["PFU_Ativo"]);

                    perfilUsuarioColecao.Add(perfilUsuario);
                }

                return perfilUsuarioColecao;

            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível consultar os perfis de usuários. Detalhes:" + ex.Message);
            }
        }

        public PerfilUsuarioColecao ComboBoxConsultar (bool ativo)
        {
            try
            {
                PerfilUsuarioColecao perfilUsuarioColecao = new PerfilUsuarioColecao();

                sQLServer.LimparParametros();

                sQLServer.AdicionarParametros("PFU_Ativo", ativo);

                DataTable dataTablePerfilUsuario = sQLServer.ExecutarConsulta(CommandType.StoredProcedure, "PERFIL_USUARIO_CONSULTAR");

                foreach (DataRow linha in dataTablePerfilUsuario.Rows)
                {
                    PerfilUsuario perfilUsuario = new PerfilUsuario();

                    perfilUsuario.IdPerfilUsuario = Convert.ToInt32(linha["PFU_Tid"]);
                    perfilUsuario.NomePerfilUsuario = Convert.ToString(linha["PFU_Nome"]);

                    perfilUsuarioColecao.Add(perfilUsuario);
                }

                return perfilUsuarioColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os perfis de usuários. Detalhes:" + ex.Message);
            }
        }
    }
}

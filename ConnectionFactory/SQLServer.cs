using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ConnectionFactory.Properties;

namespace ConnectionFactory
{
    public class SQLServer
    {
        // Criar a conexão
        private SqlConnection CreateConnection()
        {
            return new SqlConnection(Settings.Default.stringConnection);
        }

        // Parâmetros que vão para o banco
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string paramaterName, object parameterValue)
        {
            sqlParameterCollection.Add(new SqlParameter(paramaterName, parameterValue));
        }

        // Persistência - Inserir, Alterar, Excluir
        public object ExecutarManipulacao(CommandType commandType, string StoredProcedureOrSQLText)
        {
            try
            {
                // Cria a conexão
                SqlConnection sqlConnection = CreateConnection();
                // Abre a conexão
                sqlConnection.Open();
                // Criar o comando que vai levar a informação para o banco
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                // Colocando coisas dentro do comando (dentro da caixa que vai criar a conexão)
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = StoredProcedureOrSQLText;
                sqlCommand.CommandTimeout = 7200; // Em segundos;

                // Adicionar os parâmetros no comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                // Executar o comando, ou seja, mandar o comando ir até o banco de dados
                return sqlCommand.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // Consultar Registros no banco de dados
        public DataTable ExecutarConsulta(CommandType commandType, string StoredProcedureOrSQLText)
        {
            try
            {
                // Cria a conexão
                SqlConnection sqlConnection = CreateConnection();
                // Abre a conexão
                sqlConnection.Open();
                // Criar o comando que vai levar a informação para o banco
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                // Colocando coisas dentro do comando (dentro da caixa que vai criar a conexão)
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = StoredProcedureOrSQLText;
                sqlCommand.CommandTimeout = 7200; // Em segundos;

                // Adicionar os parâmetros no comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                // Criar um adaptador
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // DataTable = Tabela de Dados vazia onde vou colocar os dados que vem do banco
                DataTable dataTable = new DataTable();

                // Mandar o comando ir até o banco buscar os dados e o adaptador preencher o datatable 
                sqlDataAdapter.Fill(dataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet BuscarDados(CommandType commandType, string StoredProcedureOrSQLText)
        {
            try
            {
                // Cria a conexão
                SqlConnection sqlConnection = CreateConnection();
                // Abre a conexão
                sqlConnection.Open();
                // Criar o comando que vai levar a informação para o banco
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                // Colocando coisas dentro do comando (dentro da caixa que vai criar a conexão)
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = StoredProcedureOrSQLText;
                sqlCommand.CommandTimeout = 7200; // Em segundos;

                // Adicionar os parâmetros no comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                DataSet dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet);

                return dataSet;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
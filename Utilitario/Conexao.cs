using System;
using MySql.Data.MySqlClient;

namespace CRUD.Utilitario
{
    internal class Conexao
    {       
        private static MySqlConnection _conexao;

        public static MySqlConnection conexao;

        public static MySqlConnection Conectar()
        {
            try
            {
                string strconexao = "server=localhost;port=3306;uid=root;pwd=root;database=BD_Floricultura";
                conexao = new MySqlConnection(strconexao);
                conexao.Open();
                return conexao;
                
            }
            catch (Exception ex)
            {

                throw new Exception("erro ao conectar" + ex.Message);
            }
            
        }
        public static void FecharConexao()
        {
            conexao.Clone();
        }
    }
}
using CRUD.Mapeamento;
using CRUD.Utilitario;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using Mysqlx.Expect;
using Mysqlx.Cursor;


namespace CRUD.DAO
{
    internal class FuncionariosDAO
    {
        public void Insert(Funcionarios funcionario)
        {
            try
            {
                string sql = "INSERT INTO funcionarios (_Nome, _CPF, _DataNascimento, _Endereco, _Telefone, _Sexo) " +
                             "VALUES (@_Nome, @_CPF, @_DataNascimento, @_Endereco, @_Telefone, @_Sexo)";

                using (MySqlConnection conexao = Conexao.Conectar())
                {
                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@_Nome", funcionario._Nome);
                        comando.Parameters.AddWithValue("@_CPF", funcionario._CPF);
                        comando.Parameters.AddWithValue("@_DataNascimento", funcionario._DataNascimento);
                        comando.Parameters.AddWithValue("@_Endereco", funcionario._Endereco);
                        comando.Parameters.AddWithValue("@_Telefone", funcionario._Telefone);
                        comando.Parameters.AddWithValue("@_Sexo", funcionario._Sexo);

                        comando.ExecuteNonQuery();
                        Console.WriteLine("\nFuncionário cadastrado com sucesso.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no DAO ao cadastrar funcionário: {ex.Message}");
                throw;
            }
        }

        public void DeletarFuncionario(int _id_Funcionario)
        {
            MySqlConnection conexao = null;
            try
            {
                conexao = Conexao.Conectar();
                if (conexao == null) return;

                string sql = "DELETE FROM Funcionarios WHERE _Id_Funcionarios = @_Id_Funcionarios";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@_id_Funcionarios", _id_Funcionario);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Funcionário deletado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Nenhum funcionário encontrado com o ID especificado.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao deletar funcionário: " + ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }
                       

        public void Update(Funcionarios funcionario)
        {
            try
            {
                string sql = "UPDATE funcionarios SET _Nome = @_Nome, _CPF = @_CPF, _DataNascimento = @_DataNascimento, " +
                             "_Endereco = @_Endereco, _Telefone = @_Telefone, _Sexo = @_Sexo " +
                             "WHERE _Id_Funcionarios = @_Id_Funcionarios";

                using (MySqlConnection conexao = Conexao.Conectar())
                {
                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@_Id_Funcionarios", funcionario._Id_Funcionarios);
                        comando.Parameters.AddWithValue("@_Nome", funcionario._Nome);
                        comando.Parameters.AddWithValue("@_CPF", funcionario._CPF);
                        comando.Parameters.AddWithValue("@_DataNascimento", funcionario._DataNascimento);
                        comando.Parameters.AddWithValue("@_Endereco", funcionario._Endereco);
                        comando.Parameters.AddWithValue("@_Telefone", funcionario._Telefone);
                        comando.Parameters.AddWithValue("@_Sexo", funcionario._Sexo);

                        int rowsAffected = comando.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\n-- Funcionário atualizado com sucesso --");
                        }
                        else
                        {
                            Console.WriteLine("\n-- Nenhum funcionário encontrado com o ID fornecido --");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no DAO ao atualizar funcionário: {ex.Message}");
                throw;
            }
        }

        public List<Funcionarios> List()
        {
            List<Funcionarios> funcionariosList = new List<Funcionarios>();

            try
            {
                var sql = "SELECT _Id_Funcionarios, _Nome, _CPF, _DataNascimento, _Endereco, _Telefone, _Sexo " +
                          "FROM funcionarios ORDER BY _Nome";

                using (MySqlConnection conexao = Conexao.Conectar())
                {
                    using (MySqlCommand command = new MySqlCommand(sql, conexao))
                    {
                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Funcionarios funcionario = new Funcionarios();

                                funcionario._Id_Funcionarios = dr.GetInt32("_Id_Funcionarios"); // <-- Corrigido
                                funcionario._Nome = dr.GetString("_Nome");
                                funcionario._CPF = dr.GetString("_CPF");
                                funcionario._DataNascimento = dr.GetDateTime("_DataNascimento");
                                funcionario._Endereco = dr.GetString("_Endereco");
                                funcionario._Telefone = dr.GetString("_Telefone");
                                funcionario._Sexo = dr.GetString("_Sexo");

                                funcionariosList.Add(funcionario);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no DAO ao listar funcionários: {ex.Message}");
                throw;
            }

            return funcionariosList;
        }
    }
}
using CRUD.DAO;
using CRUD.Mapeamento;
using CRUD.Utilitario;
using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int opcao;
        do
        {
            Console.WriteLine(">>> Menu Cadastro Funcionários <<<");
            Console.WriteLine("");
            Console.WriteLine("1 - Cadastrar Funcionário");
            Console.WriteLine("2 - Listar Funcionários");
            Console.WriteLine("3 - Atualizar Funcionário");
            Console.WriteLine("4 - Deletar Funcionário");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                opcao = -1;
            }

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("");
                    CadastrarFuncionario();
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    ListarFuncionarios();
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    AtualizarFuncionario();
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("");
                    DeletarFuncionario();
                    Console.WriteLine("");
                    break;
                case 0:
                    Console.WriteLine("");
                    Console.WriteLine("Saindo...");
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.WriteLine("");
                    break;
            }

        } while (opcao != 0);
    }

    static void CadastrarFuncionario()
    {
        try
        {
            Funcionarios f1 = new Funcionarios();

            Console.Write("Nome: ");
            f1._Nome = Console.ReadLine();

            Console.Write("CPF: ");
            f1._CPF = Console.ReadLine();

            Console.Write("Data de Nascimento (DD/MM/AAAA): ");
            f1._DataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Endereço: ");
            f1._Endereco = Console.ReadLine();

            Console.Write("Telefone: ");
            f1._Telefone = Console.ReadLine();

            Console.Write("Sexo (M/F): ");
            f1._Sexo = Console.ReadLine();

            FuncionariosDAO cadastroFuncionario = new FuncionariosDAO();
            cadastroFuncionario.Insert(f1);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro de formato na entrada. Certifique-se de usar o formato correto para Data de Nascimento.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar funcionário: {ex.Message}");
        }
    }

    static void ListarFuncionarios()
    {
        try
        {
            FuncionariosDAO cadastroFuncionario = new FuncionariosDAO();
            List<Funcionarios> funcionarios = cadastroFuncionario.List();

            if (funcionarios == null || funcionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
                return;
            }

            Console.WriteLine("--- Lista de Funcionários ---");
            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"ID: {funcionario._Id_Funcionarios}, Nome: {funcionario._Nome}, CPF: {funcionario._CPF}, " +
                                  $"Data Nasc.: {funcionario._DataNascimento.ToShortDateString()}, Endereço: {funcionario._Endereco}, " +
                                  $"Telefone: {funcionario._Telefone}, Sexo: {funcionario._Sexo}");
            }
            Console.WriteLine("-----------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao listar funcionários: {ex.Message}");
        }
    }

    static void AtualizarFuncionario()
    {
        try
        {
            Funcionarios funcionario = new Funcionarios();

            Console.Write("ID do Funcionário a ser atualizado: ");
            if (!int.TryParse(Console.ReadLine(), out int _id_Funcionario))
            {
                Console.WriteLine("ID inválido. Por favor, digite um número.");
                return;
            }
            funcionario._Id_Funcionarios = _id_Funcionario;

            Console.Write("Novo Nome: ");
            funcionario._Nome = Console.ReadLine();

            Console.Write("Novo CPF: ");
            funcionario._CPF = Console.ReadLine();

            Console.Write("Nova Data de Nascimento (DD/MM/AAAA): ");
            funcionario._DataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Novo Endereço: ");
            funcionario._Endereco = Console.ReadLine();

            Console.Write("Novo Telefone: ");
            funcionario._Telefone = Console.ReadLine();

            Console.Write("Novo Sexo (M/F): ");
            funcionario._Sexo = Console.ReadLine();

            FuncionariosDAO cadastroFuncionario = new FuncionariosDAO();
            cadastroFuncionario.Update(funcionario);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro de formato na entrada. Certifique-se de usar o formato correto para ID e Data de Nascimento.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar funcionário: {ex.Message}");
        }
    }
    static void DeletarFuncionario()
    {
        try
        {
            Console.Write("Digite o ID do funcionário a ser deletado: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            new FuncionariosDAO().DeletarFuncionario(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao deletar funcionário: {ex.Message}");
        }
    }
}

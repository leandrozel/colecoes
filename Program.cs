using System;
using System.Collections.Generic;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    public class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();

        static void Main(string[] args)
        {
            CriarLista();
            ExibirLista();
            DetalharData();
            CalcularDescontoINSS();
             ObterPorNome();
            ObterFuncionariosRecentes();
            ObterEstatisticas();
            ObterPorTipo();

        }



        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "===============================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += "===============================\n";
            }
            Console.WriteLine(dados);
        }

        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Roger Guedes";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }
        public static void ValidarFuncionario(Funcionario f)
        {
            if (f.Salario <= 0)
            {
                Console.WriteLine($"Erro: O salário do funcionário {f.Nome} não pode ser 0 ou negativo.");
                return;
            }

            if (f.DataAdmissao > DateTime.Today)
            {
                Console.WriteLine($"Erro: A data de admissão do funcionário {f.Nome} não pode ser no futuro.");
                return;
            }

            if (f.Nome.Length < 2)
            {
                Console.WriteLine($"Erro: O nome do funcionário deve ter no mínimo 2 caracteres.");
                return;
            }

            lista.Add(f);
        }

        public static void DetalharData()
        {
            Console.Write("Digite uma data (dd/MM/yyyy): ");
            string dataDigitada = Console.ReadLine();

            if (DateTime.TryParse(dataDigitada, out DateTime dataConvertida))
            {
                Console.WriteLine("O dia da semana é: " + dataConvertida.ToString("dddd"));
                Console.WriteLine("O nome do mês é: " + dataConvertida.ToString("MMMM"));

                if (dataConvertida.DayOfWeek == DayOfWeek.Sunday)
                {
                    Console.WriteLine("Hora atual: " + DateTime.Now.ToString("HH:mm"));
                }
            }
            else
            {
                Console.WriteLine("Data inválida. Por favor, digite no formato dd/MM/yyyy.");
            }
        }

        public static void CalcularDescontoINSS()
        {
            Console.WriteLine("Digite o seu salário");
            if (decimal.TryParse(Console.ReadLine(), out decimal salario))
            {
                decimal descontoINSS = 0;

                if (salario <= 1212.00M)
                {
                    descontoINSS = salario * 0.075M;
                }
                else if (salario <= 2327.35M)
                {
                    descontoINSS = salario * 0.09M;
                }
                else if (salario <= 3641.03M)
                {
                    descontoINSS = salario * 0.12M;
                }
                else if (salario <= 7087.22M)
                {
                    descontoINSS = salario * 0.14M;
                }
                else
                {
                    descontoINSS = 7087.22M * 0.14M;
                }

                decimal salarioliquido = salario - descontoINSS;

                Console.WriteLine($"O valor do INSS a ser pago é: {descontoINSS:c2}");
                Console.WriteLine($"O valor do salário descontado do INSS é: {salarioliquido:c2}");
            }
            else
            {
                Console.WriteLine("Valor de salário inválido. Por favor, digite um número.");
            }
        }
         public static void ObterPorNome()
        {
            Console.Write("Digite o nome do funcionário: ");
            string nomeBuscado = Console.ReadLine();

            Funcionario funcionarioEncontrado = lista.Find(f => f.Nome.Equals(nomeBuscado, StringComparison.OrdinalIgnoreCase));

            if (funcionarioEncontrado != null)
            {
                string dados = "===============================\n";
                dados += string.Format("Id: {0} \n", funcionarioEncontrado.Id);
                dados += string.Format("Nome: {0} \n", funcionarioEncontrado.Nome);
                dados += string.Format("CPF: {0} \n", funcionarioEncontrado.Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", funcionarioEncontrado.DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", funcionarioEncontrado.Salario);
                dados += string.Format("Tipo: {0} \n", funcionarioEncontrado.TipoFuncionario);
                dados += "===============================\n";
                Console.WriteLine(dados);
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }

        public static void ObterFuncionariosRecentes()
        {
            lista.RemoveAll(f => f.Id < 4);
            List<Funcionario> listaOrdenada = lista.OrderByDescending(f => f.Salario).ToList();

            Console.WriteLine("\n--- Funcionários recentes (Id >= 4) em ordem decrescente de salário ---\n");
            string dados = "";
            foreach (var funcionario in listaOrdenada)
            {
                dados += "===============================\n";
                dados += string.Format("Id: {0} \n", funcionario.Id);
                dados += string.Format("Nome: {0} \n", funcionario.Nome);
                dados += string.Format("CPF: {0} \n", funcionario.Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", funcionario.DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", funcionario.Salario);
                dados += string.Format("Tipo: {0} \n", funcionario.TipoFuncionario);
                dados += "===============================\n";
            }
            Console.WriteLine(dados);
        }

        public static void ObterEstatisticas()
        {
            Console.WriteLine("\n--- Estatísticas de Funcionários ---");
            Console.WriteLine($"Quantidade de funcionários: {lista.Count}");
            decimal somaSalarios = lista.Sum(f => f.Salario);
            Console.WriteLine($"Somatório dos salários: {somaSalarios:c2}");
        }

        public static void ObterPorTipo()
        {
            Console.WriteLine("\nSelecione o tipo de funcionário:");
            Console.WriteLine("1 - CLT");
            Console.WriteLine("2 - Aprendiz");
            Console.Write("Digite o número correspondente: ");

            if (int.TryParse(Console.ReadLine(), out int tipoDigitado))
            {
                TipoFuncionarioEnum tipoSelecionado = (TipoFuncionarioEnum)tipoDigitado;
                List<Funcionario> listaFiltrada = lista.FindAll(f => f.TipoFuncionario == tipoSelecionado);

                Console.WriteLine($"\n--- Lista de Funcionários do tipo {tipoSelecionado} ---");
                if (listaFiltrada.Count > 0)
                {
                    foreach (var funcionario in listaFiltrada)
                    {
                        Console.WriteLine("===============================");
                        Console.WriteLine($"Id: {funcionario.Id}");
                        Console.WriteLine($"Nome: {funcionario.Nome}");
                        Console.WriteLine($"Salário: {funcionario.Salario:c2}");
                        Console.WriteLine("===============================");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum funcionário encontrado para o tipo selecionado.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, digite 1 ou 2.");
            }
        }
    }
}











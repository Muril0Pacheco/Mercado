using System;
using System.Threading;
using System.Collections.Generic;


namespace teste
{
    class Program
    {
        static string user_verificar, senha_verificar;

        static string[] produtos_limpeza = { "Detergente", "Bucha", "Agua Sanitaria 1L" };
        static decimal[] precos_limpeza = { 2.90m, 2.00m, 7.50m };
        static string[] produtos_alimentos = { "Arroz 5KG", "Feijao 1KG", "Macarrao 500g" };
        static decimal[] precos_alimentos = { 15.50m, 5.50m, 7.50m };
        static string[] produtos_carnes = { "Carne bovina", "Frango", "Linguica" };
        static decimal[] precos_carnes = { 9.50m, 7.40m, 5.50m };

        static string user_cadastro, senha_cadastro;
        static string endereco_municipio, endereco_cidade, endereco_rua, endereco_complemento;
        static UInt16 endereco_numero;

        static List<string> produtosEscolhidos = new List<string>();
        static decimal valor_carrinho;

        static void Main()
        {
            Menu();
            //Menu_setores()
        }

        static void Menu()
        {
            Console.Clear();

            uint opcao = 0;

            Console.WriteLine("Seja Bem-vindo(a)");
            Console.WriteLine("-----------------");
            try
            {
                Console.WriteLine("1 - Fazer Login\n2 - Cadastro\n3 - Sair");
                Console.Write("\n->");
                opcao = Convert.ToUInt16(Console.ReadLine());
            }

            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Algo de inesperado aconteceu.\nRetornando ao menu inicial");
                Thread.Sleep(1600);
                Menu();
            }

            if (opcao == 1)
            {
                Entrar();
            }

            if (opcao == 2)
            {
                Cadastro_user();
            }

            if (opcao == 3)
            {
                Console.WriteLine("\nSaindo...");
                Environment.Exit(0);
                Thread.Sleep(1000);
            }

            else
            {
                Console.WriteLine("Digite uma opcao valida!");
                Thread.Sleep(1300);
                Menu();
            }
        }

        static void Entrar()
        {
            Console.Clear();

            string user = string.Empty, senha = string.Empty;

            Console.WriteLine("Login");
            Console.WriteLine("---------------------");

            try
            {
                Console.Write("Digite seu usuario: ");
                user = Console.ReadLine();

                Console.Write("Digite sua senha: ");
                senha = Console.ReadLine();
            }

            catch (Exception)
            {
                Console.WriteLine("Algo de inesperado aconteceu, retornando ao menu inicial");
                Entrar();
            }

            if (user.CompareTo(user_verificar) == 0 && senha.CompareTo(senha_verificar) == 0)
            {
                Menu_setores();
            }

            else
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("\nAcesso Negado!\nUsuário ou senha não encontrados.\nVocê pode realizar o cadastro indo ao menu inicial.");
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu();
            }

            Console.Clear();
        }

        static void Cadastro_user()
        {
            Console.Clear();

            Console.WriteLine("Cadastro");
            Console.WriteLine("---------------------");
            try
            {
                Console.Write("Crie um usuário (10 caracteres no máximo): ");
                user_cadastro = Console.ReadLine();

                if (user_cadastro.Length > 10)
                {
                    Console.WriteLine("\nSeu usuário pode conter no máximo 10 caracteres");
                    Thread.Sleep(1300);
                    Cadastro_user();
                }

                Console.Write("Crie uma senha (6 caracteres no mínimo): ");
                senha_cadastro = Console.ReadLine();

                if (senha_cadastro.Length < 6)
                {
                    Console.WriteLine("\nSua senha deve conter no mínimo 6 caracteres!");
                    Thread.Sleep(1000);
                    Cadastro_user();
                }

                user_verificar = user_cadastro;
                senha_verificar = senha_cadastro;

                Console.WriteLine("---------------------");
                Console.Write("Digite sua cidade: ");
                endereco_cidade = Console.ReadLine();
                Console.Write("Digite seu município: ");
                endereco_municipio = Console.ReadLine();
                Console.Write("Digite o nome de sua rua: ");
                endereco_rua = Console.ReadLine();
                Console.Write("Digite o complemento: ");
                endereco_complemento = Console.ReadLine();
                solicitar_numero_residencia();
            }

            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Algo de inesperado aconteceu.\nRetornando ao menu inicial.");
                Thread.Sleep(1600);
                Menu();
            }
        }

        static void solicitar_numero_residencia()
        {
            try
            {
                Console.Write("Digite o número da sua residência: ");
                endereco_numero = Convert.ToUInt16(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("Digite apenas números!\n");              
                solicitar_numero_residencia();
            }

            pos_cadastro();
        }

        static void pos_cadastro()
        {
            UInt16 opcao_user = 0;

            try
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Selecione uma opção:\n1 - Refazer Cadastro\n2 - Login\n3 - Sair ");
                Console.Write("\n-> ");
                opcao_user = UInt16.Parse(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("Digite apenas números!");
                Thread.Sleep(1300);
                pos_cadastro();
            }

            switch (opcao_user)
            {
                case 1:
                    Cadastro_user();
                    break;

                case 2:
                    Entrar();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Aplicação encerrada!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\nDigite uma opção válida!");
                    Thread.Sleep(1300);
                    pos_cadastro();
                    break;
            }
        }

        static void Menu_setores()
        {
            UInt16 opcao_setor = 0;

            try
            {

                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Valor do seu carrinho: " + "R$" + valor_carrinho);
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Escolha um setor: ");
                Console.WriteLine("1 - Limpeza\n2 - Alimentos\n3 - Carnes\n-----------------------------\n4 - Pagar\n5 - Menu Inicial\n6 - Sair");
                Console.Write("\n-> ");
                opcao_setor = Convert.ToUInt16(Console.ReadLine());

                switch (opcao_setor)
                {
                    case 1:
                        Menu_limpeza();
                        break;

                    case 2:
                        Menu_alimentos();
                        break;

                    case 3:
                        Menu_carnes();
                        break;

                    case 4:
                        if (valor_carrinho == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Nenhum produto adicionado!");
                            Console.WriteLine("Retornando para o menu de setores...");
                            Thread.Sleep(1000);
                            Menu_setores();
                        }
                        else
                        {
                            Pagamento();
                        }
                        break;

                    case 5:
                        Menu();
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("Aplicação encerrada!");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Digite uma opção válida!\nRetornando ao menu de setores...");
                        Thread.Sleep(1000);
                        Menu_setores();
                        break;
                }
            }

            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Algo de inesperado aconteceu.\nRetornando ao Menu de setores.");
                Thread.Sleep(1000);
                Menu_setores();
            }
        }

        static void Menu_limpeza()
        {
            Console.Clear();

            UInt16 opcao_produto = 0;

            try
            {
                Console.WriteLine($"0 - {produtos_limpeza[0]} " + "R$" + precos_limpeza[0]);
                Console.WriteLine($"1 - {produtos_limpeza[1]} " + "R$" + precos_limpeza[1]);
                Console.WriteLine($"2 - {produtos_limpeza[2]} " + "R$" + precos_limpeza[2]);
                Console.WriteLine("-------------------------");
                Console.WriteLine("3 - Voltar ao menu\n");

                Console.Write("-> ");

                opcao_produto = Convert.ToUInt16(Console.ReadLine());

                if (opcao_produto == 3)
                {
                    Menu_setores();
                }

                valor_carrinho += precos_limpeza[opcao_produto];
                produtosEscolhidos.Add(produtos_limpeza[opcao_produto] + " R$ " + precos_limpeza[opcao_produto]);

                adicionar_ou_pagar();
            }

            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Algo de inesperado aconteceu.\nRetornando ao menu limpeza");
                Thread.Sleep(1600);
                Menu_limpeza();
            }

        }

        static void Menu_alimentos()
        {
            Console.Clear();

            UInt16 opcao_produto = 0;

            try
            {
                Console.WriteLine($"0 - {produtos_alimentos[0]} " + "R$" + precos_alimentos[0]);
                Console.WriteLine($"1 - {produtos_alimentos[1]} " + "R$" + precos_alimentos[1]);
                Console.WriteLine($"2 - {produtos_alimentos[2]} " + "R$" + precos_alimentos[2]);
                Console.WriteLine("-------------------------");
                Console.WriteLine("3 - Voltar ao menu\n");

                Console.Write("-> ");

                opcao_produto = Convert.ToUInt16(Console.ReadLine());

                if (opcao_produto == 3)
                {
                    Menu_setores();
                }

                valor_carrinho += precos_alimentos[opcao_produto];
                produtosEscolhidos.Add(produtos_alimentos[opcao_produto] + " R$ " + precos_alimentos[opcao_produto]);
                adicionar_ou_pagar();
            }

            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Algo de inesperado aconteceu.\nRetornando ao menu de alimentos");
                Thread.Sleep(1600);
                Menu_alimentos();
            }
        }

        static void Menu_carnes()
        {
            Console.Clear();

            UInt16 opcao_produto = 0;

            try
            {
                Console.WriteLine($"0 - {produtos_carnes[0]} " + "R$" + precos_carnes[0]);
                Console.WriteLine($"1 - {produtos_carnes[1]} " + "R$" + precos_carnes[1]);
                Console.WriteLine($"2 - {produtos_carnes[2]} " + "R$" + precos_carnes[2]);
                Console.WriteLine("-------------------------");
                Console.WriteLine("3 - Voltar ao menu\n");

                Console.Write("-> ");

                opcao_produto = Convert.ToUInt16(Console.ReadLine());

                if (opcao_produto == 3)
                {
                    Menu_setores();
                }

                valor_carrinho += precos_carnes[opcao_produto];
                produtosEscolhidos.Add(produtos_carnes[opcao_produto] + " R$ " + precos_carnes[opcao_produto]);
                adicionar_ou_pagar();
            }

            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Algo de inesperado aconteceu.\nRetornando ao menu de carnes");
                Thread.Sleep(1600);
                Menu_carnes();
            }
        }

        static void adicionar_ou_pagar()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("1 - Adicionar outro produto/Voltar para menu de setores\n2 - Pagar");
            Console.Write("\n-> ");

            UInt16 opcao_add_pag = 0;

            try
            {
                opcao_add_pag = Convert.ToUInt16(Console.ReadLine());
            }

            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Algo de inesperado aconteceu.\nRetornando...");
                Thread.Sleep(1000);
                adicionar_ou_pagar();
            }

            if (opcao_add_pag == 1)
            {
                Menu_setores();
            }

            if (opcao_add_pag == 2)
            {
                Pagamento();
            }

        }

        static void Pagamento()
        {
            Console.Clear();

            UInt16 opcao_pag = 0;

            Console.WriteLine("Produtos escolhidos:\n");
            foreach (var produto in produtosEscolhidos)
            {
                Console.WriteLine(produto);
            }

            Console.WriteLine("----------------------");
            Console.WriteLine("Total a pagar: " + "R$" + valor_carrinho);
            Console.WriteLine("----------------------");
            Console.WriteLine("Selecione uma opção de pagamento: \n1 - Crédito\n2 - Débito\n3 - Pix");
            Console.Write("\n-> ");

            try
            {
                opcao_pag = Convert.ToUInt16(Console.ReadLine());
                Console.WriteLine("----------------------");
                Console.Clear();

                switch (opcao_pag)
                {
                    case 1:
                        Console.WriteLine("Pagamento realizado com o cartão de crédito.");
                        break;

                    case 2:
                        Console.WriteLine("Pagamento realizado com o cartão de débito.");
                        break;

                    case 3:
                        Console.WriteLine("Pagamento realizado com o Pix.");
                        break;
                }

                Console.WriteLine($"Seu pedido chegará em breve no endereço cadastrado:\n\nCidade: {endereco_cidade}\nMunicípio: {endereco_municipio}\nRua: {endereco_rua} N°{endereco_numero}\nComplemento: {endereco_complemento}");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Pos_pagamento();
            }

            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Algo de inesperado aconteceu.\nRetornando ao Pagamento");
                Thread.Sleep(1600);
                Pagamento();
            }
        }

        static void Pos_pagamento()
        {
            Console.Clear();

            UInt16 opcao_pos_pagamento = 0;
          
            Console.WriteLine("--------------------------");
            Console.WriteLine("Escolha uma opção:\n1 - Ir para menu inicial\n2 - Ir para menu de setores\n3 - Sair");
            Console.Write("\n-> ");

            try
            {
                opcao_pos_pagamento = UInt16.Parse(Console.ReadLine());
            }

            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Algo de inesperado aconteceu.\nRetornando...");
                Thread.Sleep(1600);
                Pos_pagamento();
            }

            if (opcao_pos_pagamento == 1)
            {
                Limpar_lista_e_carrinho();
                Menu();
            }

            if (opcao_pos_pagamento == 2)
            {
                Limpar_lista_e_carrinho();
                Menu_setores();
            }

            if (opcao_pos_pagamento == 3)
            {
                Console.Clear();
                Console.WriteLine("Aplicação encerrada.");
                Environment.Exit(0);
            }
        }

        public static void Limpar_lista_e_carrinho()
        {
            produtosEscolhidos.Clear();
            valor_carrinho = 0;
        }      
    }
}
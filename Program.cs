using System;
using System.Threading;
using System.Collections.Generic;


namespace teste
{
    class Program
    {
        static string user_verificar, senha_verificar;

        static string[] produtos_limpeza = {"Detergente", "Bucha", "Agua Sanitaria 1L"} ;
        static decimal[] precos_limpeza = {2.90m, 2.00m, 7.50m};
        static string[] produtos_alimentos = {"Arroz 5KG", "Feijao 1KG", "Macarrao 500g"} ;
        static decimal[] precos_alimentos = {15.50m, 5.50m, 7.50m};
        static string[] produtos_carnes = {"Carne bovina", "Frango", "Linguica"} ;
        static decimal[] precos_carnes = {9.50m, 7.40m, 5.50m};

        static string user_cadastro, senha_cadastro, endereco_municipio, endereco_cidade, endereco_rua, endereco_numero;

        static List<string> produtosEscolhidos = new List<string>();

        static decimal valor_carrinho;
        
        static void Main ()
        {
            Menu();
        }

        static void Menu ()
        {
            Console.Clear ();

            uint opcao;

            Console.WriteLine("Seja Bem-vindo(a)");
            Console.WriteLine("-----------------");
            Console.WriteLine ("1 - Fazer Login\n2 - Cadastro\n3 - Sair");
            Console.Write ("\n->");
            opcao = Convert.ToUInt16(Console.ReadLine());

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
                Menu();
            }
        }

        static void Entrar()
        {
            Console.Clear();

            string user, senha;

            Console.WriteLine("Login");
            Console.WriteLine("---------------------");
            Console.Write("Digite seu usuario: ");
            user = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            senha = Console.ReadLine();

            if (user.CompareTo(user_verificar) == 0 && senha.CompareTo(senha_verificar) == 0)
            {
                Console.WriteLine ("\nAcesso Permitdo!");
                Menu_setores();
            }

            else
            {
                Console.WriteLine ("\nAcesso Negado!\nRedirecionando para menu inicial..."); 
                Thread.Sleep(1600);
                Menu();
            }

            Console.Clear();
        }

        static void Cadastro_user()
        {
            Console.Clear();
            UInt16 opcao_user;

            Console.WriteLine("Cadastro");
            Console.WriteLine("---------------------");
            Console.Write("Crie um usuário: ");
            user_cadastro = Console.ReadLine();

            Console.Write("Crie uma senha: "); 
            senha_cadastro = Console.ReadLine();

            user_verificar = user_cadastro;
            senha_verificar = senha_cadastro;
            
            Console.WriteLine("---------------------");
            Console.WriteLine("Endereço");
            Console.WriteLine("---------------------");
            Console.Write("Digite sua cidade: ");
            endereco_cidade = Console.ReadLine();
            Console.Write("Digite seu município: ");
            endereco_municipio = Console.ReadLine();
            Console.Write("Digite o nome de sua rua: ");
            endereco_rua = Console.ReadLine();
            Console.Write("Digite o número: ");
            endereco_numero = Console.ReadLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("Selecione uma opção:\n1 - Refazer Cadastro\n2 - Ir para menu inicial\n3 - Sair ");
            Console.Write("\n-> ");
            opcao_user = UInt16.Parse(Console.ReadLine());

            switch (opcao_user) 
            {
                case 1:
                    Cadastro_user();
                break;

                case 2:
                    Menu();
                break;

                case 3:
                    Console.WriteLine("Aplicação encerrada!");
                    Environment.Exit(0);
                break;
            }
            Entrar();
        }

        static void Menu_setores()
        {
            UInt16 opcao_setor;

            Console.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Valor do seu carrinho: " + "R$"+valor_carrinho);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Escolha um setor: ");
            Console.WriteLine("1 - Limpeza\n2 - Alimentos\n3 - Carnes\n4 - Sair"); 
            Console.Write ("\n-> ");
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
                    Console.WriteLine("Aplicação encerrada!");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                break;
            }
        }

        static void Menu_limpeza()
        {
            Console.Clear();

            UInt16 opcao_produto;

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

        static void Menu_alimentos()
        {
            Console.Clear();

            UInt16 opcao_produto;

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

        static void Menu_carnes()
        {
            Console.Clear();

            UInt16 opcao_produto;

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
                produtosEscolhidos.Add(produtos_carnes[opcao_produto] + " R$ " + precos_alimentos[opcao_produto]);
                adicionar_ou_pagar();
        }

        static void adicionar_ou_pagar()
        {
            Console.Clear();

            Console.WriteLine("1 - Adicionar outro produto\n2 - Pagar");
            Console.Write("\n-> ");

            UInt16 opcao_add_pag;
            opcao_add_pag = Convert.ToUInt16(Console.ReadLine());

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

            foreach (var produto in produtosEscolhidos)
            {
                Console.WriteLine(produto);
            }

            Console.WriteLine("----------------------");
            Console.WriteLine("Total a pagar: " + "R$" + valor_carrinho);
            Console.WriteLine("----------------------");
            Console.WriteLine("Selecione uma opção de pagamento: \n1 - Crédito\n2 - Débito\n3 - Pix");
            Console.Write("\n-> ");
            UInt16 opcao_pag = Convert.ToUInt16(Console.ReadLine());

            switch (opcao_pag) 
            {
                case 1:
                    Console.WriteLine("\nPagamento realizado com o cartão de crédito.");
                break;

                case 2:
                    Console.WriteLine("\nPagamento realizado com o cartão de débito.");
                break;

                case 3:
                    Console.WriteLine("\nPagamento realizado com o Pix.");
                break;
            }

            Console.WriteLine($"Seu pedido chegará em breve no endereço cadastrado:\n\nCidade: {endereco_cidade}\nMunicípio: {endereco_municipio}\nRua: {endereco_rua} N°{endereco_numero}\n");
            Environment.Exit(0);
            Console.ReadKey();
        }
    }
}

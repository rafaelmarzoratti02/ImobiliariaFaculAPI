using ImobiliariaFacul.Menus;


Dictionary<int, Menu> opcoes = new Dictionary<int, Menu>();
opcoes.Add(1, new MenuCadastroDeImovel());
opcoes.Add(2, new MenuMostrarImoveis());
opcoes.Add(3, new MenuBuscarImovel());
int opcao = 0;

void ExibirOpcoesDoMenu()
{
    while (opcao != -1)
    {
        Console.Clear();
        Console.WriteLine("-----------Bem vindo a Devztti imobiliaria!-----------");
        Console.WriteLine("\nDigite 1 para um imovel");
        Console.WriteLine("Digite 2 para exibir todas os imoveis");
        Console.WriteLine("Digite 3 para buscar um imovel");
        Console.WriteLine("Digite -1 para sair");
        Console.WriteLine("------------------------------------------------------");
        Console.Write("Digite a opção desejada: ");

        opcao = int.Parse(Console.ReadLine());

        
            if (!opcoes.ContainsKey(opcao))
            {
                Console.WriteLine("Opcão inválida");
                Console.Clear();
                ExibirOpcoesDoMenu();
            }
          
            if(opcao != -1) {
            Menu menuASerExibido = opcoes[opcao];
            menuASerExibido.Executar();
            }

        Console.WriteLine("Adeus!");
    }
}

ExibirOpcoesDoMenu();
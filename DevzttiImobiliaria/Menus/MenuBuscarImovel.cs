using ImobiliariaFacul.Banco;
using ImobiliariaFacul.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobiliariaFacul.Menus;

internal class MenuBuscarImovel : Menu
{
    public string TituloOpcao = "IMOVEL";


    public override void Executar()
    {
        base.ExibirTituloOpcao(TituloOpcao);
        Console.WriteLine("Qual o tipo de imovel você quer buscar? [1] Casa [2] Apto [3] Terreno");
        Console.Write("Digite sua opção: ");
        int opcao = int.Parse(Console.ReadLine()!);

        switch (opcao)
        {
            case 1:
                Console.Clear();
                Console.Write("Digite o endereço da casa: ");
                string endereco = Console.ReadLine()!;
                DAL<Casa> casas = new DAL<Casa>(new ImobiliariaContext());
                var casaSelecionada = casas.BuscarPorCondicao(x => x.Endereco.ToUpper() == endereco.ToUpper());
                if (casaSelecionada is null)
                {
                    Console.WriteLine("Nenhuma casa registrada!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("---------------");
                    casaSelecionada.ExibirDetalhes();
                    Console.WriteLine("---------------");
                    Console.WriteLine("Digite qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                }
                break;

            case 2:
                DAL<Apto> aptos = new DAL<Apto>(new ImobiliariaContext());
                Console.Clear();
                Console.Write("Digite o endereço do apto: ");
                endereco = Console.ReadLine()!;
                var aptoSelecionado = aptos.BuscarPorCondicao(x => x.Endereco == endereco);
                if (aptoSelecionado is null)
                {
                    Console.WriteLine("Nenhum apto registrado!");
                }
                else
                {
                    Console.WriteLine("---------------");
                    aptoSelecionado.ExibirDetalhes();
                    Console.WriteLine("---------------");
                    Console.WriteLine("Digite qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                }
                break;
            case 3:
                DAL<Terreno> terrenos = new DAL<Terreno>(new ImobiliariaContext());
                Console.Clear();
                Console.Write("Digite o Id da casa: ");
                endereco = Console.ReadLine()!;
                var terrenoSelecionado = terrenos.BuscarPorCondicao(x => x.Endereco == endereco);
                if (terrenoSelecionado is null)
                {
                    Console.WriteLine("Nenhuma casa registrada!");
                    Console.WriteLine("Digite qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("---------------");
                    terrenoSelecionado.ExibirDetalhes();
                    Console.WriteLine("---------------");
                    Console.WriteLine("Digite qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                }
                break;
        }
    }
}

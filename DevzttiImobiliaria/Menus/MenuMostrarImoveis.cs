using ImobiliariaFacul.Banco;
using ImobiliariaFacul.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobiliariaFacul.Menus
{
    internal class MenuMostrarImoveis : Menu
    {
        public string TituloOpcao = "IMOVEIS";
        public override void Executar()
        {
            base.ExibirTituloOpcao(TituloOpcao);
            Console.WriteLine("Qual o tipo de imoveis você quer ver? [1] Casa [2] Apto [3] Terreno");
            Console.Write("Digite sua opção: ");
            int opcao = int.Parse(Console.ReadLine()!);

            switch (opcao) {
                case 1:
                    DAL<Casa> casas = new DAL<Casa>(new ImobiliariaContext());
                    var casasListadas = casas.Listar();
                    if(casasListadas is null)
                    {
                        Console.WriteLine("Nenhuma casa registrada!");
                    }
                    else{
                    foreach (var casa in casasListadas)
                        {
                            casa.ExibirDetalhes();
                            Console.WriteLine("----------------");
                        }
                    Console.WriteLine("Digite qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                    }
                    break;
                   
                case 2:
                    DAL<Apto> aptos = new DAL<Apto>(new ImobiliariaContext());
                    var aptosListados = aptos.Listar();
                    if (aptosListados is null)
                    {
                        Console.WriteLine("Nenhuma casa registrada!");
                    }
                    else
                    {
                        foreach (var apto in aptosListados)
                        {
                            apto.ExibirDetalhes();
                            Console.WriteLine("----------------");
                        }
                        Console.WriteLine("Digite qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    DAL<Terreno> terrenos = new DAL<Terreno>(new ImobiliariaContext());
                    var terrenosListados = terrenos.Listar();
                    if (terrenosListados is null)
                    {
                        Console.WriteLine("Nenhuma casa registrada!");
                    }
                    else
                    {
                        foreach (var terreno in terrenosListados)
                        {
                            terreno.ExibirDetalhes();
                            Console.WriteLine("----------------");
                        }
                        Console.WriteLine("Digite qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                    }
                    break;
            }
            
        }
    }
}

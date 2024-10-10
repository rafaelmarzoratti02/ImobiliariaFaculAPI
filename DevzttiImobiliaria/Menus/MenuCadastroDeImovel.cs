using ImobiliariaFacul.Banco;
using ImobiliariaFacul.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImobiliariaFacul.Menus
{
    internal class MenuCadastroDeImovel: Menu
    {
        public string TituloOpcao = "CADASTRO DE IMOVEL";
        public override void Executar()
        {
            base.ExibirTituloOpcao(TituloOpcao);
            Console.WriteLine("Qual o tipo de imóvel você gostaria de cadastrar? ([1] Casa [2] Apto [3] Terreno");
            Console.Write("Digite sua opcão: ");

            int opcao = int.Parse(Console.ReadLine()!);
            if (opcao < 1 || opcao > 3) {
                Console.WriteLine("Opção inválida!");
            }

            switch (opcao)
            {
                case 1:
                    DAL<Casa> casaDAl = new DAL<Casa>(new ImobiliariaContext());
                    Console.Clear();
                    Console.WriteLine("Qual o valor da casa?");
                    float valor = float.Parse(Console.ReadLine()!); 
                    Console.WriteLine("Qual o endereço da casa?");
                    string endereco = Console.ReadLine()!;
                    Console.WriteLine("Qual a area total da casa?");
                    float areaTotal = float.Parse(Console.ReadLine()!);
                    Console.WriteLine("Qual a area construida da casa?");
                    float areaConstruida = float.Parse(Console.ReadLine()!);
                    Casa casa = new Casa(valor, endereco, areaTotal, areaConstruida);
                    casaDAl.Adicionar(casa);

                    break;
                case 2:
                    DAL<Apto> aptoDAl = new DAL<Apto>(new ImobiliariaContext());
                    Console.Clear();
                    Console.WriteLine("Qual o valor do apto?");
                     valor = float.Parse(Console.ReadLine()!);
                    Console.WriteLine("Qual o endereço do apto?");
                     endereco = Console.ReadLine()!;
                    Console.WriteLine("Qual a area total do apto?");
                     areaTotal = float.Parse(Console.ReadLine()!);
                    Console.WriteLine("Qual a area privativa do apto?");
                    float areaPrivativa = float.Parse(Console.ReadLine()!);
                    Apto apto = new Apto(valor, endereco, areaTotal, areaPrivativa);
                    aptoDAl.Adicionar(apto);

                    break;
                case 3:
                    DAL<Terreno> terrenoDAL = new DAL<Terreno>(new ImobiliariaContext());
                    Console.Clear();
                    Console.WriteLine("Qual o valor do terreno?");
                    valor = float.Parse(Console.ReadLine()!);
                    Console.WriteLine("Qual o endereço do terreno?");
                    endereco = Console.ReadLine()!;
                    Console.WriteLine("Qual a area total do terreno?");
                    areaTotal = float.Parse(Console.ReadLine()!);
                    Console.WriteLine("Qual o tipo do terreno?(Urbano ou Rural)");
                    string tipo = Console.ReadLine()!;
                    Terreno terreno = new Terreno(valor, endereco, areaTotal, tipo);
                    terrenoDAL.Adicionar(terreno);

                    break;
                default:
                    Console.WriteLine("Opção inválida! Retornando ao menu principal...");
                    Thread.Sleep(2000);
                    break;
            }
            
        }
    }

   

}

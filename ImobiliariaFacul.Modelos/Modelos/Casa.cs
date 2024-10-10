using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobiliariaFacul.Modelos;

public class Casa : Imovel
{
    public float AreaConstruida { get; set; }

    public Casa(float valor, string endereco, float areaTotal, float areaConstruida) : base(valor, endereco, areaTotal)
    {
        AreaConstruida = areaConstruida;
    }


    public override void ExibirDetalhes()
    {
        base.ExibirDetalhes();
        Console.WriteLine($"Area Construida:{AreaConstruida}");
    }
}

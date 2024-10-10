using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobiliariaFacul.Modelos;

public class Apto: Imovel
{
    public float AreaPrivativa { get; set; }

    public Apto(float valor, string endereco, float areaTotal, float areaPrivativa) : base(valor, endereco, areaTotal)
    {
        AreaPrivativa = areaPrivativa;
    }


    

    public override void ExibirDetalhes()
    {
        base.ExibirDetalhes();
        Console.WriteLine($"Area Privativa:{AreaPrivativa}");
    }

}

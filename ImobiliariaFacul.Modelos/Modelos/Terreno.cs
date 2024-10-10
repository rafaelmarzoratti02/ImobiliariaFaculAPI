using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobiliariaFacul.Modelos;

public class Terreno: Imovel
{
    public string Tipo { get; set; }

    public Terreno(float valor, string endereco, float areaTotal, string tipo) : base(valor, endereco, areaTotal)
    {
        Tipo = tipo;
    }

    public override float CalcularIptu()
    {
        return base.CalcularIptu();
    }

    public override void ExibirDetalhes()
    {
        base.ExibirDetalhes();
        Console.WriteLine($"Tipo:{Tipo}");
    }
}

using ImobiliariaFacul.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobiliariaFacul.Modelos;

public class Imovel
{
    public int Id { get; set; }
    public float Valor { get; set; }
    public string Endereco { get; set; }
    public float AreaTotal { get; set; }


    public Imovel(float valor, string endereco, float areaTotal)
    {
        Valor = valor;
        Endereco = endereco;
        AreaTotal = areaTotal;
    }

    public virtual float CalcularIptu()
    {
        return 1;
    }

    public virtual void ExibirDetalhes()
    {
        Console.WriteLine(
            $@"
Id: {Id}
Valor: {Valor}
Endereço: {Endereco}
Área total: {AreaTotal}");
    }
}

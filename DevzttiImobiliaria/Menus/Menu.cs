using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobiliariaFacul.Menus;

abstract class Menu
{
    public string TituloOpcao { get; set; }

    public void ExibirTituloOpcao(string tituloOpcao)
    {
        Console.Clear();
        Console.WriteLine($"------{tituloOpcao}------");
    }

    public virtual void Executar()
    {
    }
}

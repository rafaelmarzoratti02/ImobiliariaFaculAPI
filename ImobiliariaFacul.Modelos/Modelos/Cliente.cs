using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobiliariaFacul.Modelos.Modelos;

public class Cliente
{
    public int Id { get; set; }
    public int Nome { get; set; }


    public Cliente(int id, int nome)
    {
        Id = id;
        Nome = nome;
    }
}

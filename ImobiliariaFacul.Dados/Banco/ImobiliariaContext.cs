using ImobiliariaFacul.Modelos;
using ImobiliariaFacul.Modelos.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobiliariaFacul.Banco;

public class ImobiliariaContext : DbContext
{
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Imobiliaria;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    public  DbSet<Casa> Casas { get; set; }
    public DbSet<Apto> Aptos { get; set; }
    public DbSet<Terreno> Terrenos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Imovel> Imoveis { get; set; }





    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

}



using ImobiliariaFacul.Banco;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobiliariaFacul.Banco;

public class DAL<T> where T : class
{
    private readonly ImobiliariaContext context;

    public DAL(ImobiliariaContext context)
    {
        this.context = context;
    }

    public IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }
    public void Adicionar(T obj)
    {
        context.Set<T>().Add(obj);
        context.SaveChanges();
    }
    public void Atualizar(T obj)
    {
        context.Set<T>().Update(obj);
        context.SaveChanges();
    }
    public void Deletar(T obj)
    {
        context.Set<T>().Remove(obj);
        context.SaveChanges();
    }

    public T BuscarPorCondicao(Func<T,bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }
}

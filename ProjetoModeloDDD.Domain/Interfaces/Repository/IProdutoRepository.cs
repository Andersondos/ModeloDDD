
using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IRepositortyBase<Produto>
    {
        IEnumerable<Produto> BuscarProNome(string nome);

    }
}

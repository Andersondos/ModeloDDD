using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repository
{
    public interface IRepositortyBase<TEntity> where TEntity :class
    {
        //metodos genericos do repositorio base (GRUD)
        void Add(TEntity obj); //adicionar 
        TEntity GetById(int id); // selecionar 
        IEnumerable<TEntity> GetAll(); // selcionar tudo
        void Update(TEntity obj); // Atualizar
        void Remove(TEntity obj); // Remover
        void Dispose();
    }
}

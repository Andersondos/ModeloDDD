using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Repository;
using ProjetoModeloDDD.Infra.Data.Contexto;


namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEnity> : IDisposable, IRepositortyBase<TEnity> where TEnity : class
    {

        protected ProjetoModeloContext Db = new ProjetoModeloContext();  

        public void Add(TEnity obj)
        {
            Db.Set<TEnity>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEnity> GetAll()
        {
            
            return Db.Set<TEnity>().ToList();
        }

        public TEnity GetById(int id)
        {
            return Db.Set<TEnity>().Find(id);
        }

        public void Remove(TEnity obj)
        {
            Db.Set<TEnity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEnity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}

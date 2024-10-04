using System.Collections.Generic;

namespace VotreNamespace.Models.Repositories
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T FindByID(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        List<T> Search(string term);
    }
}
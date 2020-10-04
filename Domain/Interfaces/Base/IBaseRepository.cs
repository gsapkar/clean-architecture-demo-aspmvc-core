using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IReadOnlyList<T> GetAll();
        IReadOnlyList<T> GetPagedReponse(int pageNumber, int pageSize);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

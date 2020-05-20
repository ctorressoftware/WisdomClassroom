using System.Collections.Generic;

namespace WisdomClassroomApp.Common
{
    interface IRepository<T> where T : class
    {
        T GetById(int id);

        List<T> GetAll();

        void Create(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}

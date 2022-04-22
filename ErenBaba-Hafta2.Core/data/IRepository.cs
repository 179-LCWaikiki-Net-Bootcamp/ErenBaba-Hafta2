using ErenBaba_Hafta2.Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenBaba_Hafta2.Core.data
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Remove(int Id);
        void Update(TEntity entity);
        TEntity Find(int Id);
        IQueryable<TEntity> GetQuery();
        IQueryable GetSqlRawQuery(string query);
        void Save();
    }
}

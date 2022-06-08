using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pryPlayers.DataAccess.Contracts.Repositories
{
    public interface IRepository<T, G>
        where T : class
        where G : class
    {
        T Add(T element);
        Task<T> Get(G id);
        IEnumerable<T> GetAll();
        T Update(T element);
        T Delete(T id);
        Task<bool> Exist(G id);
        Task SaveChanges();
    }
}

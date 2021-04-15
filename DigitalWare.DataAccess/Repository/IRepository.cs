using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWare.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Allows the Query actions
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Query();

        /// <summary>
        /// Adds an element
        /// </summary>
        /// <param name="entity">Object to add</param>
        void Add(T entity);

        /// <summary>
        /// Detachs an element
        /// </summary>
        /// <param name="entity"></param>
        void Detach(T entity);

        /// <summary>
        /// Adss an element asynchronously
        /// </summary>
        /// <param name="entity">Object to add</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an especific element
        /// </summary>
        /// <param name="entity">Object to update</param>
        void Update(T entity);

        /// <summary>
        /// Begins the transaction
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTransaction();

        /// <summary>
        /// Save model changes
        /// </summary>
        /// <returns></returns>
        int SaveChange();

        /// <summary>
        /// Save model changes asynchronously
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangeAsync();

        /// <summary>
        /// Deletes an element
        /// </summary>
        /// <param name="entity">Object to remove from the context</param>
        void Remove(T entity);
    }
}

using System.Data.Entity;
using AngularJS.SqlDataAccess.Repo.Concrete;

namespace AngularJS.SqlDataAccess.Repo.Interfaces
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
namespace Cvl.Training.SmsEmailSender.Core.Base
{
    public interface IReadOnlyEntities
    {
        IQueryable<TEntity> QueryReadOnly<TEntity>() where TEntity : BaseEntity;
    }

    public interface IWriteEntities : IReadOnlyEntities, IUnitOfWork
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : BaseEntity;
        Task<TEntity?> Find<TEntity>(long id) where TEntity : BaseEntity;
        Task Add<TEntity>(TEntity entity) where TEntity : class;
        void MarkAsUpdated<TEntity>(TEntity entity) where TEntity : class;
        Task Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }

    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}

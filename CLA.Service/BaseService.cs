using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CLA.Service
{
    public abstract class BaseService<TDbContext, TModel> : IGenericService<TModel>
        where TDbContext : DbContext
        where TModel : class
    {
        protected readonly TDbContext _dbContext;

        public BaseService(TDbContext dbContext)
        {
            this._dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected virtual void SetModifiedByModel<TM, TProperty>(TM model,
            params Expression<Func<TM, TProperty>>[] propertiesExpression) where TM : class
        {
            if (propertiesExpression == null
                || propertiesExpression.Length == 0)
            {
                return;
            }

            foreach (Expression<Func<TM, TProperty>> item in propertiesExpression)
            {
                _dbContext.Entry(model).Property(item).IsModified = true;
            }
        }

        protected virtual void SetModified<TProperty>(TModel model,
            params Expression<Func<TModel, TProperty>>[] propertiesExpression)
        {
            SetModifiedByModel<TModel, TProperty>(model, propertiesExpression);
        }

        protected virtual void SetModified(TModel model,
            params Expression<Func<TModel, object>>[] propertiesExpression)
        {
            SetModified<object>(model, propertiesExpression);
        }

        public IQueryable<TModel> GetAll()
        {
            return _dbContext.Set<TModel>();
        }

        public virtual async Task<ICollection<TModel>> GetAllAsync()
        {

            return await _dbContext.Set<TModel>().ToListAsync();
        }

        public async Task<ICollection<TModel>> FindByAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await _dbContext.Set<TModel>().ToListAsync();
        }

        public virtual TModel Get(string id)
        {
            return _dbContext.Set<TModel>().Find(id);
        }

        public virtual async Task<TModel> GetAsync(string id)
        {
            return await _dbContext.Set<TModel>().FindAsync(id);
        }

        public virtual TModel Add(TModel t)
        {

            _dbContext.Set<TModel>().Add(t);
            _dbContext.SaveChanges();
            return t;
        }

        public virtual async Task<TModel> AddAsync(TModel t)
        {
            _dbContext.Set<TModel>().Add(t);
            await _dbContext.SaveChangesAsync();
            return t;

        }

        public virtual TModel Find(Expression<Func<TModel, bool>> match)
        {
            return _dbContext.Set<TModel>().SingleOrDefault(match);
        }

        public virtual async Task<TModel> FindAsync(Expression<Func<TModel, bool>> match)
        {
            return await _dbContext.Set<TModel>().SingleOrDefaultAsync(match);
        }

        public ICollection<TModel> FindAll(Expression<Func<TModel, bool>> match)
        {
            return _dbContext.Set<TModel>().Where(match).ToList();
        }

        public async Task<ICollection<TModel>> FindAllAsync(Expression<Func<TModel, bool>> match)
        {
            return await _dbContext.Set<TModel>().Where(match).ToListAsync();
        }

        public virtual void Delete(TModel entity)
        {
            _dbContext.Set<TModel>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(TModel entity)
        {
            _dbContext.Set<TModel>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual TModel Update(TModel t, object key)
        {
            if (t == null)
                return null;
            TModel exist = _dbContext.Set<TModel>().Find(key);
            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(t);
                var rs = _dbContext.SaveChanges();
                if (rs == 0)
                {
                    return null;
                }
            }
            return exist;
        }

        public virtual async Task<TModel> UpdateAsync(TModel t, object key)
        {
            if (t == null)
                return null;
            TModel exist = await _dbContext.Set<TModel>().FindAsync(key);
            if (exist != null)
            {
                _dbContext.Entry(exist).State = EntityState.Modified;
                _dbContext.Entry(exist).CurrentValues.SetValues(t);
                var rs = await _dbContext.SaveChangesAsync();

                if (rs == 0)
                {
                    return null;
                }
            }
            return exist;
        }

        public int Count()
        {
            return _dbContext.Set<TModel>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<TModel>().CountAsync();
        }

        public virtual void Save()
        {

            _dbContext.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
        {
            IQueryable<TModel> query = _dbContext.Set<TModel>().Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<TModel>> FindByAsyn(Expression<Func<TModel, bool>> predicate)
        {
            return await _dbContext.Set<TModel>().Where(predicate).ToListAsync();
        }

        public IQueryable<TModel> GetAllIncluding(params Expression<Func<TModel, object>>[] includeProperties)
        {

            IQueryable<TModel> queryable = GetAll();
            foreach (Expression<Func<TModel, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<TModel, object>(includeProperty);
            }

            return queryable;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

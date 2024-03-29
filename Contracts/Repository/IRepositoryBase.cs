﻿using System.Linq.Expressions;

namespace Contracts.Repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
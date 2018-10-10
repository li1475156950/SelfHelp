using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SelfHelp.Common;

namespace SelfHelp.IDAL
{
    public interface IRepository
    {
        T Update<T>(T entity) where T : class;
        int UpdateEntity<T>(T entity) where T : class;
        T Insert<T>(T entity) where T : class;
        int InsertEntity<T>(T entity) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : class;
        List<T> FindAllByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : class;
        int Delete<T>(Expression<Func<T, bool>> conditions) where T : class;

    }
}

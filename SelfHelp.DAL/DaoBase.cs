using System;
using System.Linq;
using System.Collections.Generic;
using SelfHelp.IDAL;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;
using SelfHelp.Common;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
namespace SelfHelp.DAL
{
    public class DaoBase : IRepository, IDisposable
    {
        [Import("DB")]
        public DbContext context;

        public DaoBase() 
        {
            if(context==null)
            {
                DirectoryCatalog catalog1 = new DirectoryCatalog(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "SelfHelp.DAL.dll");
                var container = new CompositionContainer(catalog1);
                container.ComposeParts(this);
            }
            
        }
        public T Update<T>(T entity) where T : class
        {
            var set = context.Set<T>();
            set.Attach(entity);
            context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return entity;
        }
        public int UpdateEntity<T>(T entity) where T : class
        {
            var set = context.Set<T>();
            set.Attach(entity);
            context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges();
        }
        public T Insert<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }
        public int InsertEntity<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();
        }

        public T Find<T>(params object[] keyValues) where T : class
        {
            return context.Set<T>().Find(keyValues);
        }

        public List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : class
        {
            if (conditions == null)
                return context.Set<T>().ToList();
            else
                return context.Set<T>().Where(conditions).ToList();
        }

        public List<T> FindAllByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : class
        {
            var queryList = conditions == null ? context.Set<T>() : context.Set<T>().Where(conditions).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize) as IQueryable<T>;
            return queryList.ToList();

            //return queryList.OrderByDescending(orderBy).ToPagedList(pageIndex, pageSize);
        }
        public int Delete<T>(Expression<Func<T, bool>> conditions) where T : class
        {
            var tempList = context.Set<T>().Where(conditions).ToList();
            context.Set<T>().RemoveRange(tempList);
            return context.SaveChanges();

            //return queryList.OrderByDescending(orderBy).ToPagedList(pageIndex, pageSize);
        }
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}

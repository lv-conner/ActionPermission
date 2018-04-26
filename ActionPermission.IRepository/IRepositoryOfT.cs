using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
namespace ActionPermission.IRepository
{
    public interface IRepository<T>  where T: class
    {
        /// <summary>
        /// 添加
        /// </summary>
        void Add(T entity);
        /// <summary>
        /// 删除
        /// </summary>
        void Delete(T entity);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// 根据查找单个实体
        /// </summary>
        T Query(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 查找多个实体
        /// </summary>
        ICollection<T> QueryList(Expression<Func<T, bool>> predicate);
    }
}

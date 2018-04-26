using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionPermission.IRepository
{
    public interface IRepository<T>  where T: class
    {
        /// <summary>
        /// 添加
        /// </summary>
        void Add(T entity);
        /// <summary>
        /// 添加
        /// </summary>
        Task AddAsync(T entity);
        /// <summary>
        /// 删除
        /// </summary>
        void Delete<TKey>(T entity,TKey key);
        /// <summary>
        /// 删除
        /// </summary>
        Task DeleteAsync<TKey>(T entity,TKey key);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        void Update<Tkey>(T entity,Tkey key);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync<Tkey>(T entity,Tkey key);
        /// <summary>
        /// 根据查找单个实体
        /// </summary>
        T Query(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 根据查找单个实体
        /// </summary>
        Task<T> QueryAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 查找多个实体
        /// </summary>
        ICollection<T> QueryList(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 查找多个实体
        /// </summary>
        Task<ICollection<T>> QueryListAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 保存
        /// </summary>
        void SaveChange();
        /// <summary>
        /// 保存
        /// </summary>
        Task SaveChangeAsync();
    }
}

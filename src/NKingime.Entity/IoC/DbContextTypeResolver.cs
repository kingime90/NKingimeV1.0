using System;
using NKingime.Core.IoC;
using NKingime.Core.Data;
using NKingime.Core.Entity;
using NKingime.Entity.Data;
using NKingime.Core.Extension;

namespace NKingime.Entity.IoC
{
    /// <summary>
    /// 数据库上下文解析器。
    /// </summary>
    public class DbContextTypeResolver : IDbContextTypeResolver
    {
        private readonly IIocResolver _resolver;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resolver"></param>
        public DbContextTypeResolver(IIocResolver resolver)
        {
            _resolver = resolver;
        }

        /// <summary>
        /// 根据指定的数据实体类型获取关联的业务单元操作。
        /// </summary>
        /// <param name="entityType">数据实体类型。</param>
        /// <returns></returns>
        public IUnitOfWork Resolve<TEntity, TKey>()
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return Resolve(typeof(TEntity));
        }

        /// <summary>
        /// 根据指定的数据实体类型获取关联的业务单元操作。
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型。</typeparam>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <returns></returns>
        public IUnitOfWork Resolve(Type entityType)
        {
            entityType.CheckNotNull(() => nameof(entityType));
            var contextType = DbContextManage.Instance.GetDbContextType(entityType);
            var unitOfWork = (IUnitOfWork)_resolver.Resolve(contextType);
            if (unitOfWork == null)
            {

            }
            return unitOfWork;
        }
    }
}

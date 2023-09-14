﻿using Glasssix.Contrib.Domain;
using System;
using System.Linq.Expressions;

namespace Glasssix.Contrib.Repository.Operations
{
    /// <summary>
    /// 查找数量
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface ICount<TEntity, in TKey> where TEntity : class, IKey<TKey>
    {
        /// <summary>
        /// 查找数量
        /// </summary>
        /// <param name="predicate">条件</param>
        int Count(Expression<Func<TEntity, bool>> predicate = null);
    }
}
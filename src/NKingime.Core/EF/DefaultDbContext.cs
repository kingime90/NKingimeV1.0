﻿using System;

namespace NKingime.Core.EF
{
    /// <summary>
    /// 默认数据库上下文。
    /// </summary>
    public class DefaultDbContext : DbContextBase<DefaultDbContext>
    {
        /// <summary>
        /// 初始化一个<see cref="DefaultDbContext"/>新实例。
        /// </summary>
        public DefaultDbContext() : base("Default")
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DefaultDbContext"/>新实例。
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public DefaultDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
    }
}

//using System;
//using NKingime.Core.Config;
//using System.Linq;

//namespace NKingime.Core.Initializer
//{
//    /// <summary>
//    /// 上下文初始化。
//    /// </summary>
//    public class ContextInitializer : IContextInitializer
//    {
//        /// <summary>
//        /// 数据库是否已初始化。
//        /// </summary>
//        private static bool IsDatabaseInitializer;

//        /// <summary>
//        /// 初始化一个<see cref="ContextInitializer"/>新实例。
//        /// </summary>
//        public ContextInitializer()
//        {
//            DatabaseInitializer = new DatabaseInitializer();
//        }

//        /// <summary>
//        /// 初始化一个<see cref="ContextInitializer"/>新实例。
//        /// </summary>
//        /// <param name="databaseInitializer">数据库初始化接口。</param>
//        public ContextInitializer(IDatabaseInitializer databaseInitializer)
//        {
//            DatabaseInitializer = databaseInitializer;
//        }

//        /// <summary>
//        /// 数据库初始化。
//        /// </summary>
//        public IDatabaseInitializer DatabaseInitializer { get; private set; }

//        /// <summary>
//        /// 初始化上下文。
//        /// </summary>
//        /// <param name="contextConfig">上下文配置。</param>
//        public void Initialize(ContextConfig contextConfig)
//        {
//            if (!IsDatabaseInitializer)
//            {
//                DatabaseInitializer.Initialize(contextConfig.DbContexts.ToArray());
//                IsDatabaseInitializer = true;
//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NKingime.Core.Linq
{
    /// <summary>
    /// 重新绑定参数。
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> _parameterSet;

        /// <summary>
        /// 初始化一个<see cref="ParameterRebinder"/>新实例。
        /// </summary>
        /// <param name="parameterSet"></param>
        private ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> parameterSet)
        {
            _parameterSet = parameterSet ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// 初始化一个<see cref="ParameterRebinder"/>新实例。
        /// </summary>
        /// <param name="parameterSet"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> parameterSet, Expression exp)
        {
            return new ParameterRebinder(parameterSet).Visit(exp);
        }

        /// <summary>
        /// 访问 System.Linq.Expressions.ParameterExpression。
        /// </summary>
        /// <param name="node">要访问的表达式。</param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            ParameterExpression replacement;
            if (_parameterSet.TryGetValue(node, out replacement))
            {
                node = replacement;
            }
            return base.VisitParameter(node);
        }
    }
}

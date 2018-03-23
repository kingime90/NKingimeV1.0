using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NKingime.Core.Linq
{
    /// <summary>
    /// 
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> _parameterSet;

        private ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> parameterSet)
        {
            _parameterSet = parameterSet ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> parameterSet, Expression exp)
        {
            return new ParameterRebinder(parameterSet).Visit(exp);
        }

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

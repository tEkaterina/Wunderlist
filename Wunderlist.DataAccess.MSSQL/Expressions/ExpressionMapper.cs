using System.Linq.Expressions;
using System.Linq;
using System;

namespace Wunderlist.DataAccess.MsSql.Expressions
{
    public class ExpressionMapper<TFrom, TO, TResult>
    {
        private class Visitor<TTFrom, TTo> : ExpressionVisitor
        {
            public ParameterExpression ParameterExpression { get; }

            public Visitor(ParameterExpression parameterExpression)
            {
                ParameterExpression = parameterExpression;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return ParameterExpression;
            }
            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Member.DeclaringType == typeof(TTFrom))
                {
                    return Expression.MakeMemberAccess(Visit(node.Expression), typeof(TTo).GetMember(node.Member.Name).FirstOrDefault());
                }
                return base.VisitMember(node);
            }
        }
        public static Expression<Func<TO, TResult>> Map(Expression<Func<TFrom, TResult>> expression)
        {
            Visitor<TFrom, TO> expressionMapper = new Visitor<TFrom, TO>(Expression.Parameter(typeof(TO), expression.Parameters[0].Name));
            return Expression.Lambda<Func<TO, TResult>>(expressionMapper.Visit(expression.Body), expressionMapper.ParameterExpression);
        }
    }
}
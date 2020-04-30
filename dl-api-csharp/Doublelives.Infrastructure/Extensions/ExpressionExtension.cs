using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Doublelives.Infrastructure.Extensions
{
    public static class ExpressionExtension
    {
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);
            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(left, right), parameter);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);
            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(left, right), parameter);
        }

        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                    return _newValue;

                return base.Visit(node);
            }
        }

        /// <summary>
        /// GetMemberName
        /// </summary>
        /// <typeparam name="TEntity">TEntity</typeparam>
        /// <typeparam name="TMember">TMember</typeparam>
        /// <param name="memberExpression">get member expression</param>
        /// <returns></returns>
        public static string
            GetMemberName<TEntity, TMember>(this Expression<Func<TEntity, TMember>> memberExpression) =>
            GetMemberInfo(memberExpression)?.Name;

        /// <summary>
        /// GetMemberInfo
        /// </summary>
        /// <typeparam name="TEntity">TEntity</typeparam>
        /// <typeparam name="TMember">TMember</typeparam>
        /// <param name="expression">get member expression</param>
        /// <returns></returns>
        public static MemberInfo GetMemberInfo<TEntity, TMember>(this Expression<Func<TEntity, TMember>> expression)
        {
            if (expression.NodeType != ExpressionType.Lambda)
            {
                throw new ArgumentException(nameof(expression));
            }

            var lambda = (LambdaExpression)expression;

            var memberExpression = ExtractMemberExpression(lambda.Body);
            if (memberExpression == null)
            {
                throw new ArgumentException(nameof(memberExpression));
            }

            return memberExpression.Member;
        }

        public static Expression<Func<T, bool>> AndCondition<T>(
            this Expression<Func<T, bool>> expression,
            string fieldName,
            string fieldValue,
            ConditionType type)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "c");
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException(nameof(fieldName));
            }
            if (typeof(T).GetProperty(fieldName) == null)
            {
                throw new ArgumentException($"{fieldName} field not exist");
            }
            Expression left = Expression.Property(param, typeof(T).GetProperty(fieldName));
            Expression right = Expression.Constant(fieldValue);
            Expression filter;
            switch (type)
            {
                case ConditionType.Equal:
                    filter = Expression.Equal(left, right);
                    break;
                case ConditionType.NotEqual:
                    filter = Expression.NotEqual(left, right);
                    break;
                case ConditionType.MoreThan:
                    filter = Expression.GreaterThan(left, right);
                    break;
                case ConditionType.MoreThanOrEqualTo:
                    filter = Expression.GreaterThanOrEqual(left, right);
                    break;
                case ConditionType.LessThan:
                    filter = Expression.LessThan(left, right);
                    break;
                case ConditionType.LessThanOrEqualTo:
                    filter = Expression.LessThanOrEqual(left, right);
                    break;
                case ConditionType.Like:
                    filter = Expression.Call(left, typeof(string).GetMethod("Contains"), right);
                    break;
                case ConditionType.NotLike:
                    filter = Expression.Not(Expression.Call(left, typeof(string).GetMethod("Contains"), right));
                    break;
                default:
                    filter = Expression.Equal(left, right);
                    break;
            }
            Expression<Func<T, bool>> finalExpression = Expression.Lambda<Func<T, bool>>(filter, param);

            return expression.And(finalExpression);
        }

        private static MemberExpression ExtractMemberExpression(Expression expression)
        {
            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                return (MemberExpression)expression;
            }

            if (expression.NodeType == ExpressionType.Convert)
            {
                var operand = ((UnaryExpression)expression).Operand;
                return ExtractMemberExpression(operand);
            }

            return null;
        }
    }

    public enum ConditionType
    {
        // 等于
        Equal,

        // 不等于
        NotEqual,

        // 大于
        MoreThan,

        // 大于等于
        MoreThanOrEqualTo,

        // 小于
        LessThan,

        // 小于等于
        LessThanOrEqualTo,

        // 模糊搜索
        Like,

        // 反向模糊搜索
        NotLike
    }
}

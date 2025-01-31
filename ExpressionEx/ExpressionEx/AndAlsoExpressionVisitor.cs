using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEx
{
    internal class AndAlsoExpressionVisitor:ExpressionVisitor
    {
        public override Expression Visit(Expression node)
        {
            if (node == null)
            {
                return null;
            }

            switch (node.NodeType)
            {
                case ExpressionType.AndAlso:
                    return this.VisitBinary((BinaryExpression)node);

                default:
                    return base.Visit(node);
            }
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType != ExpressionType.AndAlso)
            {
                return base.VisitBinary(node);
            }

            var left = this.Visit(node.Left);
            var right = this.Visit(node.Right);
            if (left == null || right == null)
            {
                throw new InvalidOperationException("Unable to build a binary expression.");
            }

            return Expression.MakeBinary(ExpressionType.OrElse, left, right);
        }
    }
}

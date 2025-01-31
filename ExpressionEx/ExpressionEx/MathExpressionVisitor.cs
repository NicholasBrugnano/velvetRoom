using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEx
{
    internal class MathExpressionVisitor : ExpressionVisitor
    {
        public override Expression Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                case ExpressionType.Subtract:
                case ExpressionType.Multiply:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                    return VisitBinary((BinaryExpression)node);
                default:
                    return base.Visit(node);
            }
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                case ExpressionType.Subtract:
                case ExpressionType.Multiply:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                    var left = this.Visit(node.Left);
                    var right = this.Visit(node.Right);

                    if (left == null || right == null)
                    {
                        throw new InvalidOperationException("Unable to build a binary expression."); //Sanity check
                    }

                    return Expression.MakeBinary(ExpressionType.Multiply,left,right);

                default:
                    return base.VisitBinary(node);
            }
        }
    }
}

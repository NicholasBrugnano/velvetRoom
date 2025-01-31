using System;
using System.Linq.Expressions;

namespace ExpressionEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Expression<Func<string, bool>> AndAlsoExp = e => e.Length > 10 && e.StartsWith("A");

            //Console.WriteLine($"Original Expression: {AndAlsoExp}");
            //var result = AndAlsoExp.Compile()("Apple");

            //Console.WriteLine($"Calling compiled original, result is {result}");

            //var andAlsoExprVisitor = new AndAlsoExpressionVisitor();

            //var updatedEXP = andAlsoExprVisitor.Visit(AndAlsoExp);

            //Console.WriteLine($"Calling updates expression: {updatedEXP}");

            //var updatedLambda = (Expression<Func<string,bool>>)updatedEXP;

            //var newResult = updatedLambda.Compile()("Apple");

            //Console.WriteLine($"Calling compiled update, result is {newResult}");
            //Console.WriteLine("i am the one who knocks");
            //Console.ReadKey();

            Expression<Func<double, double, double, double>> mathExp = (a, b, c) => a + b - c;
            Console.WriteLine($"Original Expression: {mathExp}");

            var mathvisitor = new MathExpressionVisitor();
            var Joker = mathvisitor.Visit( mathExp );
            Console.WriteLine($"New expression: {Joker}");
            Console.ReadKey();
        }
    }
}

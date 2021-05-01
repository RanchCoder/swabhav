using System;
using System.Linq.Expressions;

namespace ExpressionLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<int, bool> test = i => i > 5;
            //Console.WriteLine(test(19));
            //ConstantExpression exp = Expression.Constant(5,typeof(int));
            //Console.WriteLine(exp.Value);
            
            ParameterExpression param1 = Expression.Parameter(typeof(int),"i");
            ParameterExpression param2 = Expression.Parameter(typeof(int),"y");

            //ConstantExpression constExp = Expression.Constant(5,typeof(int));
            BinaryExpression greaterThan = Expression.Add(param1,param2);

            Expression<Func<int,int,int>> test1 =  Expression.Lambda<Func<int,int,int>>(greaterThan, param1,param2);
            Func<int,int,int> addition =  test1.Compile();

            Console.WriteLine(addition(11,5));


            Console.ReadLine();
        }
    }
}

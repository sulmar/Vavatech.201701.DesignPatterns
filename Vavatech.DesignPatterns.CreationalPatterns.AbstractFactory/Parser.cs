using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CreationalPatterns.AbstractFactory
{

    // abstract product interface
    interface IExpression
    {
        void Interpret(Stack<int> s);
    }


    // Concrete product 
    class PlusExpression : IExpression
    {
        public void Interpret(Stack<int> s)
        {
            s.Push(s.Pop() + s.Pop());
        }
    }

    class MinusExpression : IExpression
    {
        public void Interpret(Stack<int> s)
        {
            s.Push(-s.Pop() + s.Pop());
        }
    }

    class MultiplyExpression : IExpression
    {
        public void Interpret(Stack<int> s)
        {
            s.Push(s.Pop() * s.Pop());
        }
    }


    class NumberExpression : IExpression
    {
        private int number;

        public NumberExpression(int number)
        {
            this.number = number;
        }

        public void Interpret(Stack<int> s)
        {
            s.Push(number);
        }
    }

    class Parser
    {

        private IExpressionFactory expressionFactory;

        public Parser(IExpressionFactory expressionFactory)
        {
            this.expressionFactory = expressionFactory;
        }

        private IList<IExpression> parserTree = new List<IExpression>();

        public int Evaluate(string s)
        {
            Parse(s);

            Stack<int> context = new Stack<int>();

            foreach (var expression in parserTree)
            {
                expression.Interpret(context);
            }

            return context.Pop();

        }

        private void Parse(string s)
        {
            var tokens = s.Split(' ');

            foreach (var token in tokens)
            {
                IExpression expression = expressionFactory.Create(token);

                parserTree.Add(expression);
            }

        }
    }


    interface IExpressionFactory
    {
        IExpression Create(string token);
    }

    class ExpressionFactory : IExpressionFactory
    {
        public IExpression Create(string token)
        {
            switch (token)
            {
                case "+": return new PlusExpression(); break;
                case "-": return new MinusExpression(); break;
                case "*": return new MultiplyExpression(); break;

                default: return new NumberExpression(int.Parse(token)); break;
            }
        }
    }
}

using MathsTutor.Cards;
using System.Diagnostics;

namespace MathsTutor
{
    internal abstract class MathsParser
    {
        public int SimpleParse(List<Card> equation)
        {
            if (equation.Count != 3)
                throw new IndexOutOfRangeException();

            switch (equation[1].Suit)
            {
                case OperatorType.ADD:
                    return equation[0].Value + equation[2].Value;
                case OperatorType.SUBTRACT:
                    return equation[0].Value - equation[2].Value;
                case OperatorType.MULTIPLY:
                    return equation[0].Value * equation[2].Value;
                case OperatorType.DIVIDE:
                    double division = equation[0].Value / equation[2].Value; 
                    return (int)Math.Round(division, 0);
                default:
                    throw new UnreachableException();
            }
        }
        public int SimpleParse(int number, List<Card> equation)
        {
            if (equation.Count != 2)
                throw new IndexOutOfRangeException();
            
            switch (equation[0].Suit)
            {
                case OperatorType.ADD:
                    return number + equation[1].Value;
                case OperatorType.SUBTRACT:
                    return number - equation[1].Value;
                case OperatorType.MULTIPLY:
                    return number * equation[1].Value;
                case OperatorType.DIVIDE:
                    return number / equation[1].Value;
                default:
                    throw new UnreachableException();
            }
        }
        public int SimpleParse(List<Card> equation, int number)
        {
            if (equation.Count != 2)
                throw new IndexOutOfRangeException();
            
            switch (equation[1].Suit)
            {
                case OperatorType.ADD:
                    return equation[0].Value + number;
                case OperatorType.SUBTRACT:
                    return equation[0].Value - number;
                case OperatorType.MULTIPLY:
                    return equation[0].Value * number;
                case OperatorType.DIVIDE:
                    return equation[0].Value / number;
                default:
                    throw new UnreachableException();
            }
        }

        public int ComplexParse(List<Card> equation)
        {
            // Parse Longer equations using D&C
            if (equation.Count != 5)
                throw new IndexOutOfRangeException();

            OperatorType operatorOne = equation[1].Suit;
            OperatorType operatorTwo = equation[3].Suit;

            int evaluateFirst;
            

            // This is ok since we don't generate anything more than 3 numbers and two operators
            // but if we needed more then it might be better to do some form of RPN.
            // if it's just plus and minus then we need to just go left to right. 
            if(((operatorOne == OperatorType.ADD || operatorOne == OperatorType.SUBTRACT) 
                && (operatorTwo == OperatorType.ADD || operatorTwo == OperatorType.SUBTRACT))
                || (int)operatorOne > (int)operatorTwo)
            {
                List<Card> simpleEquation = equation.GetRange(0, 3);
                evaluateFirst = SimpleParse(simpleEquation);
                return SimpleParse(evaluateFirst, equation.GetRange(3, 2));
            }
            else
            {
                List<Card> simpleEquation = equation.GetRange(2, 3);
                evaluateFirst = SimpleParse(simpleEquation);
                return SimpleParse(equation.GetRange(0, 2), evaluateFirst);
            }
        }

    }
}

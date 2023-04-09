using MathsTutor.Cards;
using System.Diagnostics;

namespace MathsTutor
{
    internal abstract class MathsParser
    {
        public void GetRemainder(int ValueOne, int ValueTwo)
        {
            if (ValueOne % ValueTwo != 0)
            {
                int remainder = ValueOne % ValueTwo;
                Console.Write("What is the Remainer of the Division? ");
                string? remainderInput = Console.ReadLine();
                int value;
                if (remainderInput is not null && int.TryParse(remainderInput, out value))
                {
                    if (value == remainder)
                        Console.WriteLine("That's Right!\n");
                    else
                        Console.WriteLine($"The Correct Remainer is {remainder}\n");
                }
                else
                {
                    Console.WriteLine($"The Correct Remainer is {remainder}\n");
                }
            }
        }
        // Overloading of the SimpleParse Method, this is Static or Compile Time Polymorphism 
        // this lets me use the same method on different parameters slightly differently.
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
                    decimal division = equation[0].Value / equation[2].Value;
                    GetRemainder(equation[0].Value, equation[2].Value); 
                    return (int)Math.Floor(division);
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
                    decimal division = number / equation[1].Value;
                    GetRemainder(number, equation[1].Value);
                    return (int)Math.Floor(division);;
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
                    double division = equation[0].Value / number;
                    GetRemainder(equation[0].Value, number); 
                    return (int)Math.Floor(division);
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
            // We also go left to right of both operators are the same or the left one has 
            // more precendence than the right. 
            if(((operatorOne == OperatorType.ADD || operatorOne == OperatorType.SUBTRACT) 
                && (operatorTwo == OperatorType.ADD || operatorTwo == OperatorType.SUBTRACT))
                || (operatorOne == operatorTwo)
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

using MathsTutor.Packs;
using MathsTutor.Cards;
using System.Diagnostics;

namespace MathsTutor
{
    internal class MathsApp
    {
        private TestPack cardPack;

        public MathsApp()
        {
            this.cardPack = new TestPack();
            this.cardPack.Shuffle();
        }

        private int SimpleParse(List<CardTest> equation)
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
                    return equation[0].Value / equation[2].Value;
                default:
                    throw new UnreachableException();
            }
        }
        private int SimpleParse(int number, List<CardTest> equation)
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
        private int SimpleParse(List<CardTest> equation, int number)
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

        private int ComplexParse(List<CardTest> equation)
        {
            if (equation.Count != 5)
                throw new IndexOutOfRangeException();

            OperatorType operatorOne = equation[1].Suit;
            OperatorType operatorTwo = equation[3].Suit;

            int evaluateFirst;

            if((int)operatorOne > (int)operatorTwo)
            {
                List<CardTest> simpleEquation = equation.GetRange(0, 3);
                evaluateFirst = SimpleParse(simpleEquation);
                return SimpleParse(evaluateFirst, equation.GetRange(3, 2));
            }
            else
            {
                List<CardTest> simpleEquation = equation.GetRange(2, 3);
                evaluateFirst = SimpleParse(simpleEquation);
                return SimpleParse(equation.GetRange(0, 2), evaluateFirst);
            }
        }



        private bool EvaluateExpression(List<CardTest> equation, int userAnswer)
        {
            switch (equation.Count)
            {
                case 3:
                    return userAnswer == SimpleParse(equation);

                case 5:
                    return userAnswer == ComplexParse(equation);
            }
            return false;
        }

        private string DisplayEquation(List<CardTest> equation)
        {
            if (equation.Count == 3)
            {
                char Operator = equation[1].GetDescriptor(equation[1].Suit);
                return $"\n{equation[0].Value} {Operator} {equation[2].Value} = ";
            }
            else if (equation.Count == 5)
            {
                char OperatorOne = equation[1].GetDescriptor(equation[1].Suit);
                char OperatorTwo = equation[3].GetDescriptor(equation[3].Suit);
                return $"\n{equation[0].Value} {OperatorOne} {equation[2].Value} {OperatorTwo} {equation[4].Value} =";
            }
            else
                return "Ivalid Equation Returned";
        }

        private int ShowMenu()
        {
            Console.WriteLine("\nSelect a option: \n");
            Console.WriteLine("1. Instructions");
            Console.WriteLine("2. Deal 3 Cards");
            Console.WriteLine("3. Deal 5 Cards");
            Console.WriteLine("4. Quit");
            while (true)
            {
                Console.Write("> ");
                string? option = Console.ReadLine();
                if (option is not null)
                {
                    int optionValue = int.Parse(option);
                    if (optionValue >= 1 && optionValue < 5)
                    {
                        return optionValue;
                    }
                }
            }
        }
            
        private void DealCardsAndCalculate(int amount)
        {
            List<CardTest> equationToSolve = new List<CardTest>();
            
            equationToSolve.AddRange(this.cardPack.Deal(amount));

            Console.WriteLine(DisplayEquation(equationToSolve));
            Console.WriteLine("Enter your Answer...");
            Console.Write("> ");
            string? answer = Console.ReadLine();
            int numberValue;
            while (true)
            {
                if (int.TryParse(answer, out numberValue))
                {
                    if(EvaluateExpression(equationToSolve, numberValue))
                    {
                        Console.WriteLine("Yay you got it!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That is the wrong answer");
                        break;
                    }
                }
            }

        }

        public void Play()
        {
            bool gameRunning = true;
            while (gameRunning)
            {
                int menuOption = ShowMenu();

                switch (menuOption)
                {
                    case 1:
                        Tutorial tutorial = new Tutorial();
                        break;
                    case 2:
                        DealCardsAndCalculate(3);
                        break;
                    case 3:
                        DealCardsAndCalculate(5);
                        break;
                    case 4:
                        gameRunning = false;
                        break;
                }
            }     
        }
    }
}

using MathsTutor.Packs;
using MathsTutor.Cards;

namespace MathsTutor
{
    internal class MathsApp: MathsParser
    {
        private CardPack cardPack;

        public MathsApp()
        {
            this.cardPack = new CardPack();
            this.cardPack.Shuffle();
        }

        private (bool,int) EvaluateExpression(List<Card> equation, int userAnswer)
        {
            int correctAnswer;
            switch (equation.Count)
            {
                case 3:
                    correctAnswer = SimpleParse(equation);
                    return (userAnswer == correctAnswer, correctAnswer);
                case 5:
                    correctAnswer = ComplexParse(equation);
                    return (userAnswer == correctAnswer,correctAnswer);
                default:
                    throw new ArgumentException("Invalid Equation Format");
            }
        }

        private string DisplayEquation(List<Card> equation)
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
            List<Card> equationToSolve = new List<Card>();
            
            equationToSolve.AddRange(this.cardPack.Deal(amount));

            Console.WriteLine(DisplayEquation(equationToSolve));
            Console.WriteLine("Enter your Answer...");
            string? answer = null;

            int numberValue;
            while (true)
            {
                Console.Write("> ");
                answer = Console.ReadLine();
                if (int.TryParse(answer, out numberValue))
                {
                    (bool, int) EvalExpression = EvaluateExpression(equationToSolve, numberValue);
                    if (EvalExpression.Item1)
                    {
                        Console.WriteLine("Yay you got it!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That is the wrong answer.");
                        Console.WriteLine("The Correct Answer was: ");
                        Console.Write(EvalExpression.Item2);
                        break;
                    }
                }
            }
        }

        public void Play()
        {
            bool gameRunning = true;
            Console.WriteLine("Please Round divisions to the nearest whole number");
            while (gameRunning)
            {
                int menuOption = ShowMenu();

                switch (menuOption)
                {
                    case 1:
                        Tutorial tutorial = new Tutorial();
                        tutorial.StartTutorial();
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

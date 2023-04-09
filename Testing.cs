using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Reflection;
using MathsTutor.Cards;
using MathsTutor.Packs;

namespace MathsTutor
{
    internal class Testing
    {
        private CardPack cards;
        public Testing()
        {   
            this.cards = new CardPack();
            // if false the assert breaks.
        }

        public void Test_DealThreeCards()
        {
            List<Card> cards = this.cards.Deal(3);
            Debug.Assert(cards.Count == 3, "Deal did not return 3 Cards");
            Console.WriteLine("Testing Deal Cards Method with 3: Test Passed!");
        }

        public void Test_DealFiveCards()
        {
            List<Card> cards = this.cards.Deal(5);
            Debug.Assert(cards.Count == 5, "Deal did not return 5 Cards");
            Console.WriteLine("Testing Deal Method with 5: Test Passed");
        }

        public void Test_DealEvenCards()
        {
            List<Card> cards = this.cards.Deal(10);
            Debug.Assert(cards.Count == 0, "Deal should not have returned cards");
            Console.WriteLine("Testing Deal Method with Even number: Test Passed");
        }

        public void Test_EvaluateExpressionThree()
        {
            MathsApp app = new MathsApp();
            List<Card> eq = this.cards.Deal(3);
            int answer;
            int numberOne = eq[0].Value, numberTwo = eq[2].Value;

            OperatorType selectedSuit = eq[1].Suit == OperatorType.DIVIDE ? OperatorType.ADD : eq[1].Suit;
            eq[1].Suit = selectedSuit;

            switch (selectedSuit)
            {
                case OperatorType.ADD:
                    answer = numberOne + numberTwo;
                    break;
                case OperatorType.SUBTRACT:
                    answer = numberOne - numberTwo;
                    break;
                case OperatorType.MULTIPLY:
                    answer = numberOne * numberTwo;
                    break;
                default:
                    answer = 0;
                    break;
            }

            Debug.Assert(app.EvaluateExpression(eq, answer).Item1, "Maths Parser did the maths wrong");
        }

        public void Test_Shuffle()
        {
            CardPack currentCards = this.cards;
            currentCards.Shuffle();
            Thread.Sleep(1000);
            Debug.Assert(currentCards.GetCards().SequenceEqual(currentCards.GetCards()), "Cards Were not shuffled Correctly");
            Console.WriteLine("Testing Shuffle Cards: Test Passed");
        }
            
        

        public void RunTests()
        {
            int testPassed = 0;
            Console.WriteLine("Running Tests!\n");

            Stopwatch timer = Stopwatch.StartNew();

            IEnumerable<MethodInfo> methods =
                from method in typeof(Testing).GetMethods()
                where method.Name.StartsWith("Test_")
                select method;

            foreach (MethodInfo method in methods)
            {
                method.Invoke(this, null);
                testPassed++;
            }
            timer.Stop();

            Console.WriteLine($"\n{testPassed} passed, {methods.ToList().Count} total");
            Console.WriteLine($"Time: {timer.ElapsedMilliseconds/1000}s");
            Console.WriteLine("Ran all tests.");
        }

    }
}

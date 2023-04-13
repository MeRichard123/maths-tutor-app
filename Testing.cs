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
            // initialise the card pack 
            this.cards = new CardPack();
        }

        // Create seperate method for each test prefixed with Test_
        public void Test_DealThreeCards()
        {
            // test to make sure the deal method will deal 3 cards
            List<Card> cards = this.cards.Deal(3);
            Debug.Assert(cards.Count == 3, "Deal did not return 3 Cards");
            Console.WriteLine("Testing Deal Cards Method with 3: Test Passed!");
        }

        public void Test_DealFiveCards()
        {
            // test to make sure the deal method can deal 5 cards
            List<Card> cards = this.cards.Deal(5);
            Debug.Assert(cards.Count == 5, "Deal did not return 5 Cards");
            Console.WriteLine("Testing Deal Method with 5: Test Passed");
        }

        public void Test_DealEvenCards()
        {
            // make sure you can't deal cards if you enter an even number
            // if it's even then there will be floating opertor or number.
            // unary operators are not supported.
            List<Card> cards = this.cards.Deal(10);
            Debug.Assert(cards.Count == 0, "Deal should not have returned cards");
            Console.WriteLine("Testing Deal Method with Even number: Test Passed");
        }

        public void Test_EvaluateExpressionThree()
        {
            // make sure the evaluate method does the maths correctly 
            MathsApp app = new MathsApp();
            List<Card> eq = this.cards.Deal(3);
            int answer;
            int numberOne = eq[0].Value, numberTwo = eq[2].Value;

            // division requires a second input so let's not deal with that
            OperatorType selectedSuit = eq[1].Suit == OperatorType.DIVIDE ? OperatorType.ADD : eq[1].Suit;
            eq[1].Suit = selectedSuit;

            // calualte the answer for comparison
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
            // test shuffle to make sure the two lists are in a different order after shuffle
            // testing code that is random is hard.
            CardPack currentCards = this.cards;
            currentCards.Shuffle();
            Debug.Assert(currentCards.GetCards().SequenceEqual(currentCards.GetCards()), "Cards Were not shuffled Correctly");
            Console.WriteLine("Testing Shuffle Cards: Test Passed");
        }
            
        

        public void RunTests()
        {
            int testPassed = 0;
            Console.WriteLine("Running Tests!\n");

            // start a timer for the tests
            Stopwatch timer = Stopwatch.StartNew();

            // get a list of all the testing method (those that start with Test_
            IEnumerable<MethodInfo> methods =
                from method in typeof(Testing).GetMethods()
                where method.Name.StartsWith("Test_")
                select method;

            // call each test method
            foreach (MethodInfo method in methods)
            {
                method.Invoke(this, null);
                testPassed++;
            }
            timer.Stop();

            Console.WriteLine($"\n{testPassed} passed, {methods.ToList().Count} total");
            Console.WriteLine($"Time: {timer.ElapsedMilliseconds}ms");
            Console.WriteLine("Ran all tests.");
        }

    }
}

using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal class TestPack: Pack, IPack
    {
        static private List<CardTest> cards = new List<CardTest>();
        static private List<CardTest> discard = new List<CardTest>();

        public TestPack()
        {
            foreach (OperatorType suit in Enum.GetValues(typeof(OperatorType)))
            {
                // loop over each possible face
                // 4 suits * 13 faces = 52 cards
                foreach (NumberValues face in Enum.GetValues(typeof(NumberValues)))
                {
                    // create a card using the face and suit
                    CardTest card = new CardTest(face, suit);
                    // add the card to the pack.
                    cards.Add(card);
                }
            }
        }

        public void Shuffle(){
            base.Shuffle(ref cards);
        }

        public override List<CardTest> Deal(in int amount = 1)
        {
            List<CardTest> _deltCards = new List<CardTest>();
            if (cards.Count > amount)
            {
                for (int i = 0; i < amount; i++)
                {
                    _deltCards.Add(cards[i]);
                    cards.RemoveAt(i);
                }
            }
            else
            {
                cards.AddRange(discard);
                Shuffle();
                Deal(amount);
            }
            return _deltCards;
        }

    }
}

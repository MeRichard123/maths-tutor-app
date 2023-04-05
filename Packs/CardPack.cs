using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal class CardPack: Pack, IPack
    {
        static private List<Card> cards = new List<Card>();
        static private List<Card> discard = new List<Card>();

        public CardPack()
        {
            foreach (OperatorType suit in Enum.GetValues(typeof(OperatorType)))
            {
                // loop over each possible face
                // 4 suits * 13 faces = 52 cards
                foreach (NumberValues face in Enum.GetValues(typeof(NumberValues)))
                {
                    // create a card using the face and suit
                    Card card = new Card(face, suit);
                    // add the card to the pack.
                    cards.Add(card);
                }
            }
        }

        public void Shuffle(){
            base.Shuffle(ref cards);
        }

        public override List<Card> Deal(in int amount = 1)
        {
            List<Card> _deltCards = new List<Card>();
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

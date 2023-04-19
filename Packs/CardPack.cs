using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal class CardPack: Pack
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
       
        // Getter for the cards mainly for the Testing class
        public List<Card> GetCards() {
            return cards; 
        }

        // shuffle calling the base shuffle
        public void Shuffle(){
            base.Shuffle(ref cards);
        }
        
        // Method overriding or Dynamic Polymorphism is sort of used here for the deal method
        // but it would make it more useful if there were multiple packs and each implementation is 
        // slightly different. 
        public override List<Card> Deal(in int amount = 1)
        {
            // create a list to hold the cards
            List<Card> _deltCards = new List<Card>();
            // deal making sure there's enough cards and you want an odd number
            if (cards.Count > amount && amount % 2 != 0)
            {
                for (int i = 0; i <= amount-1; i++)
                {
                    // add cards to the return list
                    _deltCards.Add(cards[i]);
                    // add to discard temporarily and then 
                    // add back on the end. 
                    discard.Add(cards[i]);
                    cards.RemoveAt(i);
                    cards.AddRange(discard);
                    discard.Clear();
                }
            }
            return _deltCards;
        }

    }
}

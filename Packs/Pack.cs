using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal class Pack: IPack
    {
        public Random random = new Random();
        public void Shuffle(ref List<CardTest> cards)
        {
            for (int currentCardIndex = 0; currentCardIndex < cards.Count - 1; currentCardIndex++)
            {
                // for each card we pick a random card from the current card to the end 
                int randomIndex = random.Next(currentCardIndex, cards.Count);
                // swap the current card with the random card.
                CardTest currentCard = cards[currentCardIndex];
                cards[currentCardIndex] = cards[randomIndex];
                cards[randomIndex] = currentCard;
            }

        }

        public void Display(List<CardTest> cards)
        {
            foreach (var card in cards)
            {

            }
        }

        public virtual List<CardTest> Deal(in int amount)
        {
            throw new NotImplementedException();
        }
    }
}

using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal class Pack: IPack
    {
        public Random random = new Random();

        /// <summary>
        ///     Shuffle method using a fischer yates shuffle 
        ///     from the previous oop assigment
        /// </summary>
        /// <param name="cards">
        ///     a reference to the list of cards
        ///     using a ref because I want to update the original
        /// </param>
        /// <references>
        /// https://github.com/MeRichard123/oop-assement-one-UoL
        /// </references>
        public void Shuffle(ref List<Card> cards)
        {
            for (int currentCardIndex = 0; currentCardIndex < cards.Count - 1; currentCardIndex++)
            {
                // for each card we pick a random card from the current card to the end 
                int randomIndex = random.Next(currentCardIndex, cards.Count);
                // swap the current card with the random card.
                Card currentCard = cards[currentCardIndex];
                cards[currentCardIndex] = cards[randomIndex];
                cards[randomIndex] = currentCard;
            }

        }

        /// <summary>
        ///     Method mainly for debugging letting you print all the cards
        /// </summary>
        /// <param name="cards">
        ///     List of cards
        /// </param>
        public void Display(List<Card> cards)
        {
            foreach (var card in cards)
            {
                Console.Write($"{card.Show()} ");
            }
        }

        /// <summary>
        ///     Virtual method for each for the actual 
        ///     pack to override
        /// </summary>
        /// <param name="amount">
        ///     the number of cards you want to deal
        /// </param>
        /// <returns>
        ///     returns a list of cards once implemented
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual List<Card> Deal(in int amount)
        {
            throw new NotImplementedException();
        }
    }
}

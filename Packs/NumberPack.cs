using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal class NumberPack : Pack, IPack
    {
        /*
        static private List<ICard> numbers = new List<ICard>();
        static private List<ICard> discard = new List<ICard>();

        public NumberPack() {
           for (int n = 1; n < 14; n++)
            {
                NumberCard numberCard = new NumberCard(n);
                numbers.Add(numberCard);
            }
        }

        public void Shuffle(){
            base.Shuffle(ref numbers);
        }

        public override List<ICard> Deal(in int amount = 1)
        {
            List<ICard> _deltCards = new List<ICard>();
            if (numbers.Count > amount)
            {
                for (int i = 0; i < amount; i++)
                {
                    _deltCards.Add(numbers[i]);
                    numbers.RemoveAt(i);
                }
            }
            else
            {
                numbers.AddRange(discard);
                Shuffle();
                Deal(amount);
            }
            return _deltCards;
        }*/
    }
}

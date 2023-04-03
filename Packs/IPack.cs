using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal interface IPack
    {
        void Shuffle(ref List<ICard> cards);

        void Display(List<ICard> cards);

        List<ICard> Deal(in int amount);
    }
}

using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal interface IPack
    {
        abstract void Shuffle(ref List<Card> cards);

        abstract void Display(List<Card> cards);

        abstract List<Card> Deal(in int amount);
    }
}

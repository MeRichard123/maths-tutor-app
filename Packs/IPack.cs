using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal interface IPack
    {
        void Shuffle(ref List<Card> cards);

        void Display(List<Card> cards);

        List<Card> Deal(in int amount);
    }
}

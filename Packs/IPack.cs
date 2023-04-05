using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal interface IPack
    {
        void Shuffle(ref List<CardTest> cards);

        void Display(List<CardTest> cards);

        List<CardTest> Deal(in int amount);
    }
}

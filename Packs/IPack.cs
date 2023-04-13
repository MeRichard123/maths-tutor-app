using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    // using an interface to ensure I implement all the 
    // needed behaviour. If I don't C# will yell at me 
    internal interface IPack
    {
        abstract void Shuffle(ref List<Card> cards);

        abstract void Display(List<Card> cards);

        abstract List<Card> Deal(in int amount);
    }
}

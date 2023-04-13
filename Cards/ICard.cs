namespace MathsTutor.Cards
{
    // interface for the card to ensure I implement
    // the needed features otherwise the compiler will 
    // yell at me.
    interface ICard
    {
        abstract string Show();
        abstract int Value { get; set; }
        abstract OperatorType Suit { get; set; }
        abstract char GetDescriptor(OperatorType opType);
    }
}

namespace MathsTutor.Cards
{
    interface ICard
    {
        abstract string Show();
        abstract int Value { get; set; }
        abstract OperatorType Suit { get; set; }
        abstract char GetDescriptor(OperatorType opType);
    }
}

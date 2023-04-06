using System.ComponentModel;

namespace MathsTutor.Cards
{
    // store the suit types of the card
    public enum OperatorType
    {
        [Description("-")]
        SUBTRACT = 1,
        [Description("+")]
        ADD = 2,
        [Description("*")]
        MULTIPLY = 3,
        [Description("/")]
        DIVIDE = 4,
    }

    // store the different faces.
    public enum NumberValues
    {
        ONE = 1,
        TWO = 2,
        THREE = 3,
        FOUR = 4,
        FIVE = 5,
        SIX = 6,
        SEVEN = 7,
        EIGHT = 8,
        NINE = 9,
        TEN = 10,
        ELEVEN = 11,
        TWELVE = 12,
        THIRTEEN = 13,
    }

    public class Card : ICard
    {
        // private varaibles encapsulated
        private OperatorType suitValue;
        private NumberValues cardValue;

        // constructor for card 
        public Card(NumberValues value, OperatorType suit)
        {
            suitValue = suit;
            cardValue = value;
        }

        public string Show()
        {
            return $"({Value}, {(int)Suit}), ";
        }

        // validation method for creating a card ensuring it isn't too big. 
        private bool CheckValue(int value)
        {
            if (value <= 13 && value >= 1)
            {
                return true;
            }
            else if (value > 13)
            {
                Console.WriteLine($"Cannot use Value {value} it is too big.");
                return false;
            }
            else if (value < 1)
            {
                Console.WriteLine($"Cannot use Value {value} it is too small.");
                return false;
            }
            else
            {
                Console.WriteLine("Your value is simply wrong.");
                return false;
            }
        }
        
        // ENCAPSULATION 
        // getters and setters for the value.
        public int Value
        {
            get
            {
                // return numberic value of card
                return (int)cardValue;
            }

            set
            {
                // set the numberic value if valid 
                if (CheckValue((int)value)) {
                    cardValue = (NumberValues)value;  
                }
            }
        }

        public char GetDescriptor(OperatorType opType)
        {
            switch (opType)
            {
                case OperatorType.ADD:
                    return '+';
                case OperatorType.SUBTRACT:
                    return '-';
                case OperatorType.MULTIPLY:
                    return '*';
                case OperatorType.DIVIDE:
                    return '/';
            }
            return '\0';
        }

        // get and set for suit
        public OperatorType Suit {
            get
            {
                return suitValue;
            }
            set
            {
                suitValue = value;         
            }
        }
    }
}


using System.ComponentModel;

namespace MathsTutor.Cards
{

    public enum Operator
    {
        [Description("+")]
        ADD,

        [Description("-")]
        SUBTRACT,

        [Description("/")]
        DIVIDE,

        [Description("*")]
        MULTIPLY,
    }
    public class OperatorCard: ICard
    {
        private Operator operator_;

        public OperatorCard(Operator op)
        {
            this.operator_ = op;
        }

        public Operator OperatorType
        {
            get { 
                return operator_;
            }
        }

        public string Show()
        {
            return operator_.ToString();
        }
    }
}

namespace MathsTutor.Cards
{
    internal class NumberCard: ICard
    {
        private int operand;
        public NumberCard(int operandConstr)
        {
            if(CheckValidOperand(operandConstr))
            {
                operand = operandConstr;
            }
            else
            {
                throw new ArgumentException("Invalid Operand must be in range 1-14");
            }
        }

        private bool CheckValidOperand(int operand)
        {
            return this.operand > 1 && this.operand < 14;
        }

        public string Show()
        {
            return operand.ToString();
        }
    }
}

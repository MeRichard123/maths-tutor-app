using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal class OperatorPack : Pack, IPack
    {
        static private List<ICard> operators = new List<ICard>();
        public OperatorPack() {
           foreach (Operator op in Enum.GetValues(typeof(Operator)))
            {
                OperatorCard opCard = new OperatorCard(op);
                operators.Add(opCard);
            }
        }

        public void Shuffle(){
            base.Shuffle(ref operators);
        }

        public override List<ICard> Deal(in int amount)
        {
            return operators;
        }
    }
}

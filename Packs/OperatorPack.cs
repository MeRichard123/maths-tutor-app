﻿using MathsTutor.Cards;

namespace MathsTutor.Packs
{
    internal class OperatorPack : Pack, IPack
    {
        /*
        static private List<ICard> operators = new List<ICard>();
        static private List<ICard> discard = new List<ICard>();

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

        public override List<ICard> Deal(in int amount = 1)
        {
            List<ICard> _deltCards = new List<ICard>();
            if (operators.Count > amount)
            {
                for (int i = 0; i < amount; i++)
                {
                    _deltCards.Add(operators[i]);
                    operators.RemoveAt(i);
                }
            }
            else
            {
                operators.AddRange(discard);
                Shuffle();
                Deal(amount);
            }
            return _deltCards;
        } */
    }
}
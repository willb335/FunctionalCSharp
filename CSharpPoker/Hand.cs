using System;
using System.Collections.Generic;
using System.Linq;


namespace CSharpPoker
{
    public class Hand
    {

        public Hand()
        {
            Cards = new List<Card>();
        }

        public List<Card> Cards { get; }

        public void Draw(Card card)
        {
            Cards.Add(card);
        }

        public Card HighCard()
        {
            return Cards.Aggregate( (a, c) =>
            {
                var card = (int)c.Value;

                if (card > (int)a.Value)
                {
                    a = c;
                }
                return a;

            });
        }
    }
}

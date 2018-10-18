using System;
using System.Collections.Generic;
using System.Linq;
using static CSharpPoker.FiveCardPokerScorer;


namespace CSharpPoker
{
    public class Hand
    {

        public Hand()
        {
            Cards = new List<Card>();
        }

        public List<Card> Cards { get; }

        public void Draw(Card card) => Cards.Add(card);

    }
}

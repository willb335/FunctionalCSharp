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

        public void Draw(Card card) => Cards.Add(card);

        public Card HighCard() => Cards.Aggregate((a, c) => ((int)c.Value > (int)a.Value) ? c : a);

        public HandRank GetHandRank()
        {
            if (HasRoyalFlush()) return HandRank.RoyalFlush;
            if (HasFlush()) return HandRank.Flush;

            return HandRank.HighCard;

        }

        bool HasFlush() => Cards.All(c => Cards.First().Suit == c.Suit);

        bool HasRoyalFlush() => HasFlush() && Cards.All(c => (int)c.Value > 9);
    }
}

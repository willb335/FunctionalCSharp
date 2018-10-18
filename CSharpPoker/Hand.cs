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
            if (HasFourOfAKind()) return HandRank.FourOfAKind;
            if (HasFullHouse()) return HandRank.FullHouse;
            if (HasFlush()) return HandRank.Flush;
            if (HasThreeOfAKind()) return HandRank.ThreeOfAKind;
            if (HasPair()) return HandRank.Pair;

            return HandRank.HighCard;

        }

        bool HasFlush() => Cards.All(c => Cards.First().Suit == c.Suit);

        bool HasRoyalFlush() => HasFlush() && Cards.All(c => (int)c.Value > 9);

        bool HasPair() => Cards.GroupBy(n => n.Value).Any(c => c.Count() == 2);

        bool HasThreeOfAKind() => Cards.GroupBy(n => n.Value).Any(c => c.Count() == 3);

        bool HasFourOfAKind() => Cards.GroupBy(n => n.Value).Any(c => c.Count() == 4);

        bool HasFullHouse() => Cards.GroupBy(n => n.Value).All(c => c.Count() == 3 || c.Count() == 2);



    }
}

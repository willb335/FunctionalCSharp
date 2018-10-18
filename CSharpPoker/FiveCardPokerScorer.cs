using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPoker
{
    public static class FiveCardPokerScorer
    {
        public static Card HighCard(IEnumerable<Card> cards) => cards.Aggregate((a, c) => ((int)c.Value > (int)a.Value) ? c : a);

        public static bool HasFlush(IEnumerable<Card> cards) => cards.All(c => cards.First().Suit == c.Suit);

        public static bool HasRoyalFlush(IEnumerable<Card> cards) => HasFlush(cards) && cards.All(c => (int)c.Value > 9);

        public static bool HasPair(IEnumerable<Card> cards) => cards.GroupBy(n => n.Value).Any(c => c.Count() == 2);

        public static bool HasThreeOfAKind(IEnumerable<Card> cards) => cards.GroupBy(n => n.Value).Any(c => c.Count() == 3);

        public static bool HasFourOfAKind(IEnumerable<Card> cards) => cards.GroupBy(n => n.Value).Any(c => c.Count() == 4);

        public static bool HasFullHouse(IEnumerable<Card> cards) => HasThreeOfAKind(cards) && HasPair(cards);

        public static bool HasStraight(IEnumerable<Card> cards) =>
            cards.OrderBy(card => card.Value).SelectConsecutive((n, next) => n.Value + 1 == next.Value).All(value => value);

        public static bool HasStraightFlush(IEnumerable<Card> cards) => HasStraight(cards) && HasFlush(cards);

    }
}

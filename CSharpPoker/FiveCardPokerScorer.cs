using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPoker
{
    public static class FiveCardPokerScorer
    {
        public static Card HighCard(IEnumerable<Card> cards) => cards.Aggregate((a, c) => ((int)c.Value > (int)a.Value) ? c : a);

        static bool HasFlush(IEnumerable<Card> cards) => cards.All(c => cards.First().Suit == c.Suit);

        static bool HasRoyalFlush(IEnumerable<Card> cards) => HasFlush(cards) && cards.All(c => (int)c.Value > 9);

        static bool HasPair(IEnumerable<Card> cards) => cards.GroupBy(n => n.Value).Any(c => c.Count() == 2);

        static bool HasTwoPair(IEnumerable<Card> cards) => cards.GroupBy(n => n.Value).Count(c => c.Count() == 2) == 2;

        static bool HasThreeOfAKind(IEnumerable<Card> cards) => cards.GroupBy(n => n.Value).Any(c => c.Count() == 3);

        static bool HasFourOfAKind(IEnumerable<Card> cards) => cards.GroupBy(n => n.Value).Any(c => c.Count() == 4);

        static bool HasFullHouse(IEnumerable<Card> cards) => HasThreeOfAKind(cards) && HasPair(cards);

        static bool HasStraight(IEnumerable<Card> cards) =>
           cards.OrderBy(card => card.Value).SelectConsecutive((n, next) => n.Value + 1 == next.Value).All(value => value);

        static bool HasStraightFlush(IEnumerable<Card> cards) => HasStraight(cards) && HasFlush(cards);


        // A list of ranks gives added flexibility to how hand ranks can be scored.
        // Each ranker has an Eval delegate that returns a bool
        public static HandRank GetHandRank(IEnumerable<Card> cards) => Rankings()
                           .OrderByDescending(card => card.Rank)
                           .First(rule => rule.Eval(cards)).Rank;

        static List<Ranker> Rankings() =>
          new List<Ranker>
          {
                       new Ranker(cards => HasRoyalFlush(cards), HandRank.RoyalFlush),
                       new Ranker(cards => HasStraightFlush(cards), HandRank.StraightFlush),
                       new Ranker(cards => HasFourOfAKind(cards), HandRank.FourOfAKind),
                       new Ranker(cards => HasFullHouse(cards), HandRank.FullHouse),
                       new Ranker(cards => HasFlush(cards), HandRank.Flush),
                       new Ranker(cards => HasStraight(cards), HandRank.Straight),
                       new Ranker(cards => HasThreeOfAKind(cards), HandRank.ThreeOfAKind),
                       new Ranker(cards => HasTwoPair(cards), HandRank.TwoPair),
                       new Ranker(cards => HasPair(cards), HandRank.Pair),
                       new Ranker(cards => true, HandRank.HighCard),
          };

    }


}

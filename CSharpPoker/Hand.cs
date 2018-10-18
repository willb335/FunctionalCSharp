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

        public Card HighCard() => Cards.Aggregate((a, c) => ((int)c.Value > (int)a.Value) ? c : a);

        public HandRank GetHandRank()
        {
            if (HasRoyalFlush(Cards)) return HandRank.RoyalFlush;
            if (HasStraightFlush(Cards)) return HandRank.StraightFlush;
            if (HasFourOfAKind(Cards)) return HandRank.FourOfAKind;
            if (HasFullHouse(Cards)) return HandRank.FullHouse;
            if (HasFlush(Cards)) return HandRank.Flush;
            if (HasStraight(Cards)) return HandRank.Straight;
            if (HasThreeOfAKind(Cards)) return HandRank.ThreeOfAKind;
            if (HasPair(Cards)) return HandRank.Pair;

            return HandRank.HighCard;

        }

    }
}

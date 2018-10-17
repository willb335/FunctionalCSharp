using Xunit;
using System.Linq;
using FluentAssertions;


namespace CSharpPoker.Tests
{
    public class HandTests
    {
        [Fact]
        public void CanCreateHand()
        {
            var hand = new Hand();

            //Assert.False(hand.Cards.Any());
            hand.Cards.Any().Should().BeFalse();

        }

        [Fact]
        public void CanHandDrawCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);
            var hand = new Hand();

            hand.Draw(card);

            //Assert.Equal(hand.Cards.First(), card);
            card.Should().Be(hand.Cards.First());

        }

        [Fact]
        public void CanGetHighCard()
        {
            var hand = new Hand();

            hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

            //Assert.Equal(CardValue.King, hand.HighCard().Value);
            hand.HighCard().Value.Should().Be(CardValue.King);
        }

        [Fact]
        public void CanScoreHighCard()
        {
            var hand = new Hand();

            hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

            //Assert.Equal(HandRank.HighCard, hand.GetHandRank());
            hand.GetHandRank().Should().Be(HandRank.HighCard);

        }

        [Fact]
        public void CanScoreFlush()
        {
            var hand = new Hand();

            hand.Draw(new Card(CardValue.Two, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Three, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Five, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Six, CardSuit.Spades));

            //Assert.Equal(HandRank.Flush, hand.GetHandRank());
            hand.GetHandRank().Should().Be(HandRank.Flush);
        }

        [Fact]
        public void CanScoreRoyalFlush()
        {
            var hand = new Hand();

            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
            hand.Draw(new Card(CardValue.King, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

            //Assert.Equal(HandRank.RoyalFlush, hand.GetHandRank());
            hand.GetHandRank().Should().Be(HandRank.RoyalFlush);
        }

    }
}

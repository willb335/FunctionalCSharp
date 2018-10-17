using System;
using Xunit;

namespace CSharpPoker.Tests
{
    public class CardTests
    {
        [Fact]
        public void CanCreateCard()
        {
            var card = new Card();
            Assert.NotNull(card);
        }

        [Fact]
        public void CanCreateCardWithValue() 
        {
            var card = new Card(CardValue.Ace, CardSuit.Clubs);

            Assert.Equal(CardSuit.Clubs, card.Suit);
            Assert.Equal(CardValue.Ace, card.Value);
        }
    }
}

﻿using System;
namespace CSharpPoker
{
    public class Card
    {
        public Card()
        {

        }

        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }

        public CardValue Value { get; }
        public CardSuit Suit { get; }

        public override string ToString() => $"{Value} of {Suit}";

    }
}

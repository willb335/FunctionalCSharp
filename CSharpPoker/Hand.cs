﻿using System.Collections.Generic;


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

using System;
using System.Collections.Generic;

namespace CSharpPoker
{
    public class Ranker
    {
        public Ranker(Func<IEnumerable<Card>, bool> eval, HandRank rank)
        {
            Eval = eval;
            Rank = rank;
        }

        public Func<IEnumerable<Card>, bool> Eval { get; }

        public HandRank Rank { get; }

    }
}

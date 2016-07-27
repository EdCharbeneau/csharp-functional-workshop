using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPoker
{
    public class Ranker
    {
        public Ranker(Func<IEnumerable<Card>, bool> eval, HandRank strength)
        {
            Eval = eval;
            Strength = strength;
        }

        public Func<IEnumerable<Card>, bool> Eval { get; }

        public HandRank Strength { get; }

    }
}
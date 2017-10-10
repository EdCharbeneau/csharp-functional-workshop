/*

This class is only needed for C# 6.0 where System.ValueTuple is not available.

Projects using .NET Standard 2.0 may omit this class.

 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPoker
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
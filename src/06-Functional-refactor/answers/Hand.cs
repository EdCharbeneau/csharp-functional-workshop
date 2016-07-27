using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpPoker;

namespace CsharpPoker
{
    public class Hand
    {
        private readonly List<Card> cards = new List<Card>();

        public IEnumerable<Card> Cards { get { return cards; } }

        public void Draw(Card card) => cards.Add(card);

        public Card HighCard() => cards.Aggregate((result, nextCard) => result.Value > nextCard.Value ? result : nextCard);

    }

}
using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPoker
{
    public class FiveCardPokerScorer
    {
        public HandRank GetScore(Hand hand) => Rankings().First(rule => rule.Eval(hand.Cards)).Strength;

        private List<Ranker> Rankings() =>
            new List<Ranker>
            {
                        new Ranker(cards => HasRoyalFlush(cards), HandRank.RoyalFlush),
                        new Ranker(cards => HasStraightFlush(cards), HandRank.StraightFlush),
                        new Ranker(cards => HasFourOfAKind(cards), HandRank.FourOfAKind),
                        new Ranker(cards => HasFullHouse(cards), HandRank.FullHouse),
                        new Ranker(cards => HasFlush(cards), HandRank.Flush),
                        new Ranker(cards => HasStraight(cards), HandRank.Straight),
                        new Ranker(cards => HasThreeOfAKind(cards), HandRank.ThreeOfAKind),
                        new Ranker(cards => HasPair(cards), HandRank.Pair),
                        new Ranker(cards => true, HandRank.HighCard),
            };

        public Card HighCard(IEnumerable<Card> cards) => cards.Aggregate((result, nextCard) => result.Value > nextCard.Value ? result : nextCard);

        private bool HasFlush(IEnumerable<Card> cards) => cards.All(c => cards.First().Suit == c.Suit);

        private bool HasRoyalFlush(IEnumerable<Card> cards) => HasFlush(cards) && cards.All(c => c.Value > CardValue.Nine);

        private bool HasOfAKind(IEnumerable<Card> cards, int num) => cards.ToPairs().Any(c => c.Value == num);

        private bool HasPair(IEnumerable<Card> cards) => HasOfAKind(cards, 2);
        private bool HasThreeOfAKind(IEnumerable<Card> cards) => HasOfAKind(cards, 3);
        private bool HasFourOfAKind(IEnumerable<Card> cards) => HasOfAKind(cards, 4);

        private bool HasFullHouse(IEnumerable<Card> cards) => HasThreeOfAKind(cards) && HasPair(cards);

        private bool HasStraight(IEnumerable<Card> cards) => cards.OrderBy(card => card.Value).SelectConsecutive((n, next) => n.Value + 1 == next.Value).All(value => value);

        private bool HasStraightFlush(IEnumerable<Card> cards) => HasStraight(cards) && HasFlush(cards);
    }
}
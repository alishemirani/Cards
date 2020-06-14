using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestCard
    {
        [TestCase(CardType.Clubs, 15)]
        [TestCase(CardType.Spades, 0)]
        [TestCase(CardType.Hearts, -1)]
        public void testInvalidCards(CardType cardType, int number)
        {
            Assert.Throws<ArgumentException>(() => new Card(cardType, number));
        }
        
        [TestCase(CardType.Clubs, 1)]
        [TestCase(CardType.Spades, 13)]
        [TestCase(CardType.Hearts, 4)]
        public void testValidCards(CardType cardType, int number)
        {
            var card = new Card(cardType, number);
        }

        [TestCase(CardType.Clubs, 1)]
        [TestCase(CardType.Spades, 8)]
        [TestCase(CardType.Diamonds, 13)]
        public void testEqualCards(CardType cardType, int number) {
            Assert.AreEqual(new Card(cardType, number), new Card(cardType, number));
        }

        [TestCase]
        public void testCardNotEqualsWithNull() {
            Card card1 = new Card(CardType.Hearts, 1);
            Assert.False(card1.Equals(null));
        }

        [TestCase]
        public void testCardNotEqualsWithOtherType() {
            Card card1 = new Card(CardType.Hearts, 1);
            Assert.False(card1.Equals("One"));
        }
    }
}
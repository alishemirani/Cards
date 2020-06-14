using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestCardDeck
    {
        [TestCase]
        public void testCardUniqueness() {

            int numberOfCards = 4 * 13;
            ISet<Card> cardSet = new HashSet<Card>();
            var cardDeck = CardDeckFactory.Create();

            for (int i=0;i<numberOfCards;i++) {
                cardSet.Add(cardDeck.DealOneCard());
            }

            Assert.AreEqual(cardSet.Count, numberOfCards);
        }

        [TestCase]
        public void testCardUniquenessWithShuffle() {

            //Arrange
            IRandomNumberGenerator numberGenerator = new RandomNumberGenerator();
            int numberOfCards = 4 * 13;
            ISet<Card> cardSet = new HashSet<Card>();
            var cardDeck = CardDeckFactory.Create();

            //Act
            for (int i=0;i<numberOfCards;i++) {
                cardDeck.Shuffle(numberGenerator);
                cardSet.Add(cardDeck.DealOneCard());
            }

            //Assert
            Assert.AreEqual(cardSet.Count, numberOfCards);
        }

        [TestCase]
        public void testTwoDeckInOne() {
            
            //Arrange
            IRandomNumberGenerator numberGenerator = new RandomNumberGenerator();
            int numberOfCards = 4 * 13;
            ISet<Card> cardSet = new HashSet<Card>();
            var cardDeck = CardDeckFactory.Create();
            List<Card> twoDeckInOne = new List<Card>(cardDeck.Cards);
            twoDeckInOne.AddRange(cardDeck.Cards);
            var twoCardDeck = new CardDeck(twoDeckInOne);

            //Act
            for (int i=0;i<numberOfCards*2;i++) {
                twoCardDeck.Shuffle(numberGenerator);
                cardSet.Add(twoCardDeck.DealOneCard());
            }
            
            //Assert
            Assert.AreEqual(cardSet.Count, numberOfCards);
        }

    }

}
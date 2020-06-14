using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;

/// <summary>
/// a class that hold the deck of cards
/// </summary>
public class CardDeck {
    private int topCardIndex = 0;
    private List<Card> cards;
    private Guid id;
    public Guid Id => id;
    public int TopCardIndex => topCardIndex;
    public ReadOnlyCollection<Card> Cards => cards.AsReadOnly();
    public CardDeck(Guid id, List<Card> cards, int topCardIndex) {
        this.id = id;
        this.cards = cards;
        this.topCardIndex = topCardIndex;
    }

    public CardDeck(List<Card> cards) : this(Guid.NewGuid(), cards, 0) {}

    /// <summary>
    /// shuffle the remaining cards in the deck
    /// </summary>
    public void Shuffle(IRandomNumberGenerator numberGenerator) {
        int shuffleBaseIndex = topCardIndex;
        while (shuffleBaseIndex < cards.Count) {
            int indexToSwap = numberGenerator.Between(shuffleBaseIndex, cards.Count -1);

            //swap items
            Card tempCard = cards[indexToSwap];
            cards[indexToSwap] = cards[shuffleBaseIndex];
            cards[shuffleBaseIndex++] = tempCard;
        }
    }

    /// <summary>
    /// deal one card from the top of the deck
    /// </summary>
    /// <returns>a card from the top of the deck and if no cards left return null</returns>
    public Card DealOneCard() {
        return topCardIndex < cards.Count ? cards[topCardIndex++] : null;
    }
}
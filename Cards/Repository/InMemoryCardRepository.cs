using System;
using System.Collections.Generic;

/// <summary>
/// in memmory card repository version, this class is not thread safe
/// </summary>
public class InMemoryCardRepository : ICardRepository
{
    Dictionary<Guid, CardDeck> cardCollection = new Dictionary<Guid, CardDeck>();
    public CardDeck LoadCardDeckById(Guid cardDeckId)
    {
        if (cardCollection.ContainsKey(cardDeckId)) {
            return cardCollection[cardDeckId];
        }
        return null;
    }

    public void Save(CardDeck cardDeck)
    {
        if (cardCollection.ContainsKey(cardDeck.Id)) {
            cardCollection[cardDeck.Id] = cardDeck;
        } else {
            cardCollection.Add(cardDeck.Id, cardDeck);
        }
    }
}
using System;

public interface ICardRepository {
    CardDeck LoadCardDeckById(Guid cardDeckId);
    void Save(CardDeck cardDeck);
}
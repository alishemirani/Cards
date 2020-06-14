using System;
using System.Collections.Generic;
using System.Linq;

public class CardDeckFactory {
    public static CardDeck Create() {
        return new CardDeck(InitDeck());
    }
    private static List<Card> InitDeck() {
        List<Card> cardList = new List<Card>();
        List<CardType> cardTypes = new List<CardType>(Enum.GetValues(typeof(CardType)).Cast<CardType>());
        cardTypes.ForEach(t => {
            for (int i=Card.CARD_NUMBER_LOW;i<=Card.CARD_NUMBER_HIGH;i++) {
                cardList.Add(new Card(t, i));
            }
        });
        return cardList;
    }
}
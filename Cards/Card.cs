using System;

/// <summary>
/// value object representing a card
/// </summary>
public class Card {

    /// <summary>
    /// the lowest number of card per card type
    /// </summary>
    public static readonly int CARD_NUMBER_LOW = 1;
    /// <summary>
    /// separator character used to separate cardtype and cardnumber in string representation of this class
    /// </summary>
    private static readonly char SEPARATOR = ',';
    /// <summary>
    /// the highest number of card per card type which is King
    /// </summary>
    public static readonly int CARD_NUMBER_HIGH = 13; 
    public int Number {get; private set;}
    public CardType CardType {get; private set;}
    public Card(CardType cardType, int number) {
        if (number < CARD_NUMBER_LOW || number > CARD_NUMBER_HIGH) {
            throw new ArgumentException($"card number must be in the range of [{CARD_NUMBER_LOW},{CARD_NUMBER_HIGH}]");
        }
        this.Number = number;
        this.CardType = cardType;
    }

    public override string ToString() {
        return $"{(int)CardType}{SEPARATOR}{Number}";
    }

    public override bool Equals(object obj)
    {   
        if (obj == null || obj.GetType() != typeof(Card)) {
            return false;
        }
        Card card = obj as Card;
        return card.CardType == CardType && card.Number == Number;
    }
    
    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
}
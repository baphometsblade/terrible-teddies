using System;

// Card effects are handled through the ICardEffect interface and its implementations.
public interface ICardEffect
{
    void Execute(Player player, Card card);
}

public class HealEffect : ICardEffect
{
    public void Execute(Player player, Card card)
    {
        player.HealthPoints += card.AttackPoints;
    }
}

public class DamageEffect : ICardEffect
{
    public void Execute(Player player, Card card)
    {
        player.HealthPoints -= card.AttackPoints;
    }
}

// Represents a single card in the game with its properties and the ability to be played.
[Serializable]
public class Card
{
    private string cardName;
    private int attackPoints;
    private int defensePoints;
    private string effectDescription;
    private ICardEffect effect;

    // Constructor to create a new card with default values.
    public Card()
    {
        cardName = "Default Card";
        attackPoints = 0;
        defensePoints = 0;
        effectDescription = "No effect";
        effect = null;
    }

    // Constructor to create a new card with specified values and effect.
    public Card(string name, int attack, int defense, ICardEffect cardEffect)
    {
        cardName = name;
        attackPoints = attack;
        defensePoints = defense;
        effect = cardEffect;
    }

    // Method to play the card, affecting the player who played it.
    public void PlayCard(Player player)
    {
        effect?.Execute(player, this);
    }

    // Properties to access the card's private fields.
    public string CardName
    {
        get => cardName;
        set => cardName = value;
    }

    public int AttackPoints
    {
        get => attackPoints;
        set => attackPoints = value;
    }

    public int DefensePoints
    {
        get => defensePoints;
        set => defensePoints = value;
    }

    public string EffectDescription
    {
        get => effectDescription;
        set => effectDescription = value;
    }

    // Method to set the card's effect.
    public void SetEffect(ICardEffect cardEffect)
    {
        effect = cardEffect;
    }
}

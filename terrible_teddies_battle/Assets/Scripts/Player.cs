## Assets/Scripts/Player.cs
using System.Collections.Generic;

// Represents a player in the game with a hand of cards and health points.
public class Player
{
    private List<Card> hand; // The player's current hand of cards.
    private int healthPoints; // The player's health points.

    // Constructor to create a new player with default values.
    public Player()
    {
        hand = new List<Card>();
        healthPoints = 20; // Default health points value.
    }

    // Method for the player to draw a card from the deck and add it to their hand.
    public void DrawCard(Card card)
    {
        if (card != null)
        {
            hand.Add(card);
        }
    }

    // Method for the player to play a card from their hand.
    public void PlayCard(Card card)
    {
        if (hand.Contains(card))
        {
            card.PlayCard(this); // Play the card and apply its effects to the player.
            hand.Remove(card); // Remove the card from the hand after playing it.
        }
    }

    // Method for the player to end their turn.
    public void EndTurn()
    {
        // This method could be expanded to include end-of-turn mechanics.
        // Currently, it serves as a placeholder for future game logic.
    }

    // Properties to access the player's private fields.
    public List<Card> Hand
    {
        get => hand;
        // The hand should not be set from outside, so no setter is provided.
    }

    public int HealthPoints
    {
        get => healthPoints;
        set => healthPoints = value; // Allow external modification of health points.
    }
}

## Assets/Scripts/AIPlayer.cs
using System.Collections.Generic;
using System.Linq;

// AIPlayer class inherits from Player and overrides the DecidePlay method to implement AI behavior.
public class AIPlayer : Player
{
    // Constructor to create a new AIPlayer with default values.
    public AIPlayer() : base()
    {
    }

    // Method for the AI to decide which card to play from its hand.
    public Card DecidePlay()
    {
        // Simple AI logic to play the card with the highest attack points.
        // This can be replaced with more complex AI behavior as needed.
        Card cardToPlay = Hand.OrderByDescending(card => card.AttackPoints).FirstOrDefault();

        // If there are no cards to play, return null.
        if (cardToPlay == null)
        {
            return null;
        }

        // Play the selected card and return it.
        PlayCard(cardToPlay);
        return cardToPlay;
    }
}

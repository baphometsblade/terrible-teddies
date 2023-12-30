using System.Collections.Generic;
using UnityEngine;

// GameManager class manages the game state and flow.
public class GameManager : MonoBehaviour
{
    private Player player1;
    private Player player2;
    private List<Card> deck;
    private bool isPlayer1Turn;
    private UIManager uiManager;

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        player1 = new Player();
        player2 = new AIPlayer();
        deck = new List<Card>(); // The deck should be populated with Card instances elsewhere.
        uiManager = FindObjectOfType<UIManager>(); // Find and assign the UIManager instance.
    }

    // Method to start the game.
    public void StartGame()
    {
        // Initialize players' health and hands.
        player1.HealthPoints = 20;
        player2.HealthPoints = 20;
        player1.DrawCard(DealCard());
        player2.DrawCard(DealCard());

        // Update UI to reflect the game start state.
        uiManager.UpdateHealthDisplay(player1.HealthPoints);
        uiManager.UpdateHealthDisplay(player2.HealthPoints);
        uiManager.UpdateHandDisplay(player1.Hand);
        uiManager.UpdateHandDisplay(player2.Hand);

        // Set the initial turn.
        isPlayer1Turn = true;
    }

    // Method to end the game with a message.
    public void EndGame(string message)
    {
        uiManager.ShowEndGameMessage(message);
        // Additional logic to properly end the game, such as disabling player input, can be added here.
    }

    // Method to handle the transition to the next turn.
    public void NextTurn()
    {
        isPlayer1Turn = !isPlayer1Turn;

        if (isPlayer1Turn)
        {
            player1.DrawCard(DealCard());
        }
        else
        {
            player2.DrawCard(DealCard());
        }

        // Update UI to reflect the new turn state.
        uiManager.UpdateHealthDisplay(player1.HealthPoints);
        uiManager.UpdateHealthDisplay(player2.HealthPoints);
        uiManager.UpdateHandDisplay(player1.Hand);
        uiManager.UpdateHandDisplay(player2.Hand);

        // Check for win conditions after a turn transition.
        CheckWinConditions();
    }

    // Method to deal a card from the deck.
    private Card DealCard()
    {
        if (deck.Count > 0)
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            return card;
        }
        else
        {
            // TODO: Implement reshuffling of the discard pile into the deck.
            // For now, return null to indicate no more cards can be drawn.
            return null;
        }
    }

    // Method to check for win conditions.
    private void CheckWinConditions()
    {
        if (player1.HealthPoints <= 0)
        {
            EndGame("Player 2 wins!");
        }
        else if (player2.HealthPoints <= 0)
        {
            EndGame("Player 1 wins!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1Turn)
        {
            // TODO: Implement Player 1's turn logic, handling player input.
        }
        else
        {
            // AI Player's turn logic
            Card cardToPlay = player2.DecidePlay();
            if (cardToPlay != null)
            {
                // AI plays the card
                player2.PlayCard(cardToPlay);
                // Update the game state and UI after AI plays a card
                uiManager.UpdateHandDisplay(player2.Hand);
                uiManager.UpdateHealthDisplay(player1.HealthPoints);
                uiManager.UpdateHealthDisplay(player2.HealthPoints);
                NextTurn(); // Proceed to the next turn
            }
        }
    }
}

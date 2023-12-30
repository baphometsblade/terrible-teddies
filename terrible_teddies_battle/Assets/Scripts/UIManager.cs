using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UIManager class handles all UI updates in the game.
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text playerHealthText; // Text UI for displaying player's health.
    [SerializeField] private Text opponentHealthText; // Text UI for displaying opponent's health.
    [SerializeField] private GameObject handPanel; // Panel that holds the card UI elements.
    [SerializeField] private GameObject cardPrefab; // Prefab for a card UI element.

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        ValidateUIComponents();
    }

    // Method to update the health display for a single player.
    public void UpdateHealthDisplay(int playerHealth)
    {
        if (playerHealthText != null)
        {
            playerHealthText.text = $"Health: {playerHealth}";
        }
    }

    // Method to update the health display for both players.
    public void UpdateHealthDisplays(int playerHealth, int opponentHealth)
    {
        UpdateHealthDisplay(playerHealth);
        if (opponentHealthText != null)
        {
            opponentHealthText.text = $"Health: {opponentHealth}";
        }
    }

    // Method to update the hand display with the current hand of cards.
    public void UpdateHandDisplay(List<Card> hand)
    {
        // Clear the current hand display.
        foreach (Transform child in handPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate a new card UI element for each card in the hand, if the prefab is assigned.
        if (cardPrefab != null)
        {
            foreach (Card card in hand)
            {
                GameObject cardUI = Instantiate(cardPrefab, handPanel.transform);
                cardUI.GetComponent<CardUI>().SetCard(card);
            }
        }
    }

    // Method to show the end game message.
    public void ShowEndGameMessage(string message)
    {
        GameObject messageBox = GameObject.Find("MessageBox");
        if (messageBox != null)
        {
            Text messageText = messageBox.GetComponentInChildren<Text>();
            if (messageText != null)
            {
                messageText.text = message;
                messageBox.SetActive(true); // Show the message box.
            }
            else
            {
                Debug.LogError("UIManager: MessageBox Text component not found.");
            }
        }
        else
        {
            Debug.LogError("UIManager: MessageBox GameObject not found.");
        }
    }

    // Helper method to validate and warn about unassigned UI components.
    private void ValidateUIComponents()
    {
        if (playerHealthText == null)
        {
            Debug.LogWarning("UIManager: PlayerHealthText is not assigned and will not display health.");
        }
        if (opponentHealthText == null)
        {
            Debug.LogWarning("UIManager: OpponentHealthText is not assigned and will not display health.");
        }
        if (handPanel == null)
        {
            Debug.LogWarning("UIManager: HandPanel is not assigned and will not display cards.");
        }
        if (cardPrefab == null)
        {
            Debug.LogWarning("UIManager: CardPrefab is not assigned and card UI elements cannot be instantiated.");
        }
    }
}

// CardUI class to handle the display and interaction of a card UI element.
public class CardUI : MonoBehaviour
{
    [SerializeField] private Text cardNameText; // Text UI for the card's name.
    [SerializeField] private Text attackPointsText; // Text UI for the card's attack points.
    [SerializeField] private Text defensePointsText; // Text UI for the card's defense points.
    [SerializeField] private Text effectDescriptionText; // Text UI for the card's effect description.

    // Method to set the card details on the card UI element.
    public void SetCard(Card card)
    {
        if (card != null)
        {
            cardNameText.text = card.CardName;
            attackPointsText.text = $"Attack: {card.AttackPoints}";
            defensePointsText.text = $"Defense: {card.DefensePoints}";
            effectDescriptionText.text = card.EffectDescription;
        }
    }
}

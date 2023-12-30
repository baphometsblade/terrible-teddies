using UnityEngine;

// Main class responsible for initializing and starting the game.
public class Main : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update.
    void Start()
    {
        // Find the GameManager component in the scene and store a reference to it.
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("Main: GameManager component not found in the scene.");
            return;
        }

        // Start the game through the GameManager.
        gameManager.StartGame();
    }

    // Update is called once per frame.
    void Update()
    {
        // The Main class does not handle update logic directly.
        // The GameManager will handle the game state updates.
    }
}

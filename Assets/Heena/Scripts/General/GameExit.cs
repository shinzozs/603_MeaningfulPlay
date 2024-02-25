using UnityEngine;

public class GameExit : MonoBehaviour
{
    void Update()
    {
        // Check for user input to exit the game
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ExitGame();
        }
    }

    public void ExitGame()
    {
        // Quit the application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

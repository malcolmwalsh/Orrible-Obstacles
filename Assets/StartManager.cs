using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Game started");

        SceneManager.LoadScene("Main Scene");
    }

    public void QuitGame()
    {
        Debug.Log("Game quit");

        // End the game
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}

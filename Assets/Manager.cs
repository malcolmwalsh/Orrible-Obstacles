using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
        Application.Quit();
    }
}

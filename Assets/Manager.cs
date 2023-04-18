using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    private bool _gameOver;
    private float _timeTaken = 0f;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject _deathScreen;

    private void Update()
    {
        if (!_gameOver)
        {
            // Increment time
            _timeTaken += Time.deltaTime;

            // Update text
            UpdateTimerDisplay(_timeTaken);
        }
    }

    public void GameOver()
    {
        _gameOver = true;

        // TODO disable movement

        // Show the death screen
        _deathScreen.SetActive(true);
    }

    public void Restart()
    {
        // New game
        _gameOver = false;

        // Reset timer
        ResetTimer();

        SceneManager.LoadScene("Main Scene");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
        Application.Quit();
    }

    private void ResetTimer()
    {
        _timeTaken = 0f;
    }

    private void UpdateTimerDisplay(float time)
    {
        // TODO Improve display
        timerText.text = time.ToString("0.00");
    }
}

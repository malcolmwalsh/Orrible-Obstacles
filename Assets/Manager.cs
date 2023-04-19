using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private bool _gameOver;
    private float _timeTaken = 0f;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private GameObject _playScreen;
    [SerializeField] private GameObject _winScreen;

    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private GameObject _startCamera;

    public void Start()
    {
        ToggleScreen(_deathScreen, false);
        ToggleScreen(_playScreen, true);
        ToggleScreen(_winScreen, false);
    }

    private void ToggleScreen(GameObject screen, bool value)
    {
        screen.SetActive(value);
    }

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
        Debug.Log("Game over");

        _gameOver = true;

        // TODO disable movement

        // Show the death screen
        _deathScreen.SetActive(true);
    }

    

    public void Restart()
    {
        Debug.Log("Game restarted");

        // New game
        _gameOver = false;

        // Reset timer
        ResetTimer();

        // Reload the scene
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

    private void ResetTimer()
    {
        _timeTaken = 0f;
    }

    private void UpdateTimerDisplay(float time)
    {
        // TODO Improve display
        timerText.text = time.ToString("0.00");
    }

    public void WinGame()
    {
        Debug.Log("Game won");

        _gameOver = true;

        ToggleScreen(_winScreen, true);       
    }
}

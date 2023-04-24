using Assets.OrribleUtils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class Manager : MonoBehaviour
    {
        private float _timeTaken = 0f;

        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private GameObject _deathScreen;
        [SerializeField] private GameObject _playScreen;
        [SerializeField] private GameObject _winScreen;

        [SerializeField] private GameObject _playerCamera;

        [SerializeField] private AudioSource _audio;

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
            // Increment time
            _timeTaken += Time.deltaTime;

            // Update text
            UpdateTimerDisplay(_timeTaken);
        }

        public static void PauseGame()
        {
            Time.timeScale = 0;
        }

        public static void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void GameOver()
        {
            Debug.Log("Game over");

            // Pause the game
            PauseGame();

            // Stop music
            StartCoroutine(AudioUtils.FadeOut(_audio, 1));

            // Show the death screen
            _deathScreen.SetActive(true);
        }

        public void Restart()
        {
            Debug.Log("Game restarted");

            // Resume game
            ResumeGame();

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
            // Improve display
            timerText.text = time.ToString("0.00");
        }

        public void WinGame()
        {
            Debug.Log("Game won");

            // Pause
            PauseGame();

            // Stop music
            StartCoroutine(AudioUtils.FadeOut(_audio, 1));

            // Show victory screen
            ToggleScreen(_winScreen, true);       
        }
    }
}

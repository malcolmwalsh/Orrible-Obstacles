using Assets.Player;
using UnityEngine;

namespace Assets.Objects.PowerUps
{
    public abstract class PowerUp : MonoBehaviour
    {
        [SerializeField] private Manager manager;
        [SerializeField] protected GameObject _icon;
        [SerializeField] protected Material _playerColor;
        [SerializeField] protected GameObject _tutorialScreen;
        
        protected PlayerMovement _playerMove;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player touches power up");

                // Get script
                _playerMove = other.GetComponent<PlayerMovement>();

                // Turn icon on
                _icon.SetActive(true);

                // Enable the power up
                EnablePowerUp();

                // Change color of player
                _playerMove.SetColor(_playerColor);

                // Pop-up tutorial
                OpenTutorial();

                // Destroy power up
                Destroy(this.gameObject);
            }
        }

        protected abstract void EnablePowerUp();

        private void OpenTutorial()
        {
            // TODO Pause game

            // Open screen
            _tutorialScreen.SetActive(true);
        }

        public void ExitTutorial()
        {
            // Close screen
            _tutorialScreen.SetActive(false);

            // TODO Unpause game

        }
    }
}

﻿using Assets.Player;
using UnityEngine;

namespace Assets.Objects.PowerUps
{
    public abstract class PowerUp : MonoBehaviour
    {
        [SerializeField] protected GameObject _icon;
        [SerializeField] protected Material _playerColor;
        [SerializeField] protected GameObject _tutorialScreen;

        protected PlayerMovement _playerMovement;
        private PlayerAesthetics _playerAesthetics;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player touches power up");

                // Get scripts
                _playerMovement = other.GetComponent<PlayerMovement>();
                _playerAesthetics = other.GetComponent<PlayerAesthetics>();

                // Turn icon on
                _icon.SetActive(true);

                // Enable the power up
                EnablePowerUp();

                // Change color of player
                _playerAesthetics.SetColor(_playerColor);

                // Pop-up tutorial
                if (GameState.Current.ShowTutorial(this))
                {
                    OpenTutorial();
                }

                // Disable power up
                this.gameObject.SetActive(false);
            }
        }

        protected abstract void EnablePowerUp();

        private void OpenTutorial()
        {
            // Pause game
            Manager.PauseGame();

            // Register seen this tutorial
            GameState.Current.RegisterTutorialSeen(this);

            // Open screen
            _tutorialScreen.SetActive(true);
        }

        public void ExitTutorial()
        {
            // Close screen
            _tutorialScreen.SetActive(false);

            // Unpause game
            Manager.ResumeGame();
        }

        public override string ToString()
        {
            return gameObject.name;
        }
    }
}

using System.Collections.Generic;
using Assets.Objects.PowerUps;
using UnityEngine;

namespace Assets
{
    public class GameState : MonoBehaviour
    {
        // Singleton pattern
        public static GameState Current { get; private set; }

        // Set of all tutorials seen already
        private ISet<string> _powerUpTutorialsSeen = new HashSet<string>();

        public void Awake()
        {
            if (Current != null && Current != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Current = this;
                
                DontDestroyOnLoad(gameObject);
            }
        }

        public void RegisterTutorialSeen(PowerUp powerUp)
        {
            _powerUpTutorialsSeen.Add(powerUp.name);
        }

        public bool ShowTutorial(PowerUp powerUp)
        {
            return !_powerUpTutorialsSeen.Contains(powerUp.name);
        }
    }
}

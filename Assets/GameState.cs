using UnityEngine;

namespace Assets
{
    public class GameState : MonoBehaviour
    {
        private static GameState _current;
        public static GameState Current { get { return _current; } }

        private bool _hasReadDoubleJumpTutorial = false;
        private bool _hasReadSpeedUpTutorial = false;

        private void Awake()
        {
            if (_current != null && _current != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _current = this;
                
                DontDestroyOnLoad(gameObject);
            }
        }


    }
}

using Assets.Player;
using UnityEngine;

namespace Assets.Objects.PowerUps
{
    public class DoubleJump : MonoBehaviour
    {
        [SerializeField] private GameObject icon;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player touches double jump");

                // Get script
                PlayerMovement playerMove = other.GetComponent<PlayerMovement>();

                // Enable double jump
                playerMove.EnableDoubleJump();

                // Turn icon on
                icon.SetActive(true);

                // TODO Change color of player

                // TODO Pop-up tutorial

                // Destroy power up
                Destroy(this.gameObject);

            }
        }
    }
}

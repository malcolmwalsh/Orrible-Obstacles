using UnityEngine;

namespace Assets.Objects.PowerUps
{
    public class DoubleJump : MonoBehaviour
    {
    
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Object entered trigger");

            if (other.CompareTag("Player"))
            {
                // Get script
                PlayerMovement playerMove = other.GetComponent<PlayerMovement>();

                // Enable double jump
                playerMove.EnableDoubleJump();

                // TODO Change color of player

                // TODO Pop-up tutorial

                // Destroy power up
                Destroy(this.gameObject);

            }
        }
    }
}
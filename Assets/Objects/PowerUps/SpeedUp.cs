using UnityEngine;

namespace Assets.Objects.PowerUps
{
    public class SpeedUp : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Object entered trigger");

            if (other.CompareTag("Player"))
            {
                // Get script
                PlayerMovement playerMove = other.GetComponent<PlayerMovement>();

                // Increase speed
                playerMove.IncreaseSpeed();

                // TODO Change color of player

                // TODO Pop-up tutorial

                // Destroy power up
                Destroy(this.gameObject);
            }
        }
    }
}

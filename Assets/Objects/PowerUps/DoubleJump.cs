using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    // Start is called before the first frame update
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

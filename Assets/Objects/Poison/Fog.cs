using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] private Manager _gameManager;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected in poison");

            // call game over
            _gameManager.GameOver();
        }
    }
}

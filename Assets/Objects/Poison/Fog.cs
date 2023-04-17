using UnityEngine;
using UnityEngine.UI;

public class Fog : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected in poison");

            // TODO disable movement

            // Show the canvas
            _canvas.SetActive(true);

        }
    }
}

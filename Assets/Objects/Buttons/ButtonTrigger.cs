using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private ButtonController _button;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player enters button zone");
            _button.EnableButton();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exits button zone");
            _button.DisableButton();
        }
    }
}

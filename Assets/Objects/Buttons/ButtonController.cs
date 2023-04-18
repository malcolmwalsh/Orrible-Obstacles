using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private bool _buttonEnabled = false;
    [SerializeField] private GameObject _light;

    public void Update()
    {
        if (_buttonEnabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TurnLightOff();
            }
        }
    }

    public void EnableButton()
    {
        _buttonEnabled = true;
    }

    public void DisableButton()
    {
        _buttonEnabled = false;
    }

    private void TurnLightOff()
    {
        _light.SetActive(false);
    }
}

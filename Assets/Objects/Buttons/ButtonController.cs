using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    [SerializeField] private Manager _manager;

    private bool _buttonEnabled = false;
    

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
        // Turn light off
        _light.SetActive(false);

        // Win the game
        _manager.WinGame();
    }
}

using UnityEngine;

public class LampBehaviour : MonoBehaviour
{
    [SerializeField] private float _minTimeBeforeChange;
    [SerializeField] private float _maxTimeBeforeChange;

    private float _remainingTime;

    private Light _light;

    // Start is called before the first frame update
    void Start()
    {
        // Get component
        _light = GetComponent<Light>();

        // Start with 1 second
        _remainingTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_remainingTime > 0)
        {
            // Just decrement
            _remainingTime -= Time.deltaTime;
        }
        else
        {
            // Time to do something

            // Toggle
            ToggleLight();

            // Sample new time
            _remainingTime = Random.Range(_minTimeBeforeChange, _maxTimeBeforeChange);
        }
    }

    private void ToggleLight()
    {
        Debug.Log("Toggling light");

        _light.enabled = !_light.enabled;
    }
}

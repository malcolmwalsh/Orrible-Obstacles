using UnityEngine;

namespace Assets.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class ForceReceiver : MonoBehaviour
    {
        [SerializeField] private float _mass = 3.0f; // defines the character mass
        [SerializeField] private Vector3 _resultingForce = Vector3.zero; 
        [SerializeField] private CharacterController _controller;

        // call this function to add an impact force:
        public void AddForce(Vector3 direction, float incomingForce)
        {
            Debug.Log("Force applied to a force receiver");

            // Make unit vector
            direction.Normalize();

            // Reflect down force on the ground
            if (direction.y < 0) direction.y *= -1;

            _resultingForce += direction * (incomingForce / _mass);
        }

        public void Update()
        {
            // apply the impact force:
            if (_resultingForce.magnitude > 0.2)
            {
                _controller.Move(_resultingForce * Time.deltaTime);
            }

            // consumes the impact energy each cycle:
            _resultingForce = Vector3.Lerp(_resultingForce, Vector3.zero, 5 * Time.deltaTime);
        }
    }
}

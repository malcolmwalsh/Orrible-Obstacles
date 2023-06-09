using Assets.Player;
using UnityEngine;

namespace Assets.Objects.Fans
{
    public class Fan : MonoBehaviour
    {
        [SerializeField] private float _fanPower = 1f;

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Object entered fan trigger zone");
        }

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player is in fan trigger zone");

                Vector3 position = transform.position;
                Vector3 targetPosition = other.transform.position;
                Vector3 direction = targetPosition - position;

                // Get force receiver
                // TODO Check it exists
                ForceReceiver forceReceiver = other.GetComponent<ForceReceiver>();

                // Apply force
                forceReceiver.AddForce(direction, _fanPower);
            }

        }
        void OnTriggerExit(Collider other)
        {
            Debug.Log("Object left the fan trigger zone");
        }
    }
}

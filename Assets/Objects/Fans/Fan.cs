using UnityEngine;

namespace Assets.Objects.Fans
{
    public class Fan : MonoBehaviour
    {
        [SerializeField] private int fanPower = 10;

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Object entered trigger");
        }
        void OnTriggerStay(Collider other)
        {
            Debug.Log("Object is in trigger");
            
            Vector3 position = transform.position;
            Vector3 targetPosition = other.transform.position;
            Vector3 direction = targetPosition - position;
            direction.Normalize();
            
            other.transform.position += direction * fanPower * Time.deltaTime;

        }
        void OnTriggerExit(Collider other)
        {
            Debug.Log("Object left the trigger");
        }
    }
}

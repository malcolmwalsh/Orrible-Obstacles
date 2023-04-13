using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] private int damageValue = 1;
    
    public void OnTriggerStay(Collider other)
    {
        //Debug.Log("Trigger fired");
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player detected in trigger");

            Stats stats = other.GetComponent<Stats>();

            stats.TakeDamage(damageValue);
        }
    }
}

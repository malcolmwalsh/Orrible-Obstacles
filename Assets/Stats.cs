using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] GameObject UIController;

    public void UIUpdate()
    {
        UIController.GetComponent<UIController>().UpdateHPBar(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UIUpdate();
    }
}

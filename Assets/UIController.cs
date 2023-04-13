using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Slider hpSlider;
    public Image img;
    [SerializeField] private Color color;
    
    public void UpdateHPBar(float hpValue)
    {
        hpSlider.value = hpValue;
        if (hpValue <= 0)
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            color.a = i;
            if (i >= 0.9f)
            {
                color.a = 1f;
            }
            img.color = color;
            yield return null;
        }
    }
}
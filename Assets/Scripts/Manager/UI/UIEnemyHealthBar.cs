using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Health enemyHealth;
    [SerializeField] private Slider slider;
    [SerializeField] private Image sliderFiller;

    private int thirdPart;
    private int twoThirdParts;

    private void Start()
    {
        if (enemyHealth == null || slider == null || sliderFiller == null)
        {
            throw new System.Exception("Not All Parameters Setted");
        }
        else
        {
            enemyHealth.Changed += HealthChanged;
            slider.wholeNumbers = true;
            slider.maxValue = enemyHealth.Full;
            slider.value = enemyHealth.Current;
            sliderFiller.GetComponent<Image>();
            thirdPart = enemyHealth.Full / 3;
            twoThirdParts = thirdPart * 2;
            HealthChanged(0,enemyHealth.Current);
        }
    }
    
    private void HealthChanged(int value, int current)
    {
        slider.value = current;
        if (current >= twoThirdParts)
        {
            sliderFiller.color = Color.green;
        }
        else if (current < twoThirdParts && current > thirdPart )
        {
            sliderFiller.color = Color.yellow;
        }
        else if (current <= thirdPart)
        {
            sliderFiller.color = Color.red;
        }
    }

    private void OnDestroy()
    {
        enemyHealth.Changed -= HealthChanged;
    }
}

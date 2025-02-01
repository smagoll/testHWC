using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthText;

    public void UpdateBar(int health)
    {
        healthText.text = health.ToString();
    }
}

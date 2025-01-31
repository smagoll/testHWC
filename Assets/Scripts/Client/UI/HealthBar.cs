using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro healthText;

    public void UpdateBar(int health)
    {
        healthText.text = health.ToString();
    }
}

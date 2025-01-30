using TMPro;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TextMeshProUGUI cooldownText;
    
    public Ability Ability { get; private set; }
    public int Cooldown { get; private set; }
    
    public void Init(Ability ability)
    {
        Ability = ability;

        titleText.text = ability.name;
        UpdateCooldown(0);
    }

    public void UpdateCooldown(int cooldown)
    {
        cooldownText.text = cooldown > 0 ? $"KD: {cooldown}" : "";
    }
}
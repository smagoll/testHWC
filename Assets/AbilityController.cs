using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TextMeshProUGUI cooldownText;

    private Button _button;
    
    private Controller _controller;
    private Ability _ability;

    public AbilityType AbilityType { get; private set; }
    
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Init(Ability ability, Controller controller)
    {
        _ability = ability;
        _controller = controller;
        
        UpdateAbility(ability);
    }

    public void UpdateAbility(Ability ability)
    {
        AbilityType = ability.abilityType;
        name = ability.name;
        titleText.text = ability.name;
        UpdateCooldown(ability.currentCooldown);
    }

    private void UpdateCooldown(int cooldown)
    {
        if (cooldown > 0)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
        
        cooldownText.text = $"KD: {cooldown}";
    }

    private void Activate()
    {
        _button.interactable = true;
        cooldownText.gameObject.SetActive(false);
    }

    private void Deactivate()
    {
        _button.interactable = false;
        cooldownText.gameObject.SetActive(true);
    }

    private void UseAbility()
    {
        _controller.UseAbility(_ability);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(UseAbility);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(UseAbility);
    }
}
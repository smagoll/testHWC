﻿using System;
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

    public AbilityType AbilityType { get; private set; }
    
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Init(AbilityInfo abilityInfo, Controller controller)
    {
        _controller = controller;
        
        SetAbility(abilityInfo);
    }

    private void SetAbility(AbilityInfo abilityInfo)
    {
        AbilityType = abilityInfo.abilityType;
        name = abilityInfo.title;
        titleText.text = abilityInfo.title;
        UpdateCooldown(abilityInfo.cooldown);
    }

    public void UpdateCooldown(int cooldown)
    {
        if (cooldown > 0)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
        
        cooldownText.text = cooldown > 0 ? $"KD: {cooldown}" : "";
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
        _controller.UseAbility(AbilityType);
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
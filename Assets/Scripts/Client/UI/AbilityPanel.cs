using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class AbilityPanel : MonoBehaviour
{
    [FormerlySerializedAs("abilityController")] [SerializeField]
    private AbilityController abilityControllerPrefab;
    [SerializeField]
    private CanvasGroup _canvasGroup;
    
    private Controller _controller;

    private List<AbilityController> abilityControllers = new();

    public void Init(Controller controller)
    {
        ResetPanel();
        
        _controller = controller;
        
        SpawnAbilities(controller.SelfUnit.abilities);
        
        Show();
    }

    private void SpawnAbilities(AbilityInfo[] abilities)
    {
        foreach (var ability in abilities)
        {
            var abilityController = Instantiate(abilityControllerPrefab, transform);
            abilityController.Init(ability, _controller);
            
            abilityControllers.Add(abilityController);
        }
    }

    public void UpdateAbility(string id, AbilityType abilityType, int cooldown)
    {
        if (_controller != null)
        {
            if (_controller.UnitController.Id == id) abilityControllers.FirstOrDefault(x => x.AbilityType == abilityType)?.UpdateCooldown(cooldown);
        }
    }
    
    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
    }

    private void ResetPanel()
    {
        foreach (var abilityController in abilityControllers)
        {
            Destroy(abilityController.gameObject);
        }

        abilityControllers = new();
    }
}
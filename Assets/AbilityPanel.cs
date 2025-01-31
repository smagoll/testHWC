using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class AbilityPanel : MonoBehaviour
{
    [FormerlySerializedAs("abilityController")] [SerializeField]
    private AbilityController abilityControllerPrefab;

    private Controller _controller;

    private List<AbilityController> abilityControllers = new();

    public void Init(Controller controller)
    {
        _controller = controller;
        
        SpawnAbilities(controller.SelfUnit.abilities);
    }

    private void SpawnAbilities(Ability[] abilities)
    {
        foreach (var ability in abilities)
        {
            var abilityController = Instantiate(abilityControllerPrefab, transform);
            abilityController.Init(ability, _controller);
            
            abilityControllers.Add(abilityController);
        }
    }

    public void UpdateAbility(AbilityType abilityType, int cooldown)
    {
        abilityControllers.FirstOrDefault(x => x.AbilityType == abilityType)?.UpdateCooldown(cooldown);
    }
}
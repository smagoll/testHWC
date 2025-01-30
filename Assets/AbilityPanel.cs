using TMPro;
using UnityEngine;

public class AbilityPanel : MonoBehaviour
{
    [SerializeField]
    private AbilityController abilityController;

    private Controller _controller;

    public void Init(Controller controller)
    {
        _controller = controller;
        
        SpawnAbilities(controller.GameUnit.abilities);
    }

    private void SpawnAbilities(Ability[] abilities)
    {
        foreach (var ability in abilities)
        {
            var abilityControllerGameObject = Instantiate(abilityController, transform);
            abilityControllerGameObject.Init(ability, _controller);
        }
    }
}
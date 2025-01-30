using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private UnitController unitControllerPrefab;

    private Unit _unit;
    
    protected GameClient GameClient;

    private UnitController unitController;
    
    public void Init(GameClient gameClient, Unit unit)
    {
        GameClient = gameClient;
        _unit = unit;
        
        SpawnUnit();
    }

    private void SpawnUnit()
    {
        unitController = Instantiate(unitControllerPrefab, transform);
        unitController?.Init(_unit);
    }

    public void UseAbility(Ability ability, Unit target)
    {
        var request = new Request<AbilityUseEvent>("use_ability", new AbilityUseEvent(ability, _unit.id, _unit.id)).GetJson();
        GameClient.SendRequest(request);
    }
}
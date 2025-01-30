using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private UnitController unitControllerPrefab;

    private Unit _unit;
    private Unit _enemy;
    
    protected GameClient GameClient;

    private UnitController unitController;

    public Unit Unit => _unit;
    
    public void Init(GameClient gameClient, Unit player, Unit enemy)
    {
        GameClient = gameClient;
        _unit = player;
        _enemy = enemy;
        
        SpawnUnit();
    }

    private void SpawnUnit()
    {
        unitController = Instantiate(unitControllerPrefab, transform);
        unitController.Init(_unit);
    }

    public void UseAbility(Ability ability)
    {
        var request = new RequestEvent(RequestType.UseAbility, new AbilityUseEvent(ability, _unit.id, _enemy.id)).GetJson();
        GameClient.SendRequest(request);
    }
}
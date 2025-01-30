using Unity.Android.Gradle.Manifest;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    [SerializeField]
    private UnitController unitControllerPrefab;

    private GameUnit gameUnit;
    private GameUnit _enemy;
    
    protected GameClient GameClient;

    private UnitController unitController;

    public GameUnit GameUnit => gameUnit;
    
    public void Init(GameClient gameClient, GameUnit player, GameUnit enemy)
    {
        GameClient = gameClient;
        gameUnit = player;
        _enemy = enemy;
        
        SpawnUnit();
        
        OnInit();
    }

    protected abstract void OnInit();

    private void SpawnUnit()
    {
        unitController = Instantiate(unitControllerPrefab, transform);
        unitController.Init(gameUnit);
    }

    public void UseAbility(Ability ability)
    {
        var request = new RequestEvent(RequestType.UseAbility, new AbilityUseEvent(ability, gameUnit.id, _enemy.id)).GetJson();
        GameClient.SendRequest(request);
    }
}
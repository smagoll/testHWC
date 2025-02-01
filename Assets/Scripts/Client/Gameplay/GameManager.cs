using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Database _database;
    [FormerlySerializedAs("battleSpawner")] [SerializeField]
    private BattleSystem battleSystem;
    
    private GameServer gameServer;
    private IServerAdapter Adapter { get; set; }
    
    private GameClient _gameClient;
    
    private void Awake()
    {
        gameServer = new GameServer(_database);
        Adapter = new ServerAdapter(gameServer);

        _gameClient = new GameClient(Adapter);
        
        battleSystem.Init(_gameClient);
        
        _gameClient.ServerAdapter.OnResponseHandler += Handle;

        var json = new RequestEvent(RequestType.BattleAction, new BattleActionEvent(BattleActionType.Start)).GetJson();
        SendRequest(json);
    }

    public void SendRequest(string request) => _gameClient.SendRequest(request);

    private void Handle(string response)
    {
        var responseJson = JsonUtility.FromJson<ResponseEvent>(response);
        
        switch (responseJson._responseType)
        {
            case RequestType.UpdateAbility:
                UpdateAbility(GetObject<UpdateAbilityEvent>(responseJson._data));
                break;
            case RequestType.UpdateUnit:
                UpdateUnit(GetObject<UpdateUnitEvent>(responseJson._data));
                break;
            case RequestType.BattleAction:
                BattleAction(GetObject<BattleActionEvent>(responseJson._data));
                break;
        }
    }

    private T GetObject<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }

    private void BattleAction(BattleActionEvent battleActionEvent)
    {
        BattleState battleState = battleActionEvent.battleState;
        
        switch (battleActionEvent.battleActionType)
        {
            case BattleActionType.Start:
                StartNewBattle(battleState);
                break;
            case BattleActionType.End:
                EndBattle(battleState);
                break;
            case BattleActionType.Update:
                UpdateBattleState(battleState);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(battleActionEvent), battleActionEvent, null);
        }
    }
    
    private void StartNewBattle(BattleState battleState)
    {
        battleSystem.SpawnBattle(battleState);
        UpdateBattleState(battleState);
    }

    private void EndBattle(BattleState battleState)
    {
        battleSystem.ResetControllers();
    }
    
    private void UpdateAbility(UpdateAbilityEvent updateAbilityEvent)
    {
        battleSystem.UISystem.AbilityPanel.UpdateAbility(updateAbilityEvent.id, updateAbilityEvent.abilityType, updateAbilityEvent.cooldown);
    }
    
    private void UpdateUnit(UpdateUnitEvent updateUnitEvent)
    {
        if (battleSystem.Controllers == null) return;
        var controller = battleSystem.Controllers.FirstOrDefault(x => x.UnitController.Id == updateUnitEvent.id);
        if (controller != null) controller.UnitController.UpdateUnit(updateUnitEvent.health, updateUnitEvent.abilityEffects);
    }
    
    private void UpdateBattleState(BattleState battleState)
    {
        battleSystem.UpdateBattleState(battleState);
    }
}
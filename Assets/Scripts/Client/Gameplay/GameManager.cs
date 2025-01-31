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
    public IServerAdapter Adapter { get; private set; }
    
    private GameClient _gameClient;
    
    private void Awake()
    {
        gameServer = new GameServer(_database);
        Adapter = new ServerAdapter(gameServer);

        _gameClient = new GameClient(Adapter);
        
        battleSystem.Init(_gameClient);
        
        _gameClient.ServerAdapter.OnResponseHandler += Handle;

        var json = new RequestEvent(RequestType.StartBattle, "").GetJson();
        
        _gameClient.SendRequest(json);
    }

    private void Handle(string response)
    {
        Debug.Log($"Клиент получил ответ: {response}");
        
        var responseJson = JsonUtility.FromJson<ResponseEvent>(response);
        
        switch (responseJson._responseType)
        {
            case RequestType.StartBattle:
                StartNewBattle(GetObject<Battle>(responseJson._data));
                break;
            case RequestType.UpdateAbility:
                UpdateAbility(GetObject<UpdateAbilityEvent>(responseJson._data));
                break;
            case RequestType.UpdateUnit:
                UpdateUnit(GetObject<UpdateUnitEvent>(responseJson._data));
                break;
            case RequestType.BattleState:
                UpdateBattleState(GetObject<BattleState>(responseJson._data));
                break;
        }
    }

    private T GetObject<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }
    
    private void StartNewBattle(Battle battle)
    {
        battleSystem.SpawnBattle(battle.player, battle.enemy);
    }
    
    private void UpdateAbility(UpdateAbilityEvent updateAbilityEvent)
    {
        battleSystem.UISystem.AbilityPanel.UpdateAbility(updateAbilityEvent.id, updateAbilityEvent.abilityType, updateAbilityEvent.cooldown);
    }
    
    private void UpdateUnit(UpdateUnitEvent updateUnitEvent)
    {
        var controller = battleSystem.Controllers.FirstOrDefault(x => x.UnitController.Id == updateUnitEvent.id);
        if (controller != null) controller.UnitController.UpdateHealth(updateUnitEvent.health);
    }
    
    private void UpdateBattleState(BattleState battleState)
    {
        battleSystem.UpdateBattleState(battleState);
    }
}
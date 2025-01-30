using System;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Database _database;
    [FormerlySerializedAs("battleSystem")] [SerializeField]
    private BattleSpawner battleSpawner;
    
    private GameServer gameServer;
    public IServerAdapter Adapter { get; private set; }
    
    private GameClient _gameClient;
    
    private void Awake()
    {
        gameServer = new GameServer(_database);
        Adapter = new ServerAdapter(gameServer);

        _gameClient = new GameClient(Adapter);
        
        _gameClient.ServerAdapter.OnResponseHandler += Handle;

        var json = new RequestEvent(RequestType.StartBattle, new GameEvent()).GetJson();
        
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
            case RequestType.UseAbility:
                UpdateAbility(GetObject<Ability>(responseJson._data));
                break;
        }
    }

    private T GetObject<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }
    
    private void StartNewBattle(Battle battle)
    {
        battleSpawner.SpawnBattle(_gameClient, battle.player, battle.enemy);
    }
    
    private void UpdateAbility(Ability ability)
    {
        battleSpawner.UISystem.AbilityPanel.UpdateAbility(ability);
    }
}
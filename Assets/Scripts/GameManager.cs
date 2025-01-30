using System;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
                StartNewBattle(responseJson._data);
                break;
        }
    }
    
    private void StartNewBattle(string response)
    {
        var battleData = JsonUtility.FromJson<Battle>(response);
        battleSpawner.SpawnBattle(_gameClient, battleData._player, battleData._enemy);
    }
}
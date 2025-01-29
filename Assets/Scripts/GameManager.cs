using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BattleSystem battleSystem;
    
    private GameServer gameServer;
    public IServerAdapter Adapter { get; private set; }
    
    private Player player;
    private Player enemy;
    
    private void Awake()
    {
        gameServer = new GameServer();
        Adapter = new ServerAdapter(gameServer);

        player = new Player(Adapter);
        enemy = new Player(Adapter);
    }

    private void Start()
    {
        StartNewBattle();
    }

    public void StartNewBattle()
    {
        battleSystem.SpawnBattle(player, enemy);
    }
}
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleSystem : MonoBehaviour
{
    public Action OnSwitchTurn;
    
    private GameClient _gameClient;
    
    [FormerlySerializedAs("uiSystem")] [SerializeField]
    private UISystem _uiSystem;
    
    [FormerlySerializedAs("controller")] [SerializeField]
    private Controller _controller;
    [FormerlySerializedAs("aiController")] [SerializeField]
    private Controller _aiController;

    public UISystem UISystem => _uiSystem;


    public Controller PlayerController => _controller;
    public Controller EnemyController => _aiController;
    public Controller[] Controllers { get; private set; }

    public void Init(GameClient gameClient)
    {
        _gameClient = gameClient;
    }
    
    public void SpawnBattle(GameUnit player, GameUnit enemy)
    {
        _controller.Init(this, player, enemy);
        _aiController.Init(this, enemy, player);
        
        Controllers = new[] { _controller, _aiController };
        
        _uiSystem.AbilityPanel.Init(_controller);
    }

    public void UseAbility(AbilityType abilityType, string selfId, string targetId)
    {
        var jsonData = JsonUtility.ToJson(new AbilityUseEvent(abilityType, selfId, targetId));
        var request = new RequestEvent(RequestType.UseAbility, jsonData).GetJson();
        _gameClient.SendRequest(request);
    }
    
    public void UpdateBattleState(BattleState battleState)
    {
        _controller.IsTurn = battleState.player;
        _aiController.IsTurn = battleState.enemy;
        
        OnSwitchTurn?.Invoke();
    }
}
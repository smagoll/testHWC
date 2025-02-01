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
    public Controller[] Controllers { get; private set; }

    public void Init(GameClient gameClient)
    {
        _gameClient = gameClient;
    }
    
    public void SpawnBattle(BattleState battleState)
    {
        _controller.Init(battleState.player, battleState.enemy);
        _aiController.Init(battleState.enemy, battleState.player);
        
        Controllers = new[] { _controller, _aiController };
        
        _uiSystem.AbilityPanel.Init(_controller);
    }

    public void UseAbility(AbilityType abilityType, string selfId, string targetId)
    {
        var abilityUseEvent = new AbilityUseEvent(abilityType, selfId, targetId);
        var request = new RequestEvent(RequestType.UseAbility, abilityUseEvent).GetJson();
        _gameClient.SendRequest(request);
    }
    
    public void UpdateBattleState(BattleState battleState)
    {
        _controller.IsTurn = battleState.player.isTurn;
        _aiController.IsTurn = battleState.enemy.isTurn;
        
        OnSwitchTurn?.Invoke();
    }

    public void ResetControllers()
    {
        if (Controllers == null) return;
        
        foreach (var controller in Controllers)
        {
            controller.ResetController();
        }
        
        _uiSystem.AbilityPanel.Hide();
    }
}
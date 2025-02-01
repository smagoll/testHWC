using UnityEngine;

public class BattleHandler : Handler
{
    private int steps;
    private Battle _battle;

    public Battle Battle => _battle;
    
    public BattleHandler(GameServer gameServer) : base(gameServer)
    {
        EventBus.UpdateAbility += SendResponseUpdateAbility;
        EventBus.UpdateUnit += SendResponseUpdateUnit;
    }

    public override void Handle(string request)
    {
        var player = new GameUnit("Default", 30, GetAbilities());
        var enemy = new GameUnit("Default", 30, GetAbilities());
        _battle = new Battle(player , enemy);
        
        SendBattleStart();
    }

    private void SendBattleStart()
    {
        BattleState battleState = _battle.GetBattleState();
        _gameServer.SendResponse(RequestType.StartBattle, battleState);
    }
    
    private void SendBattleState()
    {
        BattleState battleState = _battle.GetBattleState();
        _gameServer.SendResponse(RequestType.BattleState, battleState);
    }
    
    public void Step()
    {
        _battle.SwitchState();
        SendBattleState();
        _battle.OnSwitchState?.Invoke();
    }
    
    private void SendResponseUpdateAbility(string id, AbilityType abilityType, int cooldown)
    {
        UpdateAbilityEvent updateAbilityEvent = new UpdateAbilityEvent(id, abilityType, cooldown);
        _gameServer.SendResponse(RequestType.UpdateAbility, updateAbilityEvent);
    }
    
    private void SendResponseUpdateUnit(string id, int health)
    {
        UpdateUnitEvent updateUnitEvent = new UpdateUnitEvent(id, health);
        _gameServer.SendResponse(RequestType.UpdateUnit, updateUnitEvent);
    }

    private Ability[] GetAbilities()
    {
        var abilities = new[]
        {
            _gameServer.Database.GetAbility(AbilityType.Attack),
            _gameServer.Database.GetAbility(AbilityType.Barrier),
            _gameServer.Database.GetAbility(AbilityType.Regen),
            _gameServer.Database.GetAbility(AbilityType.FireBall),
            _gameServer.Database.GetAbility(AbilityType.Purge)
        };

        return abilities;
    }
}
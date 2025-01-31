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
        
        string jsonStart = JsonUtility.ToJson(_battle);
        ResponseEvent responseEventStart = new(RequestType.StartBattle, jsonStart);
        SendBattleState();
        
        _gameServer.SendResponse(responseEventStart);
    }

    private void SendBattleState()
    {
        string jsonBattle = JsonUtility.ToJson(new BattleState(_battle.player.IsTurn, _battle.enemy.IsTurn));
        ResponseEvent responseEventState = new(RequestType.BattleState, jsonBattle);
        _gameServer.SendResponse(responseEventState);
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
        ResponseEvent responseEvent = new ResponseEvent(RequestType.UpdateAbility, JsonUtility.ToJson(updateAbilityEvent));
        _gameServer.SendResponse(responseEvent);
    }
    
    private void SendResponseUpdateUnit(string id, int health)
    {
        UpdateUnitEvent updateUnitEvent = new UpdateUnitEvent(id, health);
        ResponseEvent responseEvent = new ResponseEvent(RequestType.UpdateUnit, JsonUtility.ToJson(updateUnitEvent));
        _gameServer.SendResponse(responseEvent);
    }

    private Ability[] GetAbilities()
    {
        var abilities = new Ability[]
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
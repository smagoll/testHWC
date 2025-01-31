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
        
        string json = JsonUtility.ToJson(_battle);
        ResponseEvent responseEvent = new(RequestType.StartBattle, json);
        
        _gameServer.SendResponse(responseEvent);
    }
    
    public void Step()
    {
        steps++;
        
        if(steps % 2 == 0) UpdateStates();
    }

    private void UpdateStates()
    {
        foreach (var gameUnit in _battle.units)
        {
            foreach (var ability in gameUnit.abilities)
            {
                ability.ReduceCooldown();
            }
        }
    }
    
    private void SendResponseUpdateAbility(AbilityType abilityType, int cooldown)
    {
        UpdateAbilityEvent updateAbilityEvent = new UpdateAbilityEvent(abilityType, cooldown);
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
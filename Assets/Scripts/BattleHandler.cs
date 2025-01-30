using UnityEngine;

public class BattleHandler : Handler
{
    private int steps;
    private Battle _battle;

    public Battle Battle => _battle;
    
    public BattleHandler(GameServer gameServer) : base(gameServer)
    {
        EventBus.UseAbility += SendResponseUseAbility;
    }

    public override void Handle(string request)
    {
        var abilities = new Ability[]
        {
            _gameServer.Database.GetAbility(AbilityType.Attack),
            _gameServer.Database.GetAbility(AbilityType.Barrier),
            _gameServer.Database.GetAbility(AbilityType.Regen),
            _gameServer.Database.GetAbility(AbilityType.FireBall),
            _gameServer.Database.GetAbility(AbilityType.Purge)
        };
        
        var player = new GameUnit("Default", 30, abilities);
        var enemy = new GameUnit("Default", 30, abilities);
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
    
    private void SendResponseUseAbility(Ability ability)
    {
        ResponseEvent responseEvent = new ResponseEvent(RequestType.UseAbility, JsonUtility.ToJson(ability));
        _gameServer.SendResponse(responseEvent);
    }
}
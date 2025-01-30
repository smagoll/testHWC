using UnityEngine;

public class BattleHandler : Handler
{
    private Battle _battle;

    public Battle Battle => _battle;
    
    public BattleHandler(IServerAdapter serverAdapter) : base(serverAdapter)
    {
    }

    public override void Handle(string request)
    {
        var abilities = new Ability[]
        {
            _serverAdapter.Database.GetAbility(AbilityType.Attack),
            _serverAdapter.Database.GetAbility(AbilityType.Barrier),
            _serverAdapter.Database.GetAbility(AbilityType.Regen),
            _serverAdapter.Database.GetAbility(AbilityType.FireBall),
            _serverAdapter.Database.GetAbility(AbilityType.Purge)
        };
        
        var player = new GameUnit("Default", 30, abilities);
        var enemy = new GameUnit("Default", 30, abilities);
        _battle = new Battle(player , enemy);
        
        string json = JsonUtility.ToJson(_battle);
        ResponseEvent responseEvent = new(RequestType.StartBattle, json);
        
        _serverAdapter.SendResponse(responseEvent);
    }
}
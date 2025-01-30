using UnityEngine;

public class BattleHandler : Handler
{
    public BattleHandler(IServerAdapter serverAdapter) : base(serverAdapter)
    {
    }

    public override void Handle(string request)
    {
        var player = new Unit("Default", 30, new Ability[] { new Ability(AbilityType.Attack, "Attack", 3) });
        var enemy = new Unit("Default", 30, new Ability[] { new Ability(AbilityType.Attack, "Attack", 3) });
        var battle = new Battle(player , enemy);
        
        string json = JsonUtility.ToJson(battle);
        ResponseEvent responseEvent = new(RequestType.StartBattle, json);
        
        _serverAdapter.SendResponse(responseEvent);
    }
}
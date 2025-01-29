using UnityEngine;

public class BattleHandler : Handler
{
    public BattleHandler(IServerAdapter serverAdapter) : base(serverAdapter)
    {
    }

    public override void Handle(string request)
    {
        var player = new Unit("Default", 30, new[] { new Attack() });
        var enemy = new Unit("Default", 30, new[] { new Attack() });
        var battle = new Battle(player , enemy);
        
        string json = JsonUtility.ToJson(battle);
        ResponseEvent responseEvent = new("start_battle", json);
        
        _serverAdapter.SendResponse(responseEvent);
    }
}
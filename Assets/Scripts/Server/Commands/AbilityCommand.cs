public class AbilityCommand : Command
{
    public AbilityCommand(GameServer gameServer) : base(gameServer)
    {
    }
    
    public void Execute(AbilityType abilityType, string selfId, string targetId)
    {
        var targetUnit = _gameServer.BattleHandler.Battle.GetUnit(targetId);
        var selfUnit = _gameServer.BattleHandler.Battle.GetUnit(selfId);
        var ability = selfUnit.GetAbility(abilityType);
        
        if (ability == null) return;
        if (!ability.IsReady) return;
        
        ability.Use(selfUnit, targetUnit);
        _gameServer.BattleHandler.Step();
    }
}
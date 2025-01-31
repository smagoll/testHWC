using System;

public class BarrierCommand : AbilityCommand
{
    public override void Action(string playerId, string targetId)
    {
        var targetUnit = _gameServer.BattleHandler.Battle.GetUnit(targetId);
        var selfUnit = _gameServer.BattleHandler.Battle.GetUnit(targetId);
        var ability = selfUnit.GetAbility(AbilityType.Attack);
        
        if (ability == null) return;
        if (!ability.IsReady) return;
        
        foreach (var abilityEffectType in ability.effects)
        {
            var abilityEffect = _gameServer.Database.GetEffect(abilityEffectType);
            targetUnit.AddEffect(abilityEffect);
        }
        
        ability.Use();
    }

    public BarrierCommand(GameServer gameServer) : base(gameServer)
    {
    }
}
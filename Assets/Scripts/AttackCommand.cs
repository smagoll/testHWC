using System;

public class AttackCommand : AbilityCommand
{
    public override void Action(string playerId, string targetId)
    {
        var targetUnit = _gameServer.BattleHandler.Battle.GetUnit(targetId);
        var selfUnit = _gameServer.BattleHandler.Battle.GetUnit(targetId);
        var ability = selfUnit.GetAbility(AbilityType.Attack);

        if (ability == null) return;
        if (!ability.IsReady) return;
        
        targetUnit.TakeDamage(ability.damage);
        ability.Use();
    }

    public AttackCommand(GameServer gameServer) : base(gameServer)
    {
    }
}
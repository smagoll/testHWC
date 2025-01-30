using System;

public class AttackCommand : AbilityCommand
{
    public override void Action(Guid playerId, Guid targetId)
    {
        var unit = _gameServer.BattleHandler.Battle.GetUnit(targetId);
        var ability = _gameServer.Database.GetAbility(AbilityType.Attack);

        if (ability.currentCooldown <= 0) return;

        unit.TakeDamage(ability.damage);
        ability.Use();
    }

    public AttackCommand(GameServer gameServer) : base(gameServer)
    {
    }
}
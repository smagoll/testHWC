using System;

public class AttackCommand : AbilityCommand
{
    protected override AbilityType AbilityType => AbilityType.Attack;

    public override void Action(string playerId, string targetId)
    {
        TargetUnit.TakeDamage(Ability.damage);
    }

    public AttackCommand(GameServer gameServer) : base(gameServer)
    {
    }
}
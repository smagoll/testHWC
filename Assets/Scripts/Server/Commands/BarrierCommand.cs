using System;

public class BarrierCommand : AbilityCommand
{
    protected override AbilityType AbilityType => AbilityType.Barrier;

    public override void Action(string playerId, string targetId)
    {
        foreach (var abilityEffectType in Ability.effects)
        {
            var abilityEffect = _gameServer.Database.GetEffect(abilityEffectType);
            SelfUnit.AddEffect(abilityEffect);
        }
    }

    public BarrierCommand(GameServer gameServer) : base(gameServer)
    {
    }
}
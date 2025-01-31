using System;

public class PurgeCommand : AbilityCommand
{
    protected override AbilityType AbilityType => AbilityType.Purge;

    public override void Action(string playerId, string targetId)
    {
        foreach (var abilityEffectType in Ability.effects)
        {
            var abilityEffect = _gameServer.Database.GetEffect(abilityEffectType);
            SelfUnit.AddEffect(abilityEffect);
        }
    }

    public PurgeCommand(GameServer gameServer) : base(gameServer)
    {
    }
}
using System;

public class RegenCommand : AbilityCommand
{
    protected override AbilityType AbilityType => AbilityType.Regen;

    public override void Action(string playerId, string targetId)
    {
        foreach (var abilityEffectType in Ability.effects)
        {
            var abilityEffect = _gameServer.Database.GetEffect(abilityEffectType);
            SelfUnit.AddEffect(abilityEffect);
        }
    }

    public RegenCommand(GameServer gameServer) : base(gameServer)
    {
    }
}
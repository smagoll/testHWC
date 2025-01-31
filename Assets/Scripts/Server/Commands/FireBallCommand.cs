using System;

public class FireBallCommand : AbilityCommand
{
    protected override AbilityType AbilityType => AbilityType.FireBall;

    public override void Action(string playerId, string targetId)
    {
        foreach (var abilityEffectType in Ability.effects)
        {
            var abilityEffect = _gameServer.Database.GetEffect(abilityEffectType);
            TargetUnit.AddEffect(abilityEffect);
        }
        
        TargetUnit.TakeDamage(Ability.damage);
    }

    public FireBallCommand(GameServer gameServer) : base(gameServer)
    {
    }
}
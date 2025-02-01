public class EffectHandler : Handler
{
    private AbilityCommand abilityCommand;
    
    public EffectHandler(GameServer gameServer) : base(gameServer)
    {
        GameplayEventBus.ApplyEffect += ApplyEffect;
        abilityCommand = new AbilityCommand(gameServer);
    }

    public override void Handle(string request)
    {
        
    }
    
    private void ApplyEffect(AbilityEffectType abilityEffectType, GameUnit selfUnit, GameUnit targetUnit)
    {
        var effect = _gameServer.Database.GetEffect(abilityEffectType);

        if (effect.IsSelf)
        {
            selfUnit.AddEffect(effect);
        }
        else
        {
            targetUnit.AddEffect(effect);
        }
    }
}
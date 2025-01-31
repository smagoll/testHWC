public abstract class AbilityCommand : Command
{
    protected AbilityCommand(GameServer gameServer) : base(gameServer)
    {
    }
    
    protected abstract AbilityType AbilityType { get; }
    
    protected GameUnit SelfUnit { get;  private set; }
    protected GameUnit TargetUnit { get;  private set; }
    protected Ability Ability { get;  private set; }
    
    public void Execute(string playerId, string targetId)
    {
        TargetUnit = _gameServer.BattleHandler.Battle.GetUnit(targetId);
        SelfUnit = _gameServer.BattleHandler.Battle.GetUnit(playerId);
        Ability = SelfUnit.GetAbility(AbilityType);
        
        if (Ability == null) return;
        if (!Ability.IsReady) return;
        
        Action(playerId, targetId);
        
        Ability.Use();
        EventBus.UpdateAbility?.Invoke(SelfUnit.id, Ability.abilityType, Ability.cooldown);
        _gameServer.BattleHandler.Step();
    }

    public abstract void Action(string playerId, string targetId);
}
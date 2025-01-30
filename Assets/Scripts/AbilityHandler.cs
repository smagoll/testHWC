using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : Handler
{
    private Dictionary<AbilityType, Command> abilityCommands = new();
    
    public AbilityHandler(IServerAdapter serverAdapter) : base(serverAdapter)
    {
    }
    
    public override void Handle(string request)
    {
        var abilityEvent = JsonUtility.FromJson<AbilityUseEvent>(request);
        
        if (!abilityCommands.ContainsKey(abilityEvent._ability.abilityType))
        {
            Command command = CreateCommand(abilityEvent._ability.abilityType);
            abilityCommands[abilityEvent._ability.abilityType] = command;
        }

        abilityCommands[abilityEvent._ability.abilityType].Execute(abilityEvent._playerId, abilityEvent._targetId);
    }
    
    private Command CreateCommand(AbilityType abilityType)
    {
        return abilityType switch
        {
            AbilityType.Attack => new AttackCommand(),
            AbilityType.Barrier => new BarrierCommand(),
            AbilityType.Regen => new RegenCommand(),
            AbilityType.FireBall => new FireBallCommand(),
            AbilityType.Purge => new PurgeCommand(),
            _ => throw new InvalidOperationException("Неизвестный тип способности")
        };
    }
}

public abstract class Command
{
    public abstract void Execute(Guid playerId, Guid targetId);
}

public class AttackCommand : Command
{
    public override void Execute(Guid playerId, Guid targetId)
    {
        
    }
}

public class BarrierCommand : Command
{
    public override void Execute(Guid playerId, Guid targetId)
    {
        
    }
}

public class RegenCommand : Command
{
    public override void Execute(Guid playerId, Guid targetId)
    {
        
    }
}

public class FireBallCommand : Command
{
    public override void Execute(Guid playerId, Guid targetId)
    {
        
    }
}

public class PurgeCommand : Command
{
    public override void Execute(Guid playerId, Guid targetId)
    {
        
    }
}
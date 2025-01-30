using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityHandler : Handler
{
    private Dictionary<AbilityType, AbilityCommand> abilityCommands = new();
    
    public AbilityHandler(GameServer gameServer) : base(gameServer)
    {
    }
    
    public override void Handle(string request)
    {
        var abilityEvent = JsonUtility.FromJson<AbilityUseEvent>(request);
        
        if (!abilityCommands.ContainsKey(abilityEvent._abilityType))
        {
            AbilityCommand command = CreateCommand(abilityEvent._abilityType);
            abilityCommands[abilityEvent._abilityType] = command;
        }

        abilityCommands[abilityEvent._abilityType].Execute(abilityEvent._playerId, abilityEvent._targetId);
    }
    
    private AbilityCommand CreateCommand(AbilityType abilityType)
    {
        return abilityType switch
        {
            AbilityType.Attack => new AttackCommand(_gameServer),
            AbilityType.Barrier => new BarrierCommand(_gameServer),
            AbilityType.Regen => new RegenCommand(_gameServer),
            AbilityType.FireBall => new FireBallCommand(_gameServer),
            AbilityType.Purge => new PurgeCommand(_gameServer),
            _ => throw new InvalidOperationException("Неизвестный тип способности")
        };
    }
}
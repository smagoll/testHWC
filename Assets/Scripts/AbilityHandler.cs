using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityHandler : Handler
{
    private Dictionary<AbilityType, AbilityCommand> abilityCommands = new();
    
    public AbilityHandler(GameServer gameServer) : base(gameServer)
    {
        EventBus.UseAbility += UseAbility;
        Debug.Log("add observer");
    }
    
    public override void Handle(string request)
    {
        var abilityEvent = JsonUtility.FromJson<AbilityUseEvent>(request);
        
        UseAbility(abilityEvent._abilityType, abilityEvent._playerId, abilityEvent._targetId);
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

    public void UseAbility(AbilityType abilityType, string playerId, string targetId)
    {
        if (!abilityCommands.ContainsKey(abilityType))
        {
            AbilityCommand command = CreateCommand(abilityType);
            abilityCommands[abilityType] = command;
        }

        abilityCommands[abilityType].Execute(playerId, targetId);
    }
}
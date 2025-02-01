using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityHandler : Handler
{
    private AbilityCommand abilityCommand;
    
    public AbilityHandler(GameServer gameServer) : base(gameServer)
    {
        EventBus.UseAbility += UseAbility;
        abilityCommand = new AbilityCommand(gameServer);
    }
    
    public override void Handle(string request)
    {
        var abilityEvent = JsonUtility.FromJson<AbilityUseEvent>(request);
        
        UseAbility(abilityEvent._abilityType, abilityEvent._playerId, abilityEvent._targetId);
    }

    private void UseAbility(AbilityType abilityType, string playerId, string targetId)
    {
        abilityCommand.Execute(abilityType, playerId, targetId);
    }
}
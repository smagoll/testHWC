using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AiPlayer
{
    private GameUnit _enemyId;
    private GameUnit _selfId;
    
    public AiPlayer(GameUnit selfId, GameUnit enemyId)
    {
        _enemyId = enemyId;
        _selfId = selfId;
    }
    
    public void OnStart()
    {
        if (_selfId.IsTurn)
        {
            var freeAbility = _enemyId.abilities.Where(x => x.IsReady).ToArray();
            var rnd = Random.Range(0, freeAbility.Length);
            EventBus.UseAbility?.Invoke(freeAbility[rnd].abilityType, _selfId.id, _enemyId.id);
        }
    }
}
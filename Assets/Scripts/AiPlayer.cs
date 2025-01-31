using System;
using System.Linq;
using System.Threading.Tasks;
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
    
    public async void OnStart()
    {
        await Task.Delay(1000);
        
        if (_selfId.IsTurn)
        {
            var freeAbility = _enemyId.abilities.Where(x => x.IsReady).ToArray();
            var rnd = Random.Range(0, freeAbility.Length);
            EventBus.UseAbility?.Invoke(freeAbility[rnd].abilityType, _selfId.id, _enemyId.id);
        }
    }
}
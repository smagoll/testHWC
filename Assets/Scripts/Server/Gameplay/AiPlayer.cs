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
        if (_selfId.IsTurn)
        {
            await Task.Delay(1000);
            Debug.Log("ai start");
            var freeAbility = _selfId.abilities.Where(x => x.IsReady).ToArray();
            var rnd = Random.Range(0, freeAbility.Length);
            EventBus.UseAbility?.Invoke(freeAbility[rnd].AbilityType, _selfId.id, _enemyId.id);
            Debug.Log($"Ability{freeAbility[rnd].AbilityType.ToString()}");
        }
    }
}
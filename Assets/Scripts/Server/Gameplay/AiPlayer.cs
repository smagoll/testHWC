using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
    
    public async void OnStart(CancellationTokenSource cts)
    {
        if (_selfId.IsTurn)
        {
            await Task.Delay(1000);
            if (cts.IsCancellationRequested) return;
            var freeAbility = _selfId.Abilities.Where(x => x.IsReady).ToArray();
            var rnd = Random.Range(0, freeAbility.Length);
            ResponseEventBus.UseAbilityResponse?.Invoke(freeAbility[rnd].AbilityType, _selfId.Id, _enemyId.Id);
        }
    }
}
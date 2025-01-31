using System.Collections;
using System.Linq;
using UnityEngine;

public class AIController : Controller
{
    protected override void OnStartTurn()
    {
        //StartCoroutine(Turn());
    }

    private IEnumerator Turn()
    {
        yield return new WaitForSeconds(1f);

        var freeAbility = SelfUnit.abilities.Where(x => x.IsReady).ToArray();
        var rnd = Random.Range(0, freeAbility.Length);
        UseAbility(freeAbility[rnd].abilityType);
    }
}
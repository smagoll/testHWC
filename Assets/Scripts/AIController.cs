using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AIController : Controller
{
    protected override void OnStartTurn()
    {
        StartCoroutine(Turn());
    }
    
    private IEnumerator Turn()
    {
        yield return new WaitForSeconds(1f);
        
        var rnd = UnityEngine.Random.Range(0, SelfUnit.abilities.Length);
        Debug.Log($"use {SelfUnit.abilities[rnd].abilityType.ToString()}");
        UseAbility(SelfUnit.abilities[rnd].abilityType);
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectsBar : MonoBehaviour
{
    [SerializeField] 
    private EffectUI effectUIPrefab;

    private List<EffectUI> effectsUI = new();
    
    public void UpdateBar(AbilityEffectInfo[] abilityEffectInfos)
    {
        List<EffectUI> effectsUICopy = new List<EffectUI>(effectsUI);
        
        foreach (var abilityEffectInfo in abilityEffectInfos)
        {
            var effectUI = effectsUI.FirstOrDefault(x => x.AbilityEffectType == abilityEffectInfo.abilityEffectType);
            if (effectUI == null)
            {
                SpawnEffect(abilityEffectInfo);
            }
            else
            {
                effectUI.UpdateDuration(abilityEffectInfo.duration);
                effectsUICopy.Remove(effectUI);
            }
        }

        foreach (var effectUI in effectsUICopy)
        {
            Destroy(effectUI.gameObject);
            effectsUI.Remove(effectUI);
        }
    }

    private void SpawnEffect(AbilityEffectInfo abilityEffectInfo)
    {
        var effectUI = Instantiate(effectUIPrefab, transform);
        effectUI.Init(abilityEffectInfo.abilityEffectType, abilityEffectInfo.title, abilityEffectInfo.duration);
        effectsUI.Add(effectUI);
    }
}

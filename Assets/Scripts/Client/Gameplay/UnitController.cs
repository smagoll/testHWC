using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private EffectsBar effectsBar;

    private string _id;
    private int _health;

    public string Id => _id;
    
    public void Init(GameUnitInfo gameUnitInfo)
    {
        _id = gameUnitInfo.id;
        _health = gameUnitInfo.health;
        
        UpdateBar();
    }

    public void UpdateUnit(int health, AbilityEffectInfo[] abilityEffectInfos)
    {
        UpdateHealth(health);
        UpdateEffectsBar(abilityEffectInfos);
    }
    
    private void UpdateHealth(int health)
    {
        _health = health;
        UpdateBar();
    }

    private void UpdateBar() => healthBar.UpdateBar(_health);
    private void UpdateEffectsBar(AbilityEffectInfo[] abilityEffectInfos) => effectsBar.UpdateBar(abilityEffectInfos);
}
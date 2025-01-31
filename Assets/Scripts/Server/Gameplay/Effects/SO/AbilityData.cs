using UnityEngine;

[CreateAssetMenu(menuName = "Ability")]
public class AbilityData : ScriptableObject
{
    public AbilityType abilityType;
    public string title;
    public int damage;
    public int cooldown;
    public AbilityEffectType[] effects;
}
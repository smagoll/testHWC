using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability")]
public abstract class AbilityData : ScriptableObject
{
    [SerializeField]
    protected AbilityType _abilityType;
    [SerializeField]
    protected string _title;
    [SerializeField]
    protected int _cooldown;
    [SerializeField]
    protected AbilityEffectType[] _effects;

    public AbilityType AbilityType => _abilityType;

    public abstract Ability GetAbility();
}
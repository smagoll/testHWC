using System;
using System.Linq;
using UnityEngine.Serialization;

[Serializable]
public class GameUnit
{
    public string id = Guid.NewGuid().ToString();
    public string name;
    public int health;
    public Ability[] abilities;
    public bool IsDeath { get; private set; }

    public GameUnit(string name, int health, Ability[] abilities)
    {
        this.name = name;
        this.health = health;
        this.abilities = abilities;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) IsDeath = true;
    }

    public Ability GetAbility(AbilityType abilityType)
    {
        return abilities.FirstOrDefault(x => x.abilityType == abilityType);
    }
}
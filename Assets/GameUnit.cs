using System;
using UnityEngine.Serialization;

[Serializable]
public class GameUnit
{
    public Guid id = Guid.NewGuid();
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
}
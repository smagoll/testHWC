using System;
using UnityEngine.Serialization;

[Serializable]
public class Unit
{
    public Guid id = Guid.NewGuid();
    public string name;
    public int health;
    public Ability[] abilities;

    public Unit(string name, int health, Ability[] abilities)
    {
        this.name = name;
        this.health = health;
        this.abilities = abilities;
    }
}
using System;

public class Unit
{
    public Guid Id = Guid.NewGuid();
    public string Name { get; private set; }
    public int Health { get; private set; }
    public Ability[] Abilities { get; private set; }

    public Unit(string name, int health, Attack[] abilities)
    {
        Name = name;
        Health = health;
        Abilities = abilities;
    }
}
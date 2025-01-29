public class Unit
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public Ability[] Abilities { get; private set; }

    public Unit(string name, int health, Ability[] abilities)
    {
        Name = name;
        Health = health;
        Abilities = abilities;
    }
}
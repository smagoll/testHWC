using System;

[Serializable]
public struct GameUnitInfo
{
    public string id;
    public int health;
    public AbilityInfo[] abilities;
    public bool isTurn;

    public GameUnitInfo(string id, int health, AbilityInfo[] abilities, bool isTurn)
    {
        this.id = id;
        this.health = health;
        this.abilities = abilities;
        this.isTurn = isTurn;
    }
}

[Serializable]
public struct AbilityInfo
{
    public AbilityType abilityType;
    public string title;
    public int cooldown;

    public AbilityInfo(AbilityType abilityType, string title, int cooldown)
    {
        this.abilityType = abilityType;
        this.title = title;
        this.cooldown = cooldown;
    }
}
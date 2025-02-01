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
using System;

[Serializable]
public struct UpdateUnitEvent
{
    public string id;
    public int health;

    public UpdateUnitEvent(string id, int health)
    {
        this.id = id;
        this.health = health;
    }
}
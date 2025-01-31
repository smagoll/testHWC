using System;

[Serializable]
public struct BattleState
{
    public bool player;
    public bool enemy;

    public BattleState(bool player, bool enemy)
    {
        this.player = player;
        this.enemy = enemy;
    }
}
using System;

[Serializable]
public struct BattleState
{
    public GameUnitInfo player;
    public GameUnitInfo enemy;

    public BattleState(GameUnitInfo player, GameUnitInfo enemy)
    {
        this.player = player;
        this.enemy = enemy;
    }
}
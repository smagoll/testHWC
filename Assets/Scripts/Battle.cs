using System;

[Serializable]
public struct Battle
{
    public Unit _player;
    public Unit _enemy;

    public Battle(Unit player, Unit enemy)
    {
        _player = player;
        _enemy = enemy;
    }
}
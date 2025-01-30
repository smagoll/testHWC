using System;

[Serializable]
public struct Battle
{
    public GameUnit _player;
    public GameUnit _enemy;

    public Battle(GameUnit player, GameUnit enemy)
    {
        _player = player;
        _enemy = enemy;
    }
}
using System;

public abstract class Command
{
    protected GameServer _gameServer;

    protected Command(GameServer gameServer)
    {
        _gameServer = gameServer;
    }
}
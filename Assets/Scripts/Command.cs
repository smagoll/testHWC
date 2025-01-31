using System;

public abstract class Command
{
    protected GameServer _gameServer;
    
    public Command(GameServer gameServer)
    {
        _gameServer = gameServer;
    }
}
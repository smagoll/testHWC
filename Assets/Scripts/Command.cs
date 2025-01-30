using System;

public abstract class Command
{
    protected GameServer _gameServer;
    
    public Command(GameServer gameServer)
    {
        _gameServer = gameServer;
    }
    
    public void Execute(string playerId, string targetId)
    {
        Action(playerId, targetId);
        _gameServer.BattleHandler.Step();
    }

    public abstract void Action(string playerId, string targetId);

}
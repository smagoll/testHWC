using System;

public abstract class Command
{
    protected GameServer _gameServer;
    
    public Command(GameServer gameServer)
    {
        _gameServer = gameServer;
    }
    
    public void Execute(Guid playerId, Guid targetId)
    {
        Action(playerId, targetId);
        _gameServer.BattleHandler.Step();
    }

    public abstract void Action(Guid playerId, Guid targetId);

}
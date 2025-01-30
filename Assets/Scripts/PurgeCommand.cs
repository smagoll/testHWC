using System;

public class PurgeCommand : AbilityCommand
{
    public override void Action(Guid playerId, Guid targetId)
    {
        
    }

    public PurgeCommand(GameServer gameServer) : base(gameServer)
    {
    }
}
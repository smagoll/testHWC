using System;

public class PurgeCommand : AbilityCommand
{
    public override void Action(string playerId, string targetId)
    {
        
    }

    public PurgeCommand(GameServer gameServer) : base(gameServer)
    {
    }
}
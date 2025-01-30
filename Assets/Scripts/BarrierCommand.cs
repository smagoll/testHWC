using System;

public class BarrierCommand : AbilityCommand
{
    public override void Action(string playerId, string targetId)
    {
        
    }

    public BarrierCommand(GameServer gameServer) : base(gameServer)
    {
    }
}